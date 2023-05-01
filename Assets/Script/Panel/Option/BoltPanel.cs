using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltPanel : MonoBehaviour
{
    public void OnUseButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        DataManager.Instance.PlayerData.skillName = SKILLCONST.BOLT;
        UIManager.Instance.ActiveOption(false);
        UIManager.Instance.ActiveMenuPanel(true);
    }
    public void OnNextButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        UIManager.Instance.Option.ActiveWavePanel(true);
        UIManager.Instance.Option.ActiveBoltPanel(false);
    }
    public void OnPreviousButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        UIManager.Instance.Option.ActivePulsePanel(true);
        UIManager.Instance.Option.ActiveBoltPanel(false);
    }
}
