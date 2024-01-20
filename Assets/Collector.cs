using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TacosItems item = collision.GetComponent<TacosItems>();
        if(item != null)
        {
            item.Collect();
        }
    }
}
