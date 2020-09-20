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
    [SerializeField]
    protected bool canRun;
    //-----------Mob attacking varibles-----------
    protected float MobAttackRangeX;
    protected float MobAttackRangeY;
    protected Vector2 attackSize;
    protected Transform attackPoint;
    protected float attackTimer;
    protected float attackReset;
    protected float attackDistance;
    //**********************************************
    public mobState state;
    protected virtual void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        currentHealth = 10f;
        playerPosition =  GameObject.FindGameObjectWithTag(TagHelper.Player).transform;
        playerMask = LayerMask.GetMask(MaskHelper.Player);
        noticePlayer = false;
        timeReset  = 2.5f;
        lookRight = true;
        lastPosX = transform.position.x;
        attackReset = attackTimer;
        attackPoint = transform.Find(ObjectChilds.AttackPoint).transform;
        attackSize = new Vector2(MobAttackRangeX,MobAttackRangeY);
        state = mobState.PATROL;
        canRun = true;
    }
    protected virtual void Update()
    {
        
    }
    protected virtual void FixedUpdate()
    {
        Look();
        StateAction();
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
        if(player!= null && state != mobState.ATTACK){
            text.text = player.name;
            sightTimer = timeReset;
            noticePlayer = true;
            state = mobState.CHASE;
        }
        //check noticePlayer for optimization, if sightTimer only run if the condition are right
        if(player == null && noticePlayer == true){
            sightTimer -= Time.fixedDeltaTime;
            if(sightTimer <= 0){
                sightTimer =0;
                text.text = "";
                noticePlayer = false;
                state = mobState.PATROL;
            }
            
        }
    }
    protected void StateAction(){
        if(state == mobState.CHASE){
            FollowPlayer();
        }
        if(state == mobState.ATTACK){
            Attack();
        }
    }
    protected void LookRotation(){
        if(lookRight && (transform.position.x - playerPosition.position.x) > 0){
            transform.rotation = Quaternion.Euler(0,180,0);
            lookRight = false;
        }
        if(!lookRight && (transform.position.x - playerPosition.position.x) < 0){
            transform.rotation = Quaternion.Euler(0,0,0);
            lookRight = true;
        }
        
        // lastPosX = transform.position.x;
        
    }
    protected virtual void FollowPlayer(){

        if(state == mobState.CHASE && Vector2.Distance(transform.position,playerPosition.position) > attackDistance){
            targetPos = new Vector3(playerPosition.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.fixedDeltaTime* MobmoveSpeed);
            //transform.position += transform.TransformDirection(Vector3.right)*MobmoveSpeed*Time.deltaTime;           
        }
        if(Vector2.Distance(transform.position,playerPosition.position) <= attackDistance){
            state = mobState.ATTACK;
            
        }
        
        
    }
    protected virtual void Patrol(){

    }
    protected virtual void Attack(){
        // Collider2D collider = Physics2D.BoxCast(attackPoint.position, )
        attackTimer -= Time.fixedDeltaTime;
        Debug.Log(attackTimer);
        if(attackTimer <= 0){
            attackTimer = attackReset;
            if(Vector2.Distance(transform.position,playerPosition.position) > attackDistance){
                    state = mobState.CHASE;
            }  
        }        
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 direction = transform.TransformDirection(Vector3.right) * lookDistance;
        Gizmos.DrawRay(transform.position,direction);
        if(attackPoint!=null){
            Gizmos.DrawWireCube(attackPoint.position,new Vector2(MobAttackRangeX,MobAttackRangeY));
        }
    }
    
}
