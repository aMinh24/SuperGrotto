using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        GameManager.Instance.Resume();
        Time.timeScale = 1.0f;
        UIManager.Instance.ActiveVictoryPanel(false);
        GameManager.Instance.ChangeScene("Level2");
    }
}
