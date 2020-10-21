using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldConsumeZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Treasury"){
            other.transform.GetComponent<CoinFlyToPlayer>().BeConsume();
            Debug.Log("aanananananana");
        }
    }

}
