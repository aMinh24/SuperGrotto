using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : BaseManager <DataManager>
{
    
    public DataSO PlayerData;
    private string dataFilePath;
    
    public void Init()
    {
        dataFilePath = Application.persistentDataPath + "playerdata.jason";
        Debug.Log(dataFilePath);
        this.LoadPlayerData();
    }
    private void WritePlayerDataSO()
    {
        string toJson = JsonUtility.ToJson(PlayerData);
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
}
