using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public Transform respawnPoint;

    void Update()
    {     
        if (transform.position.y < -10f)
        {
            Die();
        }
    }

    void Die()
    {      
        transform.position = respawnPoint.position;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            Die();
        }
    }
}
