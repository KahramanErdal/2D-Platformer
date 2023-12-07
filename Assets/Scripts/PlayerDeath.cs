using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public Transform respawnPoint; // Yeniden do�ma noktas�

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

        // �sterseniz ba�ka �l�m animasyonlar�, ses efektleri veya oyun durumunu s�f�rlama i�lemleri ekleyebilirsiniz.
    }

    // Karakterin ba�ka bir nesne ile temas etmesi durumunu kontrol etmek i�in OnCollisionEnter2D kullan�labilir
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            Die();
        }
    }
}
