using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    // Start is called before the first frame update
    protected Transform playerTransform;
    [SerializeField]
    protected Vector3 playerPosition;
    [SerializeField]
    protected float smoothMovement = 0.05f;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag(TagHelper.Player).GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowingPlayer();
    }
    void FollowingPlayer(){
        transform.position = Vector3.Lerp(transform.position,new Vector3(playerTransform.position.x,playerTransform.position.y,transform.position.z),smoothMovement);
    }
}
