using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItems : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
   // [SerializeField] private Text keyInteractionTxt;
   // private bool ableToPickUp;

    private void Start()
    {
        //keyInteractionTxt.gameObject.SetActive(false); //disabled so it will only display if player stands within the pick up range
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    //private void Update()
    //{
    //    if (ableToPickUp && Input.GetKeyDown(KeyCode.F))
    //    {                               // will check if player is in range (ableToPickUp = true)               
    //        PickUpKeycard();            // and if "F" key is pressed as well then this method is called
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //keyInteractionTxt.gameObject.SetActive(true);
            

            for (int i = 0; i < inventory.inventSlots.Length; i++)
            {
                if (inventory.slotIsFilled[i] == false)
                {
                    
                    inventory.slotIsFilled[i] = true;
                    Instantiate(itemButton, inventory.inventSlots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

    //private void OnTriggerExit2D(Collider2D collision) //invoked when player leaves collider of keycard turning 
    //{                                                  //the bool of abletopickup to false and hiding interaction text
    //    if (collision.GetComponent<Collider2D>().CompareTag("Player"))
    //    {
    //        keyInteractionTxt.gameObject.SetActive(false);
    //        ableToPickUp = false;
    //    }
    //}

    private void PickUpKeycard()
    {
        Destroy(gameObject);          // the keycard will be destroyed indicating its been "picked up" until I implement an inventory
    }

}
