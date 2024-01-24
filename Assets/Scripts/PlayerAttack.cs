using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject fireBallPrefab;
    public float fireSpeed = 50f;
    public float cooldownTime = 1.5f; 
    private float nextFireTime;
    // Update is called once per frame
    [SerializeField] private AudioSource fireBallEffect;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime)
        {
            Shoot();  
            fireBallEffect.Play();
        }
    }

    private void Shoot()
    {        

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 shootDirection = new Vector2(mousePosition.x - transform.position.x, 0).normalized;

        // Instantiate the fireball
        GameObject fireball = Instantiate(fireBallPrefab, transform.position, Quaternion.identity);

        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;

        fireball.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Flip the fireball sprite if needed
        SpriteRenderer fireballSpriteRenderer = fireball.GetComponent<SpriteRenderer>();
        if (shootDirection.x < 0)
        {
            fireballSpriteRenderer.flipY = true;
        }
        else
        {
            fireballSpriteRenderer.flipY = false;
        }

        // Move the fireball forward in the direction of the mouse
        fireball.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x, shootDirection.y) * fireSpeed;

        Destroy(fireball, 0.6f);
        // Set the next fire time based on cooldown
        nextFireTime = Time.time + cooldownTime;
    }

}
