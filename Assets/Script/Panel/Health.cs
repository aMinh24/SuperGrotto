using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject Player;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Player.GetComponent<PlayerLives>().Lives == 6) animator.Rebind();
        animator.SetInteger("Health", Player.GetComponent<PlayerLives>().Lives);
    }
}
