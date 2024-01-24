using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 2f;
    public float jumpForce = 2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool shouldJump;

    public int maxHealth = 3;
    private int currentHealth;
    private SpriteRenderer spriteRenderer;
    private Color ogColor;

    public int damage = 1;

    [SerializeField] private AudioSource enemydamageEffect;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        ogColor = spriteRenderer.color;
    }

    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Set a threshold distance to start chasing the player
        float chaseThreshold = 10f;

        if (distanceToPlayer <= chaseThreshold)
        {
            float direction = Mathf.Sign(player.position.x - transform.position.x);
            bool isPlayerAbove = Physics2D.Raycast(transform.position, Vector2.up, 5f, 1 << player.gameObject.layer);

            if (isGrounded)
            {
                rb.velocity = new Vector2(direction * chaseSpeed, rb.velocity.y);

                RaycastHit2D groundInFront = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 2f, groundLayer);

                RaycastHit2D gapAhead = Physics2D.Raycast(transform.position + new Vector3(direction, 0, 0), Vector2.down, 2f, groundLayer);

                RaycastHit2D platformAbove = Physics2D.Raycast(transform.position, Vector2.up, 3f, groundLayer);

                if (!groundInFront.collider && !gapAhead.collider)
                {
                    shouldJump = true;
                }
                else if (isPlayerAbove && platformAbove.collider)
                {
                    shouldJump = true;
                }
            }
        }
    }


    void FixedUpdate()
    {
        if (isGrounded && shouldJump)
        {
            shouldJump = false;
            Vector2 direction = (player.position - transform.position).normalized;

            Vector2 jumpDirection = direction * jumpForce;

            rb.AddForce(new Vector2(jumpDirection.x, jumpForce), ForceMode2D.Impulse);
        }
    }

    public void TakeDamage(int damage)
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
