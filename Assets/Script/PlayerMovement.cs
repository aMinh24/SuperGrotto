using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody;
    [SerializeField]
    private BoxCollider2D boxCollider;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    LayerMask jumpableGround;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float playerSpeed = 6;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject skillPrefab;
    [SerializeField]
    private List<Transform> firepoint;
    [SerializeField]
    private TrailRenderer trailRenderer;

    private float dirX;
    private float dirY;

    private enum MovementState { Idle, Running, Jumping, Falling, Duck, Shoot, RunningShoot };
    private MovementState movementState;
    private bool isShooting = false;
    private bool isRunning = false;
    private bool isOnAir = false;
    private float shootingTime = 0;
    private float cooldownSkill = 0;
    private float comboTime = 0;
    public static bool side;
    private bool isNotDoubleJump;
    private bool isSkilling = false;
    private bool Boom = false;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    private KeyCode[] comboKeys = { KeyCode.S, KeyCode.D, KeyCode.J };
    private int currentKey = 0;

    public bool isClimbing;
    public bool canClimb;
    [SerializeField]
    private CinemachineVirtualCamera virtualCamera;

    public bool hasBoots = false;
    public bool bootPanel = false;
    private float timeBoots;
    private float initSpeed;

    public delegate void skillCooldown();
    public static skillCooldown skillCooldownDelegate;

    

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        trailRenderer = GetComponent<TrailRenderer>();
    }
    private void Start()
    {
        initSpeed = playerSpeed;
        trailRenderer.emitting = false;
        ItemCollector.updateBootsSpeed += ChangeSpeed;

        skillPrefab = Resources.Load("SKILL/"+DataManager.Instance.PlayerData.skillName) as GameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return;
        if (!GameManager.Instance.IsPlaying) return;
        if (Time.time > timeBoots)
        {
            UIManager.Instance.GamePanel.ActiveBoots(false);
            playerSpeed = initSpeed;
        }
        if (isDashing || animator.GetBool("Dead"))
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.K) && canDash&& isRunning)
        {
            StartCoroutine(Dash());
        }
        if (!isSkilling)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            if (canClimb)
            {
                dirY = Input.GetAxisRaw("Vertical");
            }
        }
        if (dirY != 0 && canClimb) isClimbing = true;
        else isClimbing = false;
        if (dirX != 0 /*&& canClimb*/) isRunning = true;
        else isRunning = false;
        Boom = false;
        shooting();
        jumping();
        if (dirY < -0.1f && IsGround())
        { dirY = 0; }

        UpdateAnimation();
        if (IsGround())
        {
            virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset.y = 1;

        }
        
    }
    private void FixedUpdate()
    {
        if (Time.timeScale == 0) return;
        if (!GameManager.Instance.IsPlaying) return;
        if (isDashing||animator.GetBool("Dead"))
        {
            return;
        }
        moving();
    }
    private void moving()
    {
        if (rigidbody.bodyType != RigidbodyType2D.Static)
        {
            rigidbody.velocity = new UnityEngine.Vector2(dirX * playerSpeed, rigidbody.velocity.y);
        }
        if (canClimb)
        {
            rigidbody.isKinematic = true;
            rigidbody.velocity = new UnityEngine.Vector2(dirX * playerSpeed, dirY*playerSpeed);
        }
        else if (!isClimbing&&!canClimb)
        {            
            rigidbody.isKinematic= false;
        }
        if (!isClimbing&&canClimb&&!IsGround()&&!isRunning)
        {
            rigidbody.velocity = UnityEngine.Vector2.zero;
        }
    }
    private void jumping()
    {
        if (IsGround() && !Input.GetButton("Jump"))
        {
            isNotDoubleJump = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGround() || isNotDoubleJump)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpHeight);
                isNotDoubleJump = !isNotDoubleJump;
                animator.SetBool("doubleJump", !isNotDoubleJump);
                isShooting = false;
                if (AudioManager.HasInstance)
                {
                    AudioManager.Instance.PlaySE(Audio.SE_JUMP);
                }
            }

        }
    }
    private void shooting()
    {
        if (movementState == MovementState.Idle && Time.time >= cooldownSkill && Input.GetKeyDown(comboKeys[currentKey]) && !isSkilling)
        {
            comboTime = Time.time + 1f;
            isSkilling = true;
            if (currentKey == 0) currentKey += 1;
        }
        if (Input.GetKeyDown(KeyCode.J) && Time.time >= shootingTime && !isSkilling)
        {
            Invoke("ShootAnimation", 0.2f);
            isShooting = true;
            shootingTime = Time.time + 1f;
            if (AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE(Audio.SE_SHOOT);
            }
        }
        if (isSkilling && Time.time < comboTime)
        {
            if (Input.GetKeyDown(comboKeys[currentKey]))
            {
                currentKey++;
                if (currentKey == 3)
                {
                    Invoke("SkillAnimation", 0.3f);
                    currentKey = 0;
                    isSkilling = false;
                    cooldownSkill = Time.time + CONST.SKILL_COOLDOWN;
                    Boom = true;
                    skillCooldownDelegate();
                }
            }
            else if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Space))
            {
                currentKey = 0;
                isSkilling = false;
            }

        }
        if (Time.time > comboTime) isSkilling= false;

    }
    private void ShootAnimation()
    {

        GameObject bullet;
        if (side)
        {
            bullet = Instantiate(bulletPrefab, firepoint[1].position, Quaternion.identity);
        }
        else bullet = Instantiate(bulletPrefab, firepoint[0].position, Quaternion.identity);
        Destroy(bullet, 2f);
    }
    private void SkillAnimation()
    {
        GameObject bullet;
        if (side)
        {
            bullet = Instantiate(skillPrefab, firepoint[1].position, Quaternion.identity);
        }
        else bullet = Instantiate(skillPrefab, firepoint[0].position, Quaternion.identity);
        Destroy(bullet, 3f);
    }
    private void UpdateAnimation()
    {
        if (animator.GetBool("Dead")) return;
        if (canClimb&&!isClimbing)
        {
            animator.SetTrigger("CanClimb");
        }
        if (canClimb&&isClimbing&&!IsGround())
        {
            virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset.y = 3; 
            animator.SetBool("Climb", true);
        }
        
        if (dirX > 0f)
        {
            spriteRenderer.flipX = false;
            virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset.x = 4;
            side = false;
            if (IsGround() && !isShooting)
            {
                movementState = MovementState.Running;
                
            }
        }
        else if (dirX < 0f)
        {
            spriteRenderer.flipX = true;
            virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset.x = -4;
            side = true;
            if (IsGround() && !isShooting) 
            {
                movementState = MovementState.Running;
            }


        }
        else if (!isClimbing)
        {
            movementState = MovementState.Idle;
        }

        isOnAir = false;
        if (rigidbody.velocity.y > 0.1f&&!isClimbing)
        {
            isOnAir = true;
            virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset.y = 3;

            movementState = MovementState.Jumping;
            
        }
        else if (rigidbody.velocity.y < -0.3f && !isClimbing&&!IsGround())
        {
            isOnAir = true;
            virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset.y = -3;

            movementState = MovementState.Falling;
        }


        if (isShooting && (!isRunning || isOnAir))
        {
            //Invoke("ShootAnimation", 0.2f);
            movementState = MovementState.Shoot;
            isShooting = false;
        }
        if (isShooting && isRunning)
        {
            movementState = MovementState.RunningShoot;

            //isShooting = false;
        }
        if (Boom)
        {
            movementState = MovementState.Duck;
            if (AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE(Audio.SE_SKILL);
            }
            Boom = false;
        }
        
        animator.SetInteger("State", (int)movementState);
    }
    private void PlayWalkSound()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_WALK);
        }
    }
    private bool IsGround()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
    private IEnumerator Dash()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_DASH);
        }
        canDash = false;
        isDashing = true;       
        float originalGravity = rigidbody.gravityScale;
        rigidbody.gravityScale = 0f;
        rigidbody.velocity = new Vector2(dirX * dashingPower, 0f);
        if (IsGround())
        {
            rigidbody.gravityScale = originalGravity;
            animator.SetBool("Slide", true);
        }
        else
        {

            trailRenderer.emitting = true;
        }

        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        rigidbody.gravityScale = originalGravity;
        isDashing = false;
        if (animator.GetBool("Dead"))
            yield break;
        animator.Rebind();
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    public void ChangeSpeed()
    {
        playerSpeed = initSpeed * 1.5f;
        timeBoots = Time.time+15f;
        
    }
    public void ResetSpeed()
    {
        playerSpeed = initSpeed;
    }

    

}
