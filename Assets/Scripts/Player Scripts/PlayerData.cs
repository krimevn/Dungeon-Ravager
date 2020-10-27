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
    public int gem;
    //Constructor for creating a new save
    public PlayerData(){
        playerMaxHealth = playerMaxHealthDefault;
        playerAttack = playerAttackDefault;
        gem = 15;
        treasury = 1000;
    }
    public PlayerData(bool initial){
        playerMaxHealth = Player.playerMaxHealth;
        playerAttack = Player.playerAttack;
        treasury = Player.treasury;
        gem = Player.gem;
    }

    
}
