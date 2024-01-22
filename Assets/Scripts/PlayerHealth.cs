using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public HealthUI healthUI;

    public Transform respawnPoint; // Set this in the inspector to the desired respawn point

    private SpriteRenderer spriteRenderer;

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
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthUI.UpdateHearts(currentHealth);

        StartCoroutine(FlashRed());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Perform any death-related logic (e.g., play death animation, show game over screen)

        // Respawn after a delay
        StartCoroutine(RespawnAfterDelay(2.0f)); // Adjust the delay as needed
    }

    private IEnumerator RespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(0f);

        // Respawn at the checkpoint or respawn point
        Respawn();
    }

    private void Respawn()
    {
        // Reset health and update UI
        currentHealth = maxHealth;
        healthUI.UpdateHearts(currentHealth);

        // Move the player to the respawn point
        transform.position = respawnPoint.position;

        // Additional respawn logic can be added here
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }
}
