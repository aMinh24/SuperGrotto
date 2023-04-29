using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public void OnResumeButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        GameManager.Instance.Resume();
        UIManager.Instance.ActivePausePanel(false);
    }

    public void OnReplayButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        Time.timeScale = 1.0f;
        UIManager.Instance.ActivePausePanel(false);
        GameManager.Instance.Replay();
    }
    public void OnBackToMenuButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        Time.timeScale = 1.0f;
        UIManager.Instance.ActiveMenuPanel(true);
        UIManager.Instance.ActivePausePanel(false);
        UIManager.Instance.ActiveGamePanel(false);
        GameManager.Instance.RestartGame();
    }
    public void OnSettingButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        UIManager.Instance.ActivePausePanel(false);
        UIManager.Instance.ActiveSettingPanel(true);
    }    
}
