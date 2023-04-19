using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ItemCollector : MonoBehaviour
{
    public string[] items = {"Boots","Helmet","Energy","Heart","Saphire"};
    [SerializeField]
    //private GamePanel gamePanel;
    public delegate void BootsSpeed();
    public static BootsSpeed updateBootsSpeed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Boots"))
        {
            updateBootsSpeed();
            gameObject.GetComponent<PlayerMovement>().hasBoots = true;
            UIManager.Instance.GamePanel.ActiveBoots(true);
        }
        if (collision.tag.Equals("Helmet"))
        {
            gameObject.GetComponent<PlayerLives>().hasShield = true;
            UIManager.Instance.GamePanel.ActiveHelmet(true);
        }
        if (collision.tag.Equals("Heart"))
        {
            gameObject.GetComponent<PlayerLives>().setLive = gameObject.GetComponent<PlayerLives>().Lives + 1;
            PlayerLives.updateHealthDelegate(gameObject.GetComponent<PlayerLives>().Lives);
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
