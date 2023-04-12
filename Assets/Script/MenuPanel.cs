using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        UIManager.Instance.ActiveMenuPanel(false);
        GameManager.Instance.ChangeScene("Level1");
    }
    public void OnExitButtonClick()
    {
        GameManager.Instance.EndGame();
    }
}
