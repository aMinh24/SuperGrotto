using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Door"))
        {
            if (AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE(Audio.SE_FINISH);
            }
            if (gameObject.GetComponent<ItemCollector>().Energy == 0) return;
            UIManager.Instance.ActiveVictoryPanel(true);
            DataManager.Instance.SavePlayerData();
            GameManager.Instance.PauseGame();
        }
    }
}
