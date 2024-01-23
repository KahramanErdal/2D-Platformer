using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Ate� topu h�z�
    public float lifetime = 2.0f; // Ate� topunun �mr� (saniye)

    private Vector2 direction;

    // Ate� y�n�n� belirle
    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Start()
    {
       
    }

    void Update()
    {
        // Ate� topunu hareket ettir
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
