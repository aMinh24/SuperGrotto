using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class DataManager : BaseManager <DataManager>
{
    public TextMeshProUGUI txt;
    private int saphire = 0;
    public int Saphire => saphire;
    public DataSO PlayerData;
    private string dataFilePath;
    
    public void Init()
    {
        dataFilePath = Application.dataPath + "/Data/playerdata.json";
        Debug.Log(dataFilePath);
        this.LoadPlayerData();

    }
    private void WritePlayerDataSO()
    {
        Debug.Log("1");
        PlayerData.saphire+=saphire;

        Debug.Log("2");
        string toJson = JsonUtility.ToJson(PlayerData); txt.SetText("3");
        Debug.Log("3");

        File.WriteAllText(dataFilePath, toJson);
        Debug.Log("4");


    }
    private string ReadPlayerDataSO()
    {
        if (File.Exists(dataFilePath))
        {
            return File.ReadAllText(dataFilePath);
        }
        return null;
    }
    public void LoadPlayerData()
    {
        string fromJson = ReadPlayerDataSO();
        if (fromJson == null)
        {
            WritePlayerDataSO();
            fromJson = ReadPlayerDataSO();
        }
        JsonUtility.FromJsonOverwrite(fromJson, PlayerData);
    }
    public void SavePlayerData()
    {
        WritePlayerDataSO();
    }
    public void updateSaphire()
    {
        txt.SetText(dataFilePath);
        saphire++;
    }
    public void resetSaphire()
    {
        saphire = 0;
    }
}
