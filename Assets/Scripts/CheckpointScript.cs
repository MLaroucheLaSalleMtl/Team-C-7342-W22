using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{

    //Made by Elizabeth D'Avignon

    [SerializeField] private int checkpointNumber;
    [SerializeField] private GameManager.Levels sceneNumber;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Checkpoint " + checkpointNumber + " detected player");
            GameManager.WriteSave(checkpointNumber, (int)sceneNumber);
        }

    }

    public int GetCheckpointNumber()
    {
        return checkpointNumber;
    }

}
