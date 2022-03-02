using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRaycast : MonoBehaviour
{

    /*---------------------------------------------
     * Code written by Coleman Ostach
     ---------------------------------------------*/


    Collider2D targetCollider;
    [SerializeField] Transform rayTarget;

    void TurretPlayerDetection(Vector2 start, Vector2 end)
    {
        if (Physics2D.Linecast(start, end))
        {
            targetCollider = Physics2D.Linecast(start, end).collider;
            print("ray just hit the gameobject: " + targetCollider.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 startPosition = transform.position;
        Vector2 endPosition = rayTarget.transform.position;

        Debug.DrawLine(startPosition, endPosition, Color.yellow);
        TurretPlayerDetection(startPosition, endPosition);
    }
}
