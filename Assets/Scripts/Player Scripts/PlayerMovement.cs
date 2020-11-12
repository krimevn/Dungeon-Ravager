using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private Animator playerAnim;
    [SerializeField]
    private float moveSpeed =5;
    [SerializeField]
    private float jumpForce =12;
    private Joystick joystick;
    private Rigidbody2D rb;
    private Vector2 target;
    [SerializeField]
    private bool faceRight;
    [SerializeField]
    public bool isGround; 
    public bool moveAble; 
    public bool jumpable;
    private Transform standPoint;
    [SerializeField]
    private LayerMask ground;
    [SerializeField]
    private float heightCheck = 0.4f;

    
    // Start is called before the first frame update
    void Awake()
    {
        playerAnim = transform.GetComponent<Animator>();
        joystick = GameObject.FindWithTag(TagHelper.FixedJoyStick).GetComponent<FixedJoystick>();
        standPoint = transform.Find(ObjectChilds.StandPoint).transform;
        rb = transform.GetComponent<Rigidbody2D>();
        ground = LayerMask.GetMask(MaskHelper.Ground);
        faceRight = true;
        moveAble = true;
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapBox(standPoint.position,new Vector2(0.5f,heightCheck),0,ground);        
    }
    private void FixedUpdate()
    {
        target = new Vector2(joystick.Horizontal,0);
        Flip(joystick.Horizontal);
        if(moveAble){
            Moving();
        }
        if(rb.velocity != Vector2.zero)
        {
            playerAnim.SetBool("Running", true);
        }
        else
        {
            playerAnim.SetBool("Running", false);
        }
    }
    void Moving(){
        
        target.Normalize();
        target = target*moveSpeed;
        rb.velocity =  new Vector2(target.x,rb.velocity.y);
    }
    void Flip(float x){
        if(faceRight && x < 0){
            faceRight = false;
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        if(!faceRight && x >0){
            faceRight = true;
            transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
    public void Jumping(){

        if(isGround&&jumpable){
            rb.velocity = Vector2.up * jumpForce; 
        }
    }
    public void DisableMovement(){
        moveAble = false;
        jumpable =false;
        rb.velocity = Vector2.zero;
        rb.gravityScale=0;
    }
    public void EnableMovement(){
        moveAble = true;
        jumpable = true;
        rb.velocity = Vector2.zero;
        rb.gravityScale=3;
    }
    private void OnDrawGizmosSelected()
    {   
        if(standPoint != null){
            Gizmos.DrawWireCube(standPoint.position,new Vector2(0.5f,heightCheck));
        }

    }

    
    
}

