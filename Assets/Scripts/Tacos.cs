using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tacos : MonoBehaviour ,TacosItems
{
    public void Collect()
    {
        Destroy(gameObject);
    }   
}
