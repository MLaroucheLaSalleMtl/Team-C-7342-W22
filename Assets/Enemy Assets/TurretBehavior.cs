using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{

    /*---------------------------------------------
     * Code written by Coleman Ostach
     ---------------------------------------------*/


    Collider2D targetCollider;
    [SerializeField] Transform rayTarget;
    PlayerHealthManager playerHealth;
    
    //RaycastHit2D hit;

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

        //Drawing 2D Line in Game view
        LineRenderer line = GetComponent<LineRenderer>();

        List<Vector3> pos = new List<Vector3>();
        pos.Add(startPosition);
        pos.Add(endPosition);
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.startColor = Color.red;
        line.endColor = Color.red;
        line.SetPositions(pos.ToArray());
        line.useWorldSpace = true;

        DamageOverTime(startPosition, endPosition);
    }

    //Method used for player damage over time
    void DamageOverTime(Vector2 start, Vector2 end)
    {

        if (Physics2D.Linecast(start, end))
        {
            targetCollider = Physics2D.Linecast(start, end).collider;
            print("ray just hit the gameobject: " + targetCollider.gameObject.name);

            if (targetCollider.gameObject.name == "Player")
            {
                playerHealth = targetCollider.GetComponent<PlayerHealthManager>();
                playerHealth.TakeDamage(-5.0f * Time.deltaTime);
            }

        }
    }
}
