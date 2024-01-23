using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int fireBallDamage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            RangedEnemy rangedenemy = collision.gameObject.GetComponent<RangedEnemy>();  
            enemy.TakeDamage(fireBallDamage);
            Destroy(gameObject);
        }
    }
    
}
