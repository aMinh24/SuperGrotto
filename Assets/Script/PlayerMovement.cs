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
    private float dirX;
    private float dirY;

    private enum MovementState { Idle,Running,Jumping,Falling};
    private MovementState movementState;


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
        jumping();
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
    private void UpdateAnimation()
    {
        if (dirX > 0f)
        {
            spriteRenderer.flipX = false;
            if (IsGround()) movementState = MovementState.Running;
        }
        else if (dirX < 0f)
        {
            spriteRenderer.flipX = true;
            if (IsGround())
                movementState = MovementState.Running;
        }
        else movementState = MovementState.Idle;

        if (rigidbody.velocity.y > 0.1f)
        {
            movementState= MovementState.Jumping;
        }
        else if (rigidbody.velocity.y < -0.1f)
        {
            movementState= MovementState.Falling;
        }
        animator.SetInteger("State", (int)movementState);
    }
    private bool IsGround()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
