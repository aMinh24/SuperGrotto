using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Debug.Log("climb");
            collision.gameObject.GetComponent<PlayerMovement>().canClimb = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Debug.Log("notClimb");
            collision.gameObject.GetComponent<PlayerMovement>().canClimb = false;
            collision.gameObject.GetComponent<PlayerMovement>().isClimbing = false;

            collision.gameObject.GetComponent<Animator>().Rebind();
        }
    }
}
