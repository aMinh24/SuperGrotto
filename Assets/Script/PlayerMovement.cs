using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float playerSpeed;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private List<Transform> firepoint;
    private float dirX;
    private float dirY;
    
    private enum MovementState { Idle,Running,Jumping,Falling,Hurt,Shoot,RunningShoot};
    private MovementState movementState;
    private bool isShooting = false;
    private bool isRunning = false;
    private bool isOnAir = false;
    private bool isWaiting = false;
    private float waitingTime = 0;
    public static bool side;
    PlayerLives pl = new PlayerLives();
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if (dirX != 0) isRunning = true;
        else isRunning = false;
        if (Time.time < waitingTime) isWaiting = true;
        else isWaiting= false;
        jumping();
        shooting();
        UpdateAnimation();
    }
    private void FixedUpdate()
    {
        moving();
    }
    private void moving()
    {
        if (rigidbody.bodyType != RigidbodyType2D.Static)
            rigidbody.velocity = new Vector2(dirX * playerSpeed, rigidbody.velocity.y);
    }
    private void jumping()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGround())
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpHeight);
            
        }
    }
    private void shooting()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            
            isShooting = true;
        }    
    }    
    private void ShootAnimation() 
    {
        GameObject bullet;
        if (side)
        {
            bullet = Instantiate(bulletPrefab, firepoint[1].position, Quaternion.identity);
        }
        else bullet = Instantiate(bulletPrefab, firepoint[0].position, Quaternion.identity);
        Destroy(bullet, 5f);
    }
    private void UpdateAnimation()
    {
        if (!isWaiting)
        {
            if (dirX > 0f)
            {
                spriteRenderer.flipX = false;
                side = false;
                if (IsGround() && !isShooting) movementState = MovementState.Running;
            }
            else if (dirX < 0f)
            {
                spriteRenderer.flipX = true;
                side = true;
                if (IsGround() && !isShooting)
                    movementState = MovementState.Running;
            }
            else movementState = MovementState.Idle;

            isOnAir = false;
            if (rigidbody.velocity.y > 0.1f)
            {
                isOnAir = true;
                movementState = MovementState.Jumping;
            }
            else if (rigidbody.velocity.y < -0.1f)
            {
                isOnAir = true;
                movementState = MovementState.Falling;
            }
        }
        
        if (isShooting && (!isRunning||isOnAir))
        {
            movementState = MovementState.Shoot;
            isShooting = false;
        }
        if (isShooting && isRunning)
        {
            Debug.Log("run shoot");
            movementState = MovementState.RunningShoot;
            waitingTime += 1f;
            isShooting = false;
        }
        Debug.Log("Hurt " + pl.getIsHurt());
        if (pl.getIsHurt() && !isOnAir)
        {
            Debug.Log("hurt");
            pl.setIsHurt(false);
            movementState = MovementState.Hurt; 
        }
        animator.SetInteger("State", (int)movementState);
    } 
    private bool IsGround()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
