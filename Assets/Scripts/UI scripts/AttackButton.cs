using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AttackButton : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator playerAnim;
    private PlayerAttack playerAttack;
    private Button attackButton;

    void Start()
    {
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        attackButton = gameObject.GetComponent<Button>();
        attackButton.onClick.AddListener(AttackAnimation);
    }
    void AttackAnimation(){
        playerAnim.SetBool("Attack",true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
