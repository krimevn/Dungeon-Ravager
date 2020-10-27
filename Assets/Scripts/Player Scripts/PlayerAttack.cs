
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{   
    private Animator playerAnim;
    private PlayerMovement playerMovement;
    private Transform attackTransform;
    private LayerMask mobs;
    [SerializeField]
    private float attackRangeX=1.6f;
    [SerializeField]
    private float attackRangeY=1.15f;
    private AttackButton attackButton;
    private bool attackTrigger2;
    private bool attackTrigger3; 
    void Awake()
    {
        playerAnim = transform.GetComponent<Animator>();
        attackTransform = transform.Find(ObjectChilds.AttackPoint).transform;
        mobs = LayerMask.GetMask(MaskHelper.Mobs);
        playerMovement = transform.GetComponent<PlayerMovement>();
        attackButton = GameObject.FindGameObjectWithTag("AttackButton").GetComponent<AttackButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.isGround){
            playerAnim.SetBool("FlyAttack",false);
        }
        if(attackButton.noOfPush==1&&playerMovement.isGround){
            playerAnim.SetBool("Attack1",true);
        }
        if(attackButton.noOfPush==1&&!playerMovement.isGround){
            playerAnim.SetBool("FlyAttack",true);
        }
    }
    public void Attack(){
        Collider2D[] colliders =  Physics2D.OverlapBoxAll(attackTransform.position,new Vector2(attackRangeX,attackRangeY),0,mobs);
        foreach(Collider2D collider in colliders){
            collider.GetComponent<Mobs>().GetDamaged(5f);
            Debug.Log(collider.GetComponent<BoxCollider2D>().size);
        }
    }
    public void ReturnAttack1(){
        if(attackButton.noOfPush >=2){
            playerAnim.SetBool("Attack2",true);
        }else{
            playerAnim.SetBool("Attack1",false);
            attackButton.noOfPush = 0;
        }
    }
    public void ReturnAttack2(){
        if(attackButton.noOfPush >=3){
            playerAnim.SetBool("Attack3",true);
        }else{
            playerAnim.SetBool("Attack2",false);
            playerAnim.SetBool("Attack1",false);
            attackButton.noOfPush = 0;
        }
    }
    public void ReturnAttack3(){
        playerAnim.SetBool("Attack1",false);
        playerAnim.SetBool("Attack2",false);
        playerAnim.SetBool("Attack3",false);
        attackButton.noOfPush = 0;
    }
    public void ReturnFlyAttack(){
        playerAnim.SetBool("FlyAttack",false);
        attackButton.noOfPush = 0;
    }
    public void clampValue2(){
        attackButton.clampValue = 2;
    }
    public void clampValue3(){
        attackButton.clampValue = 3;
    }

    private void OnDrawGizmosSelected()
    {
        if(attackTransform!=null){
            Gizmos.DrawWireCube(attackTransform.position,new Vector2(attackRangeX,attackRangeY));
        }
    }
}
