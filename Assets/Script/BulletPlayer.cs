using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private CircleCollider2D circleCollider;
    [SerializeField]
    private Animator animator;
    
    private void Awake()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        if (PlayerMovement.side)
        {
            spriteRenderer.flipX= true;
            rb.AddForce(new Vector2(-1, 0) * speed, ForceMode2D.Impulse);
        }
        else
        {
            spriteRenderer.flipX= false;
            rb.AddForce(new Vector2(1, 0) * speed, ForceMode2D.Impulse);
        }
        circleCollider= GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Map"))
        {
            animator.SetInteger("State", 1);
            rb.bodyType = RigidbodyType2D.Static;
            Invoke("DesObj", 0.4f);
            if (AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE(Audio.SE_SHOOTHIT);
            }
        }
    }
    
    private void DesObj()
    {
        Destroy(gameObject);
    }
}
