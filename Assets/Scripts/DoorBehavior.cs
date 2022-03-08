using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private GameObject keyCard;
    [SerializeField] private GameObject keyNeeded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.CompareTag("Door"))
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
