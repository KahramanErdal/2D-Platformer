using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UseItems : MonoBehaviour
{
    private Inventory inventory;
    public int i;
    public GameObject door;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

    }
    private void OnTriggerStay2D(Collider2D collision)
    {       
        if(collision.CompareTag("door"))
            if (Input.GetKey(KeyCode.F))
            {
                foreach (Transform child in inventory.slots[0].transform)
                {
                    Destroy(door);
                    Destroy(child.gameObject);
                }

            }      
    }
}
