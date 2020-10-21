using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    
    // Start is called before the first frame update
    private string fileDir = "/SaveFile.txt";
    private Player player;
    void Awake()
    {   
        string savePath = Application.dataPath + fileDir;
        Debug.Log(Application.persistentDataPath);
        player = GameObject.FindGameObjectWithTag(TagHelper.Player).GetComponent<Player>();
        if(!File.Exists(savePath)){
            CreateDefaultSave();
        }
        LoadPlayer();
    }
    public void CreateDefaultSave(){
        PlayerData newData = new PlayerData();
        string json = JsonUtility.ToJson(newData);
        File.WriteAllText(Application.dataPath + fileDir,json);
    }
    public void SavePlayer(){
        PlayerData playerData = new PlayerData(player);
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.dataPath + fileDir,json);
        
    }
    public void LoadPlayer(){
        string data = File.ReadAllText(Application.dataPath+fileDir);
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(data);
        #region  loadPlayerData
        player.playerMaxHealth = playerData.playerMaxHealth;
        player.playerAttack = playerData.playerAttack;
        player.treasury = playerData.treasury;
        #endregion
    }

    // Update is called once per frame
    
}
