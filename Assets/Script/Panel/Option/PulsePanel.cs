using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsePanel : MonoBehaviour
{
    public void OnUseButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        DataManager.Instance.PlayerData.skillName = SKILLCONST.PUSLE;
        UIManager.Instance.ActiveOption(false);
        UIManager.Instance.ActiveMenuPanel(true);
    }
    public void OnNextButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        UIManager.Instance.Option.ActivePulsePanel(false);
        UIManager.Instance.Option.ActiveBoltPanel(true);
    }
    public void OnPreviousButton() 
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        UIManager.Instance.Option.ActivePulsePanel(false);
        UIManager.Instance.Option.ActiveSparkPanel(true);
    }
}
