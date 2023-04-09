using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatLives : MonoBehaviour
{
    private int Lives = 2;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rb;
    private float resetTime = 1f;
    private Vector2 initialPosition;
    private float time;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Time.time > time)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0.0f;
            time = Time.time + 2f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("PlayerBullet"))
        {
            Debug.Log("hit");
            Lives--;
            if (Lives == 0)
            {
                Die();
            }
            animator.SetTrigger("Hurt");
            Invoke("Reb", 0.3f);
        }
        if (collision.CompareTag("Skill"))
        {
            Debug.Log("skill");
            Die();
        }
           
        
    }
    private void Die()
    {
        gameObject.SetActive(false);
    }
    private void Reb()
    {
        animator.Rebind();
    }
    IEnumerator ResetEnemy()
    {
        // Chờ một khoảng thời gian trước khi đưa kẻ địch về trạng thái cũ
        yield return new WaitForSeconds(resetTime);
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0.0f;
        transform.position = initialPosition;
       
    }

}
