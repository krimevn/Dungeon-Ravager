using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    protected float moveSpeed =5;
    [SerializeField]
    protected float jumpForce =12;
    protected Joystick joystick;
    protected Rigidbody2D rb;
    protected Vector2 target;
    [SerializeField]
    protected bool faceRight;
    [SerializeField]
    protected bool isGround;  
    [SerializeField]
    protected Transform standPoint;
    [SerializeField]
    protected LayerMask ground;
    [SerializeField]
    protected float heightCheck = 0.4f;

    
    // Start is called before the first frame update
    void Start()
    {
        joystick = GameObject.FindWithTag(TagHelper.FixedJoyStick).GetComponent<FixedJoystick>();
        rb = transform.GetComponent<Rigidbody2D>();
        faceRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapBox(standPoint.position,new Vector2(0.5f,heightCheck),0,ground);        
    }
    private void FixedUpdate()
    {
        Moving();
    }
    void Moving(){
        target = new Vector2(joystick.Horizontal,0);
        Flip(target.x);
        target.Normalize();
        target = target*moveSpeed;
        rb.velocity =  new Vector2(target.x,rb.velocity.y);
    }
    void Flip(float x){
        if(faceRight && x < 0){
            faceRight = false;
            transform.localScale = new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
        }
        if(!faceRight && x >0){
            faceRight = true;
            transform.localScale = new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
        }
    }
    public void Jumping(){

        if(isGround){
            rb.velocity = Vector2.up * jumpForce; 
        }
    }
    private void OnDrawGizmosSelected()
    {   
        Gizmos.DrawWireCube(standPoint.position,new Vector2(0.4f,heightCheck));
    }

    
    
}

