using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteDoorScript : MonoBehaviour
{

    public bool oneTime;
    public bool toggle;
    public bool open;
    [SerializeField]
    private GameObject targetDoor;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (targetDoor)
            {
                if (toggle)
                {
                    targetDoor.SetActive(!targetDoor.activeSelf);
                }
                else if (open)
                {
                    targetDoor.SetActive(false);
                    SoundManager.playSound?.Invoke(SoundManager.SoundType.ButtonPress, transform.position); //Coleman
                }
                else
                {
                    targetDoor.SetActive(true);
                }



                if (oneTime)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
