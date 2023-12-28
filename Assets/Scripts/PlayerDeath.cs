using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public Transform respawnPoint;

    void Update()
    {
        // Karakter y�ksekli�i belirli bir de�erin alt�na d��t���nde �l�m� tetikle
        if (transform.position.y < -10f)
        {
            Die();
        }
    }

    void Die()
    {
        // �l�mde kullan�c�y� yeniden do�ma noktas�na ta��
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
