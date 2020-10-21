using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float playerMaxHealthDefault = 100f;
    public float playerAttackDefault = 5f;
    public float playerMaxHealth;
    public float playerLevel;
    public float playerExperience;
    public float playerAttack;
    public float treasury;
    //Constructor for creating a new save
    public PlayerData(){
        playerMaxHealth = playerMaxHealthDefault;
        playerAttack = playerAttackDefault;
        treasury = 1000;
    }
    public PlayerData(Player player){
        playerMaxHealth = player.playerMaxHealth;
        playerAttack = player.playerAttack;
        treasury = player.treasury;
    }

    
}
