using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    public void OnReplayButton()
    {
        GameManager.Instance.Replay();
    }
}
