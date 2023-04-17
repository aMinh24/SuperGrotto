using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        GameManager.Instance.StartGame();
        UIManager.Instance.ActiveMenuPanel(false);
        UIManager.Instance.ActiveGamePanel(true);
        GameManager.Instance.ChangeScene("Level1");
    }
    public void OnExitButtonClick()
    {
        GameManager.Instance.EndGame();
    }
}
