using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBlob : Blob
{
    // Start is called before the first frame update
    [SerializeField]
    private float health = 50f;
    [SerializeField]
    private float moveSpeed = 3f;
    protected override void Start()
    {
        base.Start();
        base.currentHealth = health;
        base.MobmoveSpeed =moveSpeed;
    }

}
