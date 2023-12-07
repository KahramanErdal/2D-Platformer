using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public Transform respawnPoint; // Yeniden doðma noktasý

    void Update()
    {
        // Karakter yüksekliði belirli bir deðerin altýna düþtüðünde ölümü tetikle
        if (transform.position.y < -10f)
        {
            Die();
        }
    }

    void Die()
    {
        // Ölümde kullanýcýyý yeniden doðma noktasýna taþý
        transform.position = respawnPoint.position;

        // Ýsterseniz baþka ölüm animasyonlarý, ses efektleri veya oyun durumunu sýfýrlama iþlemleri ekleyebilirsiniz.
    }

    // Karakterin baþka bir nesne ile temas etmesi durumunu kontrol etmek için OnCollisionEnter2D kullanýlabilir
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            Die();
        }
    }
}
