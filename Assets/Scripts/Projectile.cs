using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; 
    public float lifetime = 2.0f; 

    private Vector2 direction;

   
    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Start()
    {
       
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
