using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI saphire;
    [SerializeField]
    private ButtonMenu buttonMenu;
    public ButtonMenu ButtonMenu => buttonMenu;

    [SerializeField]
    private ButtonStart buttonStart;
    public ButtonStart ButtonStart => buttonStart;
    

    private void Awake()
    {
        ActiveButtonMenu(true);
        ActiveButtonStart(false);
        DataManager.Instance.Init();
    }

    private void OnEnable()
    {
        ActiveButtonMenu(true);
        ActiveButtonStart(false);
        loadData();
    }
    public void OnOptionButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        UIManager.Instance.ActiveMenuPanel(false);
        UIManager.Instance.ActiveOption(true);
    }    
    public void OnTutorialButton()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
        }
        UIManager.Instance.ActiveMenuPanel(false);
        UIManager.Instance.ActiveTutorial(true);
    }
    public void ActiveButtonMenu(bool active)
    {
        ButtonMenu.gameObject.SetActive(active);
    }
    public void ActiveButtonStart(bool active)
    {
        ButtonStart.gameObject.SetActive(active);
    }
    //public void OnStartButtonClick()
    //{
    //    if (AudioManager.HasInstance)
    //    {
    //        AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
    //    }
    //    GameManager.Instance.StartGame();
    //    UIManager.Instance.ActiveMenuPanel(false);
    //    UIManager.Instance.ActiveGamePanel(true);
    //    GameManager.Instance.ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}
    //public void OnSettingButtonClick()
    //{
    //    if (AudioManager.HasInstance)
    //    {
    //        AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
    //    }
    //    UIManager.Instance.ActiveSettingPanel(true);
    //}    
    //public void OnExitButtonClick()
    //{
    //    if (AudioManager.HasInstance)
    //    {
    //        AudioManager.Instance.PlaySE(Audio.SE_CHOOSE);
    //    }
    //    GameManager.Instance.EndGame();
    //}
    private void loadData()
    {
        saphire.SetText(DataManager.Instance.PlayerData.saphire.ToString());
    }
}
