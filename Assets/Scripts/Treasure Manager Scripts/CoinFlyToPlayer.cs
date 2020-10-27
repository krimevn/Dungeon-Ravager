using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFlyToPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Transform goldConsumeZone;
    public bool beingConsume;
    public float velocity;
    private Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(TagHelper.Player).GetComponent<Player>();
        goldConsumeZone = GameObject.FindGameObjectWithTag("GoldConsumeZone").transform;
        beingConsume = false;
        velocity =  0.005f;
    }

    // Update is called once per frame
    void Update()
    {
        if(beingConsume){
            velocity += velocity*Time.deltaTime*3f;
            transform.position = Vector2.MoveTowards(transform.position,goldConsumeZone.position,velocity);
        }
        if(Vector2.Distance(transform.position,goldConsumeZone.position)<0.005f){
            BeConsume();
        }
    }
    public void Consume(){
        beingConsume = true;
    }
    public void BeConsume(){
        if(gameObject.name == "Coin"||gameObject.name=="Coin(Clone)"){
            Player.treasury += 1;
        }
        if(gameObject.name == "Gem"||gameObject.name=="Gem(Clone)"){
            Player.treasury += 5;
        }
        Debug.Log(gameObject.name);
        Destroy(gameObject);
    }

}
