using System.Collections;
using UnityEngine;

public class RangedAttackEnemy : MonoBehaviour
{
    public Transform player; // Oyuncu objesinin referans�
    public float attackRange = 5f; // Sald�r� menzili
    public float attackCooldown = 2f; // Sald�r� aral���
    public GameObject projectilePrefab; // Ate� topu prefab'�
    public Transform firePoint; // Ate� topu ��k�� noktas�
    public Vector2 fireDirection = Vector2.right;

    private bool canAttack = true;

    void Update()
    {
        // Oyuncu d��man�n sald�r� menziline girdiyse ve sald�r� aral��� ge�tiyse sald�r� yap
        if (Vector2.Distance(transform.position, player.position) < attackRange && canAttack)
        {
            StartCoroutine(PerformRangedAttack());
        }
    }

    IEnumerator PerformRangedAttack()
    {
        canAttack = false;

        // Ate� topu olu�tur ve ate�le
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Ate� topuna ate� y�n�n� belirle
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        projectileScript.SetDirection(fireDirection);

        // Ate� topuna �m�r ver
        Destroy(projectile, projectileScript.lifetime);

        // Sald�r� aral���n� bekle
        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
    }
}
