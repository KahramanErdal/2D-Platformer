using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Ateþ topu hýzý
    public float lifetime = 2.0f; // Ateþ topunun ömrü (saniye)

    private Vector2 direction;

    // Ateþ yönünü belirle
    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Start()
    {
       
    }

    void Update()
    {
        // Ateþ topunu hareket ettir
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
