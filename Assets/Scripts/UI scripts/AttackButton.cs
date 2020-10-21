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
    private float lastClickTime;
    [SerializeField]
    private float comboRangeAllow = 1.2f;
    public int noOfPush;
    public int clampValue=1;

    void Start()
    {
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        attackButton = gameObject.GetComponent<Button>();
        attackButton.onClick.AddListener(pushInput);
    }
    void AttackAnimation(){
        playerAnim.SetBool("Attack",true);
    }
    void pushInput(){
        lastClickTime = Time.time;
        noOfPush++;
        noOfPush = Mathf.Clamp(noOfPush,noOfPush,clampValue);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time-lastClickTime>comboRangeAllow){
            noOfPush = 0;
        }
        
    }
}
