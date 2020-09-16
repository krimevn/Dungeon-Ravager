using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerAttack playerAttack;
    private Button attackButton;

    void Start()
    {
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
        attackButton = gameObject.GetComponent<Button>();
        attackButton.onClick.AddListener(playerAttack.Attack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
