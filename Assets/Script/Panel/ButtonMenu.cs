using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        //GameManager.Instance.StartGame();
        //UIManager.Instance.ActiveMenuPanel(false);
        //UIManager.Instance.ActiveGamePanel(true);
        //GameManager.Instance.ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);
        UIManager.Instance.MenuPanel.ActiveButtonMenu(false);
        UIManager.Instance.MenuPanel.ActiveButtonStart(true);
    }
    public void OnSettingButtonClick()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        UIManager.Instance.ActiveSettingPanel(true);
    }
    public void OnExitButtonClick()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        GameManager.Instance.EndGame();
    }
}
