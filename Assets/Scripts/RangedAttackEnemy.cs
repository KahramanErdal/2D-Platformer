using System.Collections;
using UnityEngine;

public class RangedAttackEnemy : MonoBehaviour
{
    public Transform player; // Oyuncu objesinin referansý
    public float attackRange = 5f; // Saldýrý menzili
    public float attackCooldown = 2f; // Saldýrý aralýðý
    public GameObject projectilePrefab; // Ateþ topu prefab'ý
    public Transform firePoint; // Ateþ topu çýkýþ noktasý
    public Vector2 fireDirection = Vector2.right;

    private bool canAttack = true;

    void Update()
    {
        // Oyuncu düþmanýn saldýrý menziline girdiyse ve saldýrý aralýðý geçtiyse saldýrý yap
        if (Vector2.Distance(transform.position, player.position) < attackRange && canAttack)
        {
            StartCoroutine(PerformRangedAttack());
        }
    }

    IEnumerator PerformRangedAttack()
    {
        canAttack = false;

        // Ateþ topu oluþtur ve ateþle
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Ateþ topuna ateþ yönünü belirle
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        projectileScript.SetDirection(fireDirection);

        // Ateþ topuna ömür ver
        Destroy(projectile, projectileScript.lifetime);

        // Saldýrý aralýðýný bekle
        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
    }
}
