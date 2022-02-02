using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] Collider2D targetPlayerCollider;
    [SerializeField] Transform rayTarget;
    RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 startPosition = transform.position;
        Vector2 endPosition = rayTarget.transform.position;

        Debug.DrawLine(startPosition, endPosition, Color.yellow);

        if (Physics2D.Linecast(startPosition, endPosition))
        {
            print("ray just hit the gameobject: " + targetPlayerCollider.gameObject.name);
        }
    }
}
