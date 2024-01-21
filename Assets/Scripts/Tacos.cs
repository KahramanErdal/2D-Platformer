using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tacos : MonoBehaviour ,TacosItems
{
    public static event Action<int> OnTacoCollect;
    public int count = 5;

    public void Collect()
    {
        OnTacoCollect.Invoke(count);
        Destroy(gameObject);
    }   
}
