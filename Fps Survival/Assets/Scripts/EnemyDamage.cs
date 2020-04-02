using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float health = 100f;
    public void TakeDamage(float hit)
    { 
        if(health >= 0)
        {
            health -= hit;
        }
        else
        {
            Die();
        }
    }
    void Die()
    {

        Destroy(gameObject);
    }
}
