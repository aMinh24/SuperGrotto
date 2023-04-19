using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    //private PlayerLives playerLives;
    private bool isLoaded = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        //Invoke("DelayLoad", 0.3f);
    }
    private void OnEnable()
    {
        PlayerLives.updateHealthDelegate += UpdateHealth;
    }
    private void OnDisable()
    {
        PlayerLives.updateHealthDelegate -= UpdateHealth;
    }
    private void UpdateHealth(int value)
    {
        if (value == 6) animator.Rebind();
        animator.SetInteger("Health", value);
    }
    //private void Update()
    //{
    //    if(isLoaded)
    //    {
    //        if (playerLives.Lives == 6) animator.Rebind();
    //        animator.SetInteger("Health", playerLives.Lives);
    //    }        
    //}

    //void DelayLoad()
    //{
    //    playerLives = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLives>();
    //    isLoaded = true;
    //}
}
