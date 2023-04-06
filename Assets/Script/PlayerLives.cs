using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    private int lives = 3;
    [SerializeField]
    private float pushForce = 10f;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rb;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Monster"))
        {
            
            animator.SetTrigger("Hurt");
            Rigidbody2D enemyRigidbody = coll.collider.GetComponent<Rigidbody2D>(); // Lấy Rigidbody của đối tượng kẻ địch

            if (enemyRigidbody != null) // Kiểm tra nếu đối tượng kẻ địch có Rigidbody
            {
                Vector2 pushDirection = (enemyRigidbody.transform.position - transform.position).normalized; // Tính hướng đẩy từ nhân vật tới kẻ địch
                enemyRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse); // Thêm lực đẩy vào kẻ địch
            }
            Invoke("rebind", 0.3f);
        }
    }    
    private void rebind()
    {
        animator.Rebind();
    }
}
