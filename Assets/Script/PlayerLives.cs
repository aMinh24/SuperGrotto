using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using Cinemachine;
public class PlayerLives : MonoBehaviour
{
    private int lives = 3;
    [SerializeField]
    private float pushForce = 10f;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private BoxCollider2D boxCollider;
    public CinemachineCollisionImpulseSource cinemachineImpulseSource;
    [SerializeField]
    private CinemachineVirtualCamera cinemachine;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider= GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Monster"))
        {
            lives--;
            if (lives == 0)
            {
                StartCoroutine(Die());
                return;
            }
            animator.SetTrigger("Hurt");
            Rigidbody2D enemyRigidbody = coll.collider.GetComponent<Rigidbody2D>(); // Lấy Rigidbody của đối tượng kẻ địch
            cinemachineImpulseSource.GenerateImpulse(Camera.main.transform.forward);
            if (enemyRigidbody != null) // Kiểm tra nếu đối tượng kẻ địch có Rigidbody
            {
                Vector2 pushDirection = (enemyRigidbody.transform.position - transform.position).normalized; // Tính hướng đẩy từ nhân vật tới kẻ địch
                enemyRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse); // Thêm lực đẩy vào kẻ địch
            }
            Invoke("rebind", 0.3f);
        }
        else if ((coll.gameObject.CompareTag("Bullet")))
        {
            lives--;
            if (lives == 0)
            {
                StartCoroutine(Die());
                return;
            }
            cinemachineImpulseSource.GenerateImpulse(Camera.main.transform.forward);
            animator.SetTrigger("Hurt");
            Invoke("rebind", 0.3f);
        }
        
    }
    private void rebind()
    {
        animator.Rebind();
    }
    private IEnumerator Die()
    {
        cinemachine.m_Follow = null;     
        Time.timeScale = 0.2f;
        animator.SetBool("Dead", true);
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        boxCollider.isTrigger = true;
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1f;
        Destroy(this, 2f);
    }    
}
