using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlob : Mobs
{
    // Start is called before the first frame update
    private float health = 100f;
    protected override void Start()
    {
        base.Start();
        base.currentHealth = health;
    }
    public override void GetDamaged(float damaged){
        base.GetDamaged(damaged);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
