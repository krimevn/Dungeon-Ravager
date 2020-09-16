using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobs: MonoBehaviour
{
    // Start is called before the first frame update
    protected float currentHealth;
    protected virtual void Start()
    {
        currentHealth = 10f;
    }
    public virtual void GetDamaged(float damaged){
        currentHealth =  currentHealth - damaged;
        Debug.Log(currentHealth);
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die(){
        Destroy(gameObject);
    }

    private void Update()
    {
        
    }
}
