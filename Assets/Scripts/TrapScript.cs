using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyDamage damageManager = other.gameObject.GetComponent<EnemyDamage>();
            damageManager.Death(); 
        }
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trap Detected");
            PlayerDamage playerManager = other.gameObject.GetComponent<PlayerDamage>();
            playerManager.health = 0;
        }
    }
}
