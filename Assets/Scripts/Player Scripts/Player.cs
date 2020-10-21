using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public float playerMaxHealth;
    [SerializeField]
    public float playerLevel;
    [SerializeField]
    public float playerExperience;
    [SerializeField]
    public float playerAttack;
    [SerializeField]
    private float playerCurrentHealth;
    [SerializeField]
    public float treasury;
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getDamaged(float damage){
        playerCurrentHealth -= damage;
    }
}
