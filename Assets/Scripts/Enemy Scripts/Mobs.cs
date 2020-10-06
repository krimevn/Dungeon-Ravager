using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobs: MonoBehaviour
{
    // Start is called before the first frame update
    protected Rigidbody2D rb ;
    //-------------Player Varibles--------------
    protected Transform playerPosition;
    protected LayerMask playerMask;
    //---------------------------------
    protected float currentHealth;
    protected float lookDistance =8f;
    protected float MobmoveSpeed;
    protected float sightTimer;
    protected float timeReset;
    protected bool noticePlayer;
    protected Vector3 targetPos;
    protected bool lookRight;
    protected float lastPosX;
    protected Animator mobAnimator;
    //----------Mob info-----------------------
    protected string mobName;

    //-----------Mob attacking varibles-----------
    protected float MobAttackRangeX;
    protected float MobAttackRangeY;
    protected Vector2 attackSize;
    protected Transform attackPoint;
    [SerializeField]
    protected float iniCooldown;
    protected float cooldownReset;
    protected float attackDistance;
    //**********************************************

    //-----------Mob behaviour-------------------
    protected RegionBoundary boundary;
    protected float leftBound;
    protected float rightBound;
    protected bool hitWall;
    protected bool canRun;
    protected bool attackMode;
    [SerializeField]
    protected bool cooldown;
    protected bool isPatrolling;
    protected float xPos;
    protected Vector2 patrolPos;
    protected float distanceToPlayer;
    protected float delay = 1.5f;
    System.Random rndPos = new System.Random();
    //*****************************************
    protected virtual void Start()
    {
        boundary = transform.parent.GetComponent<RegionBoundary>();
        Debug.Log(boundary);
        mobAnimator = transform.GetComponent<Animator>();
        rb = transform.GetComponent<Rigidbody2D>();
        currentHealth = 10f;
        playerPosition =  GameObject.FindGameObjectWithTag(TagHelper.Player).transform;
        playerMask = LayerMask.GetMask(MaskHelper.Player);
        noticePlayer = false;
        timeReset  = 10f;
        lookRight = true;
        lastPosX = transform.position.x;
        #region attack setting
        cooldownReset = iniCooldown;
        attackPoint = transform.Find(ObjectChilds.AttackPoint).transform;
        attackSize = new Vector2(MobAttackRangeX,MobAttackRangeY);
        #endregion
        //----------------
        #region  enemy behaviour
        isPatrolling = false ;
        canRun = true;
        attackMode = false;
        cooldown = false;
        hitWall = false;
        #endregion
        #region patrol setting
        leftBound = transform.parent.Find("LeftBound").transform.position.x;
        rightBound = transform.parent.Find("RightBound").transform.position.x;
        #endregion
        
    }
    protected virtual void Update()
    {
        Look();
        EnemyBehaviour();
    }
    protected virtual void FixedUpdate()
    {

    }
    protected virtual void LateUpdate()
    {
        
    }
    public virtual void GetDamaged(float damaged){
        currentHealth =  currentHealth - damaged;
        Debug.Log(currentHealth);
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    protected virtual void Die(){
        Destroy(gameObject);
    }
    protected virtual void Look(){
        Vector3 direction = transform.TransformDirection(Vector3.right) * lookDistance;
        RaycastHit2D hits = Physics2D.Raycast(transform.position,transform.TransformDirection(Vector3.right),lookDistance,playerMask);
        TextMesh text = transform.GetComponentInChildren<TextMesh>();
        Collider2D player = hits.collider;
        //Flip the enemy
        LookRotation();
        //
        if(player!= null){
            text.text = player.name;
            sightTimer = timeReset;
            noticePlayer = true;
        }
        //check noticePlayer for optimization, if sightTimer only run if the condition are right
        if(player == null && noticePlayer == true){
            sightTimer -= Time.fixedDeltaTime;
            if(sightTimer <= 0){
                sightTimer =0;
                text.text = "";
                noticePlayer = false;
            }
            
        }
    }
    protected void EnemyBehaviour(){
        distanceToPlayer = Vector2.Distance(transform.position,playerPosition.position);
        if(noticePlayer){
            if(lookRight && transform.position.x - playerPosition.position.x > 0 && !mobAnimator.GetCurrentAnimatorStateInfo(0).IsName(mobName+"_Attack")){
                transform.rotation = Quaternion.Euler(0,180,0);
                lookRight = false;
            }
            if(!lookRight && transform.position.x - playerPosition.position.x <0 && !mobAnimator.GetCurrentAnimatorStateInfo(0).IsName(mobName+"_Attack")){
                transform.rotation = Quaternion.Euler(0,0,0);
                lookRight = true;
            }
        }
        if(!noticePlayer&&leftBound!=0&&rightBound!=0){
            Patrol();
        }
        if(distanceToPlayer > attackDistance){
            StopAttack();
            FollowPlayer();
        }
        if(distanceToPlayer <= attackDistance && noticePlayer){
            Attack();
        } 
        if(cooldown){
            AttackCoolingDown();
            mobAnimator.SetBool("Attack",false);
        }
    }
    protected void LookRotation(){
        if(lookRight && (-transform.position.x + lastPosX) > 0.05 && !mobAnimator.GetCurrentAnimatorStateInfo(0).IsName(mobName+"_Attack")){
            transform.rotation = Quaternion.Euler(0,180,0);
            lookRight = false;
        }
        if(!lookRight && (-transform.position.x + lastPosX) < -0.05 && !mobAnimator.GetCurrentAnimatorStateInfo(0).IsName(mobName+"_Attack")){
            transform.rotation = Quaternion.Euler(0,0,0);
            lookRight = true;
        }
        
        lastPosX = transform.position.x;
        
    }
    protected virtual void FollowPlayer(){
        // mobAnimator.SetBool("canMove",true);
        if(!mobAnimator.GetCurrentAnimatorStateInfo(0).IsName(mobName+"_Attack") && noticePlayer){
            
            targetPos = new Vector3(playerPosition.position.x, rb.velocity.y, transform.position.z);
            transform.position += transform.TransformDirection(Vector3.right)*MobmoveSpeed*Time.deltaTime; ;
        }
        //transform.position += transform.TransformDirection(Vector3.right)*MobmoveSpeed*Time.deltaTime;                
    }
    protected virtual void Patrol(){
        if(!isPatrolling){
            isPatrolling = true;
            xPos = 1;
            patrolPos = new Vector2(rightBound,transform.position.y);
        }
        if(isPatrolling&&canRun){
            transform.position += transform.TransformDirection(Vector2.right)*Time.fixedDeltaTime*MobmoveSpeed;
        }
        if(Vector2.Distance(transform.position,patrolPos)>=0&&Vector2.Distance(transform.position,patrolPos)<=0.01){
        }
    }
    protected virtual void newDestinationPatrol(){
        
    }
    #region setting up attacking
    protected virtual void Attack(){
        // Collider2D collider = Physics2D.BoxCast(attackPoint.position, )
        
        attackMode = true;
        canRun = false;
        mobAnimator.SetBool("canMove",false);
        mobAnimator.SetBool("Attack",true);
    }
    protected virtual void AttackCoolingDown(){
        iniCooldown -= Time.fixedDeltaTime;
        if(iniCooldown <= 0 && attackMode){
            cooldown = false;
            iniCooldown = cooldownReset;
        }
    }
    protected virtual void CooldownTrigger(){
        cooldown = true;
    }
    protected virtual void StopAttack(){
        iniCooldown = cooldownReset;
        attackMode = false;
        cooldown = false;
        mobAnimator.SetBool("Attack",false);
    }
    #endregion
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boundary"&&!noticePlayer){
            transform.right = transform.right * -1;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Vector3 direction = transform.TransformDirection(Vector3.right) * lookDistance;
        Gizmos.DrawRay(transform.position,direction);
        if(attackPoint!=null){
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(attackPoint.position,new Vector2(MobAttackRangeX,MobAttackRangeY));
        }
    }
    
}
