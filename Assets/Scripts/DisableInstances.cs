using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInstances : MonoBehaviour
{
    InstanceController instanceController;
    void Start()
    {
        instanceController = GetComponentInParent<InstanceController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            instanceController.DisableInstances();
        }
    }
}
