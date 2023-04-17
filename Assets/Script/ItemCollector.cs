using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public string[] items = {"Boots","Helmet","Energy","Heart","Saphire"};
    [SerializeField]
    private GamePanel gamePanel;
    private void Update()
    {
        gamePanel.ActiveBoots(gameObject.GetComponent<PlayerMovement>().bootPanel);
        gamePanel.ActiveHelmet(gameObject.GetComponent<PlayerLives>().hasShield);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Boots"))
        {
            gameObject.GetComponent<PlayerMovement>().hasBoots = true;
            gamePanel.ActiveBoots(true);
        }
        if (collision.tag.Equals("Helmet"))
        {
            gameObject.GetComponent<PlayerLives>().hasShield = true;
            gamePanel.ActiveHelmet(true);
        }
        if (collision.tag.Equals("Heart"))
        {
            gameObject.GetComponent<PlayerLives>().setLive = gameObject.GetComponent<PlayerLives>().Lives + 1;
        }
        foreach (var item in items)
        {
            if (collision.CompareTag(item))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
