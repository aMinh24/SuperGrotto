using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown) 
        {
            if (AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
            }
            UIManager.Instance.ActiveTutorial(false);
            UIManager.Instance.ActiveMenuPanel(true);
        }
    }
}
