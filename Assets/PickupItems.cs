using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItems : MonoBehaviour
{
    private Inventory inventory;


    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.inventSlots.Length; i++)
            {
                if (inventory.slotIsFilled[i] == false)
                {
                    inventory.slotIsFilled[i] = true;
                    break;
                }
            }
        }
    }
    
}
