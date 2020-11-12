using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackIncrease : MonoBehaviour
{
    public Button attackIncrease;
    void Start()
    {
        attackIncrease = transform.GetComponent<Button>();
        attackIncrease.onClick.AddListener(IncreasAttack);
    }

    public void IncreasAttack(){
        Player.playerAttack += 5f;
    }
}
