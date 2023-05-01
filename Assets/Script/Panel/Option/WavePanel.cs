using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePanel : MonoBehaviour
{
    public void OnUseButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        DataManager.Instance.PlayerData.skillName = SKILLCONST.WAVE;
        UIManager.Instance.ActiveOption(false);
        UIManager.Instance.ActiveMenuPanel(true);
    }
    public void OnPreviousButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        UIManager.Instance.Option.ActiveWavePanel(false);
        UIManager.Instance.Option.ActiveBoltPanel(true);
    }
}
