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
    [SerializeField]
    private TextMeshProUGUI energy;
    [SerializeField]
    private TextMeshProUGUI scale;
    private void Start()
    {
        DataManager.Instance.Init();
    }
    private void OnEnable()
    {
        DataManager.Instance.resetSaphire();
        resetGamePanel();
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
    public void resetGamePanel()
    {
        ActiveBoots(false);
        ActiveHelmet(false);
        saphie.SetText("0");
        energy.SetText("0");

    }
    public void loadData()
    {
        saphie.SetText(DataManager.Instance.Saphire.ToString());
    }    
    public void updateEnergy(int count)
    {
        energy.SetText(count.ToString());
    }
}
