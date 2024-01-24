using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tacos : MonoBehaviour ,TacosItems
{
    public static event Action<int> OnTacoCollect;
    public int count = 5;
    [SerializeField] private AudioSource collect;
    public void Collect()
    {
        collect.Play();
        OnTacoCollect.Invoke(count);
        Destroy(gameObject);
    }
}
