using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
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
    }
}
