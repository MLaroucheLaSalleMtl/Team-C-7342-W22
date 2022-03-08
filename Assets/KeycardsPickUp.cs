using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeycardsPickUp : MonoBehaviour
{
    [SerializeField] private Text keyInteractionTxt;
    private bool ableToPickUp;

    
    void Start()
    {
        keyInteractionTxt.gameObject.SetActive(false); //disabled so it will only display if player stands within the pick up range
        
    }

    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        for (int i = 0; i < inventory.inventSlots.Length; i++)
    //        {
    //            if (inventory.slotIsFilled[i] == false) //checks for space and if so item can be stored in said open slot
    //                inventory.slotIsFilled[i] = true;
    //            break;
    //        }
    //    }
    //}

    private void Update()
    {
       if(ableToPickUp && Input.GetKeyDown(KeyCode.F))
        {                               // will check if player is in range (ableToPickUp = true)               
            PickUpKeycard();            // and if "F" key is pressed as well then this method is called
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision) //invoked when player collides with keycard object
    {
        if (collision.GetComponent<Collider2D>().CompareTag("Player"))
        {
            keyInteractionTxt.gameObject.SetActive(true);
            ableToPickUp = true;
        }
      
    }

    private void OnTriggerExit2D(Collider2D collision) //invoked when player leaves collider of keycard turning 
    {                                                  //the bool of abletopickup to false and hiding interaction text
        if (collision.GetComponent<Collider2D>().CompareTag("Player"))
        {
            keyInteractionTxt.gameObject.SetActive(false);
            ableToPickUp = false;
        }
    }

    private void PickUpKeycard()
    {
        Destroy(gameObject);          // the keycard will be destroyed indicating its been "picked up" until I implement an inventory
    }

}
