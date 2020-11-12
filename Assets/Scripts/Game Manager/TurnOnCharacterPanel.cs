using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOnCharacterPanel : MonoBehaviour
{
    public GameObject UIhome;
    public GameObject characterPanel;
    public Button character;
    void Start()
    {
        UIhome = GameObject.FindGameObjectWithTag("UIHome");
        characterPanel = UIhome.transform.Find("Character Panel").gameObject;
        character = transform.GetComponent<Button>();
        character.onClick.AddListener(TurnOnCharacterPanelInfo);
    }
    public void TurnOnCharacterPanelInfo(){
        characterPanel.SetActive(true);
    }
    
}
