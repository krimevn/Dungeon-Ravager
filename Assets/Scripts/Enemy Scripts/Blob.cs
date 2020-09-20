using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : Mobs
{
    // Start is called before the first frame update [SerializeField]
    protected float blobAttackRangeX=0.85f;
    protected float blobAttackRangeY=1f;
    protected float blobAttackTimer = 1.5f;
    protected float blobAttackDistance=1.3f;
    protected override void Start()
    {
        base.Start();
        base.attackSize = new Vector2(blobAttackRangeX,blobAttackRangeY);
        base.attackReset = blobAttackTimer;
        base.attackDistance = blobAttackDistance;
    }
    protected override void Update()
    {
        base.Update();
        
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    protected override void Look()
    {
        base.Look(); 
    }
    public override void GetDamaged(float damaged){
        base.GetDamaged(damaged);
    }
}
