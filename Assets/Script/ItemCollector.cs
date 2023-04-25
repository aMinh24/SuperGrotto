using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ItemCollector : MonoBehaviour
{
    [SerializeField]
    private GameObject door;
    private int energy;
    public int Energy => energy;
    // khi qua màn mới lưu lại cái saphie
    public string[] items = {"Boots","Helmet","Energy","Heart","Saphire"};
    [SerializeField]
    //private GamePanel gamePanel;
    public delegate void BootsSpeed();
    public static BootsSpeed updateBootsSpeed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.timeScale != 1) return;
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
            if (gameObject.GetComponent<PlayerLives>().Lives == 6) return;
            gameObject.GetComponent<PlayerLives>().setLive = gameObject.GetComponent<PlayerLives>().Lives + 1;
            PlayerLives.updateHealthDelegate(gameObject.GetComponent<PlayerLives>().Lives);
        }
        if (collision.tag.Equals("Saphire"))
        {
            DataManager.Instance.updateSaphire();
            UIManager.Instance.GamePanel.loadData();
        }
        if (collision.tag.Equals("Energy"))
        {
            energy++;
            door.GetComponent<Animator>().enabled = true;
            if (UIManager.HasInstance)
            {
                UIManager.Instance.GamePanel.updateEnergy(energy);
            }    
        }
        foreach (var item in items)
        {
            if (collision.CompareTag(item))
            {
                if (AudioManager.HasInstance)
                {
                    AudioManager.Instance.PlaySE(Audio.SE_COLLECT);
                }
                Destroy(collision.gameObject);
            }
        }
    }
}
