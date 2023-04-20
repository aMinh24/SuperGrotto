using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject boots;
    [SerializeField]
    private GameObject helmet;
    [SerializeField]
    private TextMeshProUGUI saphie;
    private void Start()
    {
        ActiveBoots(false);
        ActiveHelmet(false);
        DataManager.Instance.Init();
        loadData();
    }
    public void ActiveBoots(bool active)
    {
        boots.SetActive(active);
    }
    public void ActiveHelmet(bool active)
    {
        helmet.SetActive(active);
    }
    public void loadData()
    {
        saphie.SetText(DataManager.Instance.PlayerData.saphie.ToString());
        DataManager.Instance.SavePlayerData();
    }    
}
