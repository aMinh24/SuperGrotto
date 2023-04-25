using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryPanel : MonoBehaviour
{
    public void OnReplayButton()
    {
        
        UIManager.Instance.ActiveVictoryPanel(false);
        GameManager.Instance.Replay();
    }
    public void OnBackToMenuButton()
    {
        UIManager.Instance.ActiveMenuPanel(true);
        UIManager.Instance.ActiveVictoryPanel(false);
        UIManager.Instance.ActiveGamePanel(false);
        GameManager.Instance.RestartGame();
    }
    public void OnNextLevelButton()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 > 2) return;
        PlayerLives.updateHealthDelegate(6);
        DataManager.Instance.resetSaphire();
        UIManager.Instance.GamePanel.resetGamePanel();
        GameManager.Instance.Resume();
        UIManager.Instance.ActiveVictoryPanel(false);
        GameManager.Instance.ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
