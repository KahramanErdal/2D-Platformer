using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public HealthUI healthUI;

    public Transform respawnPoint; 

    private SpriteRenderer spriteRenderer;

    [SerializeField] private AudioSource hurtEffect;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthUI.SetMaxHearts(maxHealth);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy)
        {
            TakeDamage(enemy.damage);
        }
        Trap trap = collision.GetComponent<Trap>();
        if (trap && trap.damage >0)
        {
            TakeDamage(trap.damage);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthUI.UpdateHearts(currentHealth);

        StartCoroutine(FlashRed());
        hurtEffect.Play();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        StartCoroutine(RespawnAfterDelay(2.0f)); 
    }

    private IEnumerator RespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(0f);

        Respawn();
    }

    private void Respawn()
    {
        // Reset health and update UI
        currentHealth = maxHealth;
        healthUI.UpdateHearts(currentHealth);

        transform.position = respawnPoint.position;
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }
}
