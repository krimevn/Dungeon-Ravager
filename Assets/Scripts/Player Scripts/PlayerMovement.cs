using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed =5;
    private Joystick joystick;
    private Rigidbody2D rb;
    private Vector2 target;
    [SerializeField]
    private bool faceRight;

    
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

    
    
}
