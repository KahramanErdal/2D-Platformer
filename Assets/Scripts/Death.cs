using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Transform checkpoint;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Deathzone"))
        {
            transform.position = checkpoint.position;
        }        
    }
}
