using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryPanel : MonoBehaviour
{
    public void OnReplayButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        UIManager.Instance.ActiveVictoryPanel(false);
        GameManager.Instance.Replay();
    }
    public void OnBackToMenuButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        UIManager.Instance.ActiveMenuPanel(true);
        UIManager.Instance.ActiveVictoryPanel(false);
        UIManager.Instance.ActiveGamePanel(false);
        GameManager.Instance.RestartGame();
    }
    public void OnNextLevelButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        if (SceneManager.GetActiveScene().buildIndex + 1 > 2) return;
        PlayerLives.updateHealthDelegate(6);
        DataManager.Instance.resetSaphire();
        UIManager.Instance.GamePanel.resetGamePanel();
        GameManager.Instance.Resume();
        UIManager.Instance.ActiveVictoryPanel(false);
        GameManager.Instance.ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
