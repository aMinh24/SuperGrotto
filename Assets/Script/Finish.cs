using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Door"))
        {
            if (gameObject.GetComponent<ItemCollector>().Energy == 0) return;
            
            if (AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE(Audio.SE_FINISH);
            }
            GameManager.Instance.PauseGame();
            UIManager.Instance.ActiveVictoryPanel(true);
            DataManager.Instance.SavePlayerData();
        }
    }
}
