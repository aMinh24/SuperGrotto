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
    private void Start()
    {
        ActiveVictoryPanel(false);
        ActiveMenuPanel(true);
        ActiveLosePanel(false);
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
}
