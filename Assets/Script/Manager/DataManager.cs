using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class DataManager : BaseManager <DataManager>
{
    private int saphire = 0;
    public int Saphire => saphire;
    public DataSO PlayerData;
    private string dataFilePath;
    
    public void Init()
    {
        dataFilePath = Application.persistentDataPath + "/playerdata.json";
        Debug.Log(dataFilePath);
        this.LoadPlayerData();

    }
    private void WritePlayerDataSO()
    {
        PlayerData.saphire+=saphire;
        Debug.Log(PlayerData.saphire);
        string toJson = JsonUtility.ToJson(PlayerData);
        if(!File.Exists(dataFilePath))
        {
            File.Create(dataFilePath);
        }
        File.WriteAllText(dataFilePath, toJson);


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
        saphire++;
    }
    public void resetSaphire()
    {
        saphire = 0;
    }
}
