using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
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
    private bool isGround;  
    private Transform standPoint;
    [SerializeField]
    private LayerMask ground;
    [SerializeField]
    private float heightCheck = 0.4f;

    
    // Start is called before the first frame update
    void Awake()
    {
        joystick = GameObject.FindWithTag(TagHelper.FixedJoyStick).GetComponent<FixedJoystick>();
        standPoint = transform.Find(ObjectChilds.StandPoint).transform;
        rb = transform.GetComponent<Rigidbody2D>();
        ground = LayerMask.GetMask(MaskHelper.Ground);
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
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        if(!faceRight && x >0){
            faceRight = true;
            transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
    public void Jumping(){

        if(isGround){
            rb.velocity = Vector2.up * jumpForce; 
        }
    }
    private void OnDrawGizmosSelected()
    {   
        if(standPoint != null){
            Gizmos.DrawWireCube(standPoint.position,new Vector2(0.5f,heightCheck));
        }

    }

    
    
}

