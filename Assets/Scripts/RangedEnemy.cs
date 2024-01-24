using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public int maxHealth = 3;
    private int currentHealth;
    private SpriteRenderer spriteRenderer;
    private Color ogColor;
    public int damage = 1;

    [SerializeField] private AudioSource enemydamageEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        ogColor = spriteRenderer.color;
    }

    public void TakeRangeDamage(int damage)
    {
        enemydamageEffect.Play();
        currentHealth -= damage;
        StartCoroutine(FlashWhite());
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private IEnumerator FlashWhite()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = ogColor;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
