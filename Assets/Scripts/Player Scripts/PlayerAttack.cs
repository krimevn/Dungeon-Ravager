
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{   
    private Animator playerAnim;
    private Transform attackTransform;
    private LayerMask mobs;
    [SerializeField]
    private float attackRangeX=1.6f;
    [SerializeField]
    private float attackRangeY=1.15f; 
    void Awake()
    {
        playerAnim = transform.GetComponent<Animator>();
        attackTransform = transform.Find(ObjectChilds.AttackPoint).transform;
        Debug.Log(attackTransform);
        mobs = LayerMask.GetMask(MaskHelper.Mobs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack(){
        Collider2D[] colliders =  Physics2D.OverlapBoxAll(attackTransform.position,new Vector2(attackRangeX,attackRangeY),0,mobs);
        foreach(Collider2D collider in colliders){
            collider.GetComponent<Mobs>().GetDamaged(5f);
            Debug.Log(collider.GetComponent<BoxCollider2D>().size);
        }
        playerAnim.SetBool("Attack",false);
    }
    private void OnDrawGizmosSelected()
    {
        if(attackTransform!=null){
            Gizmos.DrawWireCube(attackTransform.position,new Vector2(attackRangeX,attackRangeY));
        }
    }
}
