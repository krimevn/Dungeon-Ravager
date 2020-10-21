using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour
{
    public GameObject mobSpawn;
    public float timeReset=0; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timeReset >= 5f ){
            timeReset = Time.time ;
            Spawn();
        }
    }
    void Spawn(){
        
    }
}
