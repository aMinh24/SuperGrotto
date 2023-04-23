using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public void OnResumeButton()
    {
        GameManager.Instance.Resume();
        UIManager.Instance.ActivePausePanel(false);
    }

    public void OnReplayButton()
    {
        Time.timeScale = 1.0f;
        UIManager.Instance.ActivePausePanel(false);
        GameManager.Instance.Replay();
    }
    public void OnBackToMenuButton()
    {
        Time.timeScale = 1.0f;
        UIManager.Instance.ActiveMenuPanel(true);
        UIManager.Instance.ActivePausePanel(false);
        UIManager.Instance.ActiveGamePanel(false);
        GameManager.Instance.RestartGame();
    }
    public void OnSettingButton()
    {
        UIManager.Instance.ActivePausePanel(false);
        UIManager.Instance.ActiveSettingPanel(true);
    }    
}
