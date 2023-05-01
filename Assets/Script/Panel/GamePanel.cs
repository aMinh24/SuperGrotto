using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    private Image cooldownImg;
    [SerializeField]
    private TextMeshProUGUI cooldownText;
    private float timeCooldown =0;
    private Color color;
    private void OnEnable()
    {
        //cooldownImg.sprite = Resources.Load("SKILLIMG/"+DataManager.Instance.PlayerData.skillName) as Sprite;
        cooldownImg.sprite = Resources.Load<Sprite>("SKILLIMG/" + DataManager.Instance.PlayerData.skillName);
        Debug.Log(DataManager.Instance.PlayerData.skillName);
        Debug.Log(cooldownImg.sprite);
        PlayerMovement.skillCooldownDelegate += updateSkillCooldown;
        DataManager.Instance.resetSaphire();
        resetGamePanel();
        loadData();
    }
    private void OnDisable()
    {
        PlayerMovement.skillCooldownDelegate -= updateSkillCooldown;
    }
    private void Update()
    {
        if (timeCooldown > Time.time)
        {
            cooldownText.enabled = true;
            cooldownText.SetText((timeCooldown-Time.time).ToString("F1"));
            color = cooldownImg.color;
            color.a = 0.4f;
            cooldownImg.color = color;
        }
        else
        {
            cooldownText.enabled = false;
            color = cooldownImg.color;
            color.a = 1f;
            cooldownImg.color = color;
        }
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
    private void updateSkillCooldown()
    {
        timeCooldown = Time.time + CONST.SKILL_COOLDOWN;
    }
}
