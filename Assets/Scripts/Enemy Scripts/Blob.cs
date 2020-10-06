using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : Mobs
{
    // Start is called before the first frame update [SerializeField]
    [SerializeField]
    protected float blobAttackRangeX=0.85f;
    [SerializeField]
    protected float blobAttackRangeY=1f;
    protected float blobAttackCooldown = 1.5f;
    protected float blobAttackDistance=1.5f;
    protected string blobName = "Blob";
    protected override void Start()
    {
        base.Start();
        base.attackSize = new Vector2(blobAttackRangeX,blobAttackRangeY);
        base.cooldownReset = blobAttackCooldown;
        base.iniCooldown = blobAttackCooldown;
        base.attackDistance = blobAttackDistance;
        base.mobName = blobName;
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
    private void OnDrawGizmosSelected()
    {
        if(attackPoint!=null){
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(attackPoint.position,base.attackSize);
        }
    }
}
