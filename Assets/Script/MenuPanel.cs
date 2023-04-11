using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        GameManager.Instance.ChangeScene()
    }
}
