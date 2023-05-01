using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ResetPlayerData : MonoBehaviour
{
    public DataSO PlayerData;
    private string dataFilePath;
    public void ResetData()
    {
        PlayerData = new DataSO();
        dataFilePath = Application.persistentDataPath + "/playerdata.json";
        PlayerData.saphire = 0;
        PlayerData.sceneIndex = 1;
        PlayerData.skillName = SKILLCONST.SPARK;
        string toJson = JsonUtility.ToJson(PlayerData);
        if (!File.Exists(dataFilePath))
        {
            File.Create(dataFilePath);
        }
        File.WriteAllText(dataFilePath, toJson);
    }    
}
