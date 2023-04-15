using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPanel : MonoBehaviour
{
    public void OnReplayButton()
    {
        Time.timeScale = 1.0f;
        UIManager.Instance.ActiveVictoryPanel(false);
        GameManager.Instance.Replay();
    }
    public void OnBackToMenuButton()
    {
        Time.timeScale = 1.0f;
        UIManager.Instance.ActiveMenuPanel(true);
        UIManager.Instance.ActiveVictoryPanel(false);
        GameManager.Instance.RestartGame();
    }
    public void OnNextLevelButton()
    {
        Time.timeScale = 1.0f;
        UIManager.Instance.ActiveVictoryPanel(false);
        GameManager.Instance.ChangeScene("Level2");
    }
}
