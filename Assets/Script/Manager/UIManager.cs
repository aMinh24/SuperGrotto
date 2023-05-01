using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : BaseManager <UIManager>
{
    [SerializeField]
    private MenuPanel menuPanel;
    public MenuPanel MenuPanel=>menuPanel;
    [SerializeField]
    private LosePanel losePanel;
    public LosePanel LosePanel =>LosePanel;
    [SerializeField]
    private VictoryPanel victoryPanel;
    public VictoryPanel VictoryPanel=>victoryPanel;

    [SerializeField]
    private GamePanel gamePanel;
    public GamePanel GamePanel =>gamePanel;
    [SerializeField]
    private PausePanel pausePanel;
    public PausePanel PausePanel =>pausePanel;
    [SerializeField]
    private SettingPanel settingPanel;
    public SettingPanel SettingPanel =>settingPanel;

    [SerializeField]
    private Tutorial tutorial;
    public Tutorial Tutorial => tutorial;

    [SerializeField]
    private Option option;
    public Option Option => option;
    private void Start()
    {
        ActiveVictoryPanel(false);
        ActiveMenuPanel(true);
        ActiveLosePanel(false);
        ActiveGamePanel(false);
        ActivePausePanel(false);
        ActiveSettingPanel(false);
        ActiveTutorial(false);
        ActiveOption(false);
    }
    private void Update()
    {
        if (GameManager.Instance.IsPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.Instance.PauseGame();
                ActivePausePanel(true);
            }
        }
    }
    public void ActiveOption(bool active)
    {
        option.gameObject.SetActive(active);
    }
    public void ActiveTutorial(bool active)
    {
        tutorial.gameObject.SetActive(active);
    }
    public void ActiveSettingPanel(bool active)
    {
        settingPanel.gameObject.SetActive(active);
    }
    public void ActiveVictoryPanel(bool active)
    {

        victoryPanel.gameObject.SetActive(active);
    }
    public void ActiveMenuPanel(bool active)
    {
        menuPanel.gameObject.SetActive(active);
    }
    public void ActiveLosePanel(bool active)
    {
        losePanel.gameObject.SetActive(active);
    }
    public void ActiveGamePanel(bool active)
    {
        gamePanel.gameObject.SetActive(active);
    }
    public void ActivePausePanel(bool active)
    {
        pausePanel.gameObject.SetActive(active);
    }
}

