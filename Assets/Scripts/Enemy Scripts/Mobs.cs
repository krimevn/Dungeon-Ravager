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
    protected bool canRun;
    protected bool attackMode;
    [SerializeField]
    protected bool cooldown;
    protected bool patrolMode;
    protected float distanceToPlayer;
    //*****************************************
    protected virtual void Start()
    {
        mobAnimator = transform.GetComponent<Animator>();
        rb = transform.GetComponent<Rigidbody2D>();
        currentHealth = 10f;
        playerPosition =  GameObject.FindGameObjectWithTag(TagHelper.Player).transform;
        playerMask = LayerMask.GetMask(MaskHelper.Player);
        noticePlayer = false;
        timeReset  = 2.5f;
        lookRight = true;
        lastPosX = transform.position.x;
        #region attack setting
        cooldownReset = iniCooldown;
        attackPoint = transform.Find(ObjectChilds.AttackPoint).transform;
        attackSize = new Vector2(MobAttackRangeX,MobAttackRangeY);
        #endregion
        //----------------
        #region  enemy behaviour
        patrolMode = true;
        canRun = true;
        attackMode = false;
        cooldown = false;
        #endregion
        
    }
    protected virtual void Update()
    {
        
    }
    protected virtual void FixedUpdate()
    {
        Look();
        EnemyBehaviour();
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
        if(distanceToPlayer > attackDistance){
            StopAttack();
            FollowPlayer();
        }
        if(distanceToPlayer <= attackDistance){
            Attack();
        } 
        if(cooldown){
            AttackCoolingDown();
            mobAnimator.SetBool("Attack",false);
        }
    }
    protected void LookRotation(){
        if(lookRight && (transform.position.x - playerPosition.position.x) > 0 && !mobAnimator.GetCurrentAnimatorStateInfo(0).IsName(mobName+"_Attack")){
            transform.rotation = Quaternion.Euler(0,180,0);
            lookRight = false;
        }
        if(!lookRight && (transform.position.x - playerPosition.position.x) < 0 && !mobAnimator.GetCurrentAnimatorStateInfo(0).IsName(mobName+"_Attack")){
            transform.rotation = Quaternion.Euler(0,0,0);
            lookRight = true;
        }
        
        // lastPosX = transform.position.x;
        
    }
    protected virtual void FollowPlayer(){
        // mobAnimator.SetBool("canMove",true);
        Debug.Log(mobAnimator.GetCurrentAnimatorStateInfo(0).IsName(mobName+"_Attack"));
        if(!mobAnimator.GetCurrentAnimatorStateInfo(0).IsName(mobName+"_Attack") && noticePlayer){
            targetPos = new Vector3(playerPosition.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.fixedDeltaTime* MobmoveSpeed);
        }
        //transform.position += transform.TransformDirection(Vector3.right)*MobmoveSpeed*Time.deltaTime;                
    }
    protected virtual void Patrol(){

    }
    #region setting up attacking part
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
    private void OnDrawGizmosSelected()
    {
        Vector3 direction = transform.TransformDirection(Vector3.right) * lookDistance;
        Gizmos.DrawRay(transform.position,direction);
        if(attackPoint!=null){
            Gizmos.DrawWireCube(attackPoint.position,new Vector2(MobAttackRangeX,MobAttackRangeY));
        }
    }
    
}
