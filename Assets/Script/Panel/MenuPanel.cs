using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI saphire;

    private void Awake()
    {
        DataManager.Instance.Init();
    }

    private void OnEnable()
    {
        loadData();
    }
    public void OnStartButtonClick()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        GameManager.Instance.StartGame();
        UIManager.Instance.ActiveMenuPanel(false);
        UIManager.Instance.ActiveGamePanel(true);
        GameManager.Instance.ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnSettingButtonClick()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        UIManager.Instance.ActiveSettingPanel(true);
    }    
    public void OnExitButtonClick()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        GameManager.Instance.EndGame();
    }
    private void loadData()
    {
        saphire.SetText(DataManager.Instance.PlayerData.saphire.ToString());
    }
}
