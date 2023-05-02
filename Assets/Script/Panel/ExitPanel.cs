using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPanel : MonoBehaviour
{
    public void OnYesButtonClick()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        GameManager.Instance.EndGame();
    }
    public void OnBackToMenuButtonClick()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        UIManager.Instance.ActiveMenuPanel(true);
        UIManager.Instance.ActiveExitPanel(false);
    }
}
