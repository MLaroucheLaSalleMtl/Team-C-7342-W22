using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceController : MonoBehaviour
{
    //Made by Elizabeth D'Avignon

    //to finish

    [SerializeField]
    private bool startDisabled;
    [SerializeField]
    private GameObject enableZone;
    [SerializeField]
    private GameObject disableZone;
    [SerializeField]
    private GameObject[] objetArray;

    private void Start()
    {
        if (startDisabled) DisableInstances();
    }

    public void EnableInstances()
    {
        foreach(GameObject obj in objetArray)
        {
            obj.SetActive(true);
        }
    }

    public void DisableInstances()
    {
        foreach (GameObject obj in objetArray)
        {
            obj.SetActive(false);
        }
    }

}
