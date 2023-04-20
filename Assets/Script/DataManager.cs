using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : BaseManager <DataManager>
{
    private int saphire = 0;
    public int Saphire => saphire;
    public DataSO PlayerData;
    private string dataFilePath;
    
    public void Init()
    {
        dataFilePath = Application.dataPath + "/Data/playerdata.jason";
        Debug.Log(dataFilePath);
        this.LoadPlayerData();
    }
    private void WritePlayerDataSO()
    {
        PlayerData.saphie+=saphire;
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
    public void updateSaphire()
    {
        saphire++;
    }
    public void resetSaphire()
    {
        saphire = 0;
    }
}
