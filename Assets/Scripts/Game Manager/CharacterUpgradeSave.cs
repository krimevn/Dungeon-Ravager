using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUpgradeSave : MonoBehaviour
{
    public GameObject UIhome;
    public GameObject characterPanel;
    void Start()
    {
        UIhome = GameObject.FindGameObjectWithTag("UIHome");
        characterPanel = UIhome.transform.Find("Character Panel").gameObject;
    }

    // Update is called once per frame
    public void TurnOffCharacterPanel(){
        characterPanel.SetActive(false);
    }
}
