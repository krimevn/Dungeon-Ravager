using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    
    // Start is called before the first frame update
    private string fileDir = "/SaveFile.txt";
    void Awake()
    {   
        string savePath = Application.dataPath + fileDir;
        if(!File.Exists(savePath)){
            CreateDefaultSave();
        }
    }
    public void CreateDefaultSave(){
        PlayerData newData = new PlayerData();
        string json = JsonUtility.ToJson(newData);
        File.WriteAllText(Application.dataPath + fileDir,json);
    }
    public void SavePlayer(){
        PlayerData playerData = new PlayerData(true);
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.dataPath + fileDir,json);
        
    }
    public void LoadPlayer(){
        string data = File.ReadAllText(Application.dataPath+fileDir);
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(data);
        #region  loadPlayerData
        Player.playerMaxHealth = playerData.playerMaxHealth;
        Player.playerAttack = playerData.playerAttack;
        Player.treasury  = playerData.treasury;
        Player.gem = playerData.gem;
        #endregion
    }

    // Update is called once per frame
    
}
