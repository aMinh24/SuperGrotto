using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    public void OnNewGameButtonClick()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        GameManager.Instance.StartGame();
        UIManager.Instance.ActiveMenuPanel(false);
        UIManager.Instance.ActiveGamePanel(true);
        GameManager.Instance.ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnContinueButtonClick()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        GameManager.Instance.StartGame();
        UIManager.Instance.ActiveMenuPanel(false);
        UIManager.Instance.ActiveGamePanel(true);
        GameManager.Instance.ChangeScene(DataManager.Instance.PlayerData.sceneIndex);
    }
    public void OnReturnButtonClick()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        UIManager.Instance.MenuPanel.ActiveButtonMenu(true);
        UIManager.Instance.MenuPanel.ActiveButtonStart(false);
    }
}
