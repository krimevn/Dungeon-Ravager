using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlob : Blob
{

    // Start is called before the first frame update
        [SerializeField]
        private float health = 60f;
        [SerializeField]
        private float moveSpeed = 4f;
        protected override void Start()
    {
        base.Start();
        base.currentHealth = health;
        base.MobmoveSpeed = moveSpeed;
    }
    // Update is called once per frame


}
