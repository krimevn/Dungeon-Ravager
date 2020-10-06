using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionBoundary : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public float leftBound;
    [SerializeField]
    public float RightBound;

    void Awake()
    {
        leftBound = transform.Find("LeftBound").transform.position.x;
        RightBound = transform.Find("RightBound").transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(new Vector2(leftBound,transform.position.y),Vector2.up*5);
        Gizmos.DrawRay(new Vector2(leftBound,transform.position.y),Vector2.down*5);
        Gizmos.DrawRay(new Vector2(RightBound,transform.position.y),Vector2.up*5);
        Gizmos.DrawRay(new Vector2(RightBound,transform.position.y),Vector2.down*5);        
    }
}
