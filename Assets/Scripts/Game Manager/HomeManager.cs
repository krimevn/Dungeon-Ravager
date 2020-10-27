using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
    public Text goldValue;
    public Text gemValue;
    public Text healthValue;
    public Text attackValue;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UIupdate();
    }
    void UIupdate(){
        goldValue.text = Player.treasury.ToString();
        gemValue.text = Player.gem.ToString();
        healthValue.text = Player.playerMaxHealth.ToString();
        attackValue.text = Player.playerAttack.ToString();
    }
}
