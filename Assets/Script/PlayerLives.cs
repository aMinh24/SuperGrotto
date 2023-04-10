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
    private float time;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider= GetComponent<BoxCollider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Monster")&& !animator.GetBool("Dead"))
        {
            if (Time.time < time) return;
            lives--;
            time = Time.time+0.3f;
            Debug.Log("mon " + lives);
            if (lives == 0)
            {
                StartCoroutine(Die());
                return;
            }
            Debug.Log("no");
            animator.SetTrigger("Hurt");
            Rigidbody2D enemyRigidbody = coll.GetComponent<Rigidbody2D>(); // Lấy Rigidbody của đối tượng kẻ địch
            cinemachineImpulseSource.GenerateImpulse(Camera.main.transform.forward);
            if (enemyRigidbody != null) // Kiểm tra nếu đối tượng kẻ địch có Rigidbody
            {
                Vector2 pushDirection = (enemyRigidbody.transform.position - transform.position).normalized; // Tính hướng đẩy từ nhân vật tới kẻ địch
                enemyRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse); // Thêm lực đẩy vào kẻ địch
                
            }
            Invoke("rebind", 0.3f);
        }
        else if ((coll.CompareTag("Bullet"))&& !animator.GetBool("Dead"))
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
        if (coll.CompareTag("Trap")&&!animator.GetBool("Dead"))
        {
            StartCoroutine(Die());
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
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
   
}
