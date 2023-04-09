using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkelekonLives : MonoBehaviour
{
    private int Lives = 3;
    [SerializeField]
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
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
}
