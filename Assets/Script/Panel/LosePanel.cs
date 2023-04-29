using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    public void OnReplayButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        UIManager.Instance.GamePanel.resetGamePanel();
        Time.timeScale = 1.0f;
        UIManager.Instance.ActiveLosePanel(false);
        GameManager.Instance.Replay();
    }
    public void OnBackToMenuButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        Time.timeScale = 1.0f;
        UIManager.Instance.ActiveGamePanel(false);
        UIManager.Instance.ActiveMenuPanel(true);
        UIManager.Instance.ActiveLosePanel(false);
        GameManager.Instance.RestartGame();
    }
}
