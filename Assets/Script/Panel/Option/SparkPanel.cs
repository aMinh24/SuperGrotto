using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkPanel : MonoBehaviour
{
    public void OnUseButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        DataManager.Instance.PlayerData.skillName = SKILLCONST.SPARK;
        UIManager.Instance.ActiveOption(false);
        UIManager.Instance.ActiveMenuPanel(true);
    }    
    public void OnNextButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        UIManager.Instance.Option.ActivePulsePanel(true);
        UIManager.Instance.Option.ActiveSparkPanel(false);
    }
}
