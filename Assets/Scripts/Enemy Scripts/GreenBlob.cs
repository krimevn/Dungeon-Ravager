using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBlob : Blob
{
    // Start is called before the first frame update
    [SerializeField]
    private float health = 15f;
    [SerializeField]
    private float moveSpeed = 3f;
    private Vector3 itemDropPos;
    private Vector2 explodeDir;
    protected override void Start()
    {
        base.Start();
        base.currentHealth = health;
        base.MobmoveSpeed =moveSpeed;
        
    }
    protected override void Update()
    {
        base.Update();
        itemDropPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
    }
    protected override void DropTreasure(){
        for(int i=0;i<10;i++){
            explodeDir = new Vector2(Random.Range(-5,5),Random.Range(0,5));
            GameObject obj = Instantiate(base.coinPreb,itemDropPos,Quaternion.identity);
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            rb.AddForce(explodeDir*50);

        }
        for(int i=0;i<3;i++){
            explodeDir = new Vector2(Random.Range(-5,5),Random.Range(0,5));
            GameObject obj = Instantiate(base.gemPreb,itemDropPos,Quaternion.identity);
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            rb.AddForce(explodeDir*50);
        }
        
    }
    

}
