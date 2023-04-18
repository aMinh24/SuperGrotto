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
    private void Start()
    {
        ActiveVictoryPanel(false);
        ActiveMenuPanel(true);
        ActiveLosePanel(false);
        ActiveGamePanel(false);
        ActivePausePanel(false);
    }
    private void Update()
    {
        if (GameManager.Instance.IsPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("pause");
                GameManager.Instance.PauseGame();
                ActivePausePanel(true);
            }
        }
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

