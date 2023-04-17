using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject boots;
    [SerializeField]
    private GameObject helmet;
    private void Start()
    {
        ActiveBoots(false);
        ActiveHelmet(false);
    }
    public void ActiveBoots(bool active)
    {
        boots.SetActive(active);
    }
    public void ActiveHelmet(bool active)
    {
        helmet.SetActive(active);
    }
}
