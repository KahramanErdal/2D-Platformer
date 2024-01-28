using System.Collections;
using UnityEngine;

public class RangedAttackEnemy : MonoBehaviour
{
    public Transform player; 
    public float attackRange = 5f;
    public float attackCooldown = 2f; 
    public GameObject projectilePrefab; 
    public Transform firePoint; 
    public Vector2 fireDirection = Vector2.right;

    private bool canAttack = true;

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < attackRange && canAttack)
        {
            StartCoroutine(PerformRangedAttack());
        }
    }

    IEnumerator PerformRangedAttack()
    {
        canAttack = false;

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        Projectile projectileScript = projectile.GetComponent<Projectile>();
        projectileScript.SetDirection(fireDirection);

        Destroy(projectile, projectileScript.lifetime);

        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
    }
}
