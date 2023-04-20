using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI saphire;
    private void OnEnable()
    {
        loadData();
    }
    public void OnStartButtonClick()
    {
        GameManager.Instance.StartGame();
        UIManager.Instance.ActiveMenuPanel(false);
        UIManager.Instance.ActiveGamePanel(true);
        GameManager.Instance.ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnExitButtonClick()
    {
        GameManager.Instance.EndGame();
    }
    private void loadData()
    {
        saphire.SetText(DataManager.Instance.PlayerData.saphie.ToString());
    }
}
