using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIncrease : MonoBehaviour
{
    public Button healthIncrease;
    void Start()
    {
        healthIncrease = transform.GetComponent<Button>();
        healthIncrease.onClick.AddListener(IncreasHealth);
    }

    public void IncreasHealth(){
        Player.playerMaxHealth += 50f;
    }
}
