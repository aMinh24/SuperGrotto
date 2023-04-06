using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    private int lives = 3;
    private bool isHurt= false;
    [SerializeField]
    private float pushForce = 10f;
    public bool getIsHurt()
    {
        return isHurt;
    }    
    public void setIsHurt(bool isHurt)
    {
        this.isHurt = isHurt;
    }    
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Monster"))
        {
            this.isHurt= true;
        }
        else this.isHurt= false;
        Debug.Log("hurt " + isHurt);
        Rigidbody2D enemyRigidbody = coll.collider.GetComponent<Rigidbody2D>(); // Lấy Rigidbody của đối tượng kẻ địch

        if (enemyRigidbody != null) // Kiểm tra nếu đối tượng kẻ địch có Rigidbody
        {
            Vector2 pushDirection = (enemyRigidbody.transform.position - transform.position).normalized; // Tính hướng đẩy từ nhân vật tới kẻ địch
            enemyRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse); // Thêm lực đẩy vào kẻ địch
        }
    }    
}
