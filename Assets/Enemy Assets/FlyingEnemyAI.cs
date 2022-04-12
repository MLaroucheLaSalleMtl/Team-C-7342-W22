using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingEnemyAI : MonoBehaviour
{

    /*---------------------------------------------
     * Code written by Coleman Ostach 
     * Written using the help of https://www.youtube.com/watch?v=jvtFUfJ6CP8&list=WL&index=14&t=518s
     ---------------------------------------------*/

    public Transform enemySprite;

    public Transform target;
    [SerializeField] private float speed = 200f;
    [SerializeField] private float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndofPath = false;

    Seeker seeker;
    Rigidbody2D rigid;

    //Timer for FindTarget
    float secs = 5f;
    float currentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rigid = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
            seeker.StartPath(rigid.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FindTarget()
    {
        Collider2D targetCollider = Physics2D.OverlapCircle(transform.position, 5);

        if(targetCollider.CompareTag("Player"))
        {
            target = targetCollider.transform;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FindTarget();

        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndofPath = true;
            return;
        }
        else
            reachedEndofPath = false;

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rigid.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rigid.AddForce(force);

        float distance = Vector2.Distance(rigid.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
            currentWaypoint++;

        //if (rigid.velocity.x >= 0.01f)
        //    enemySprite.localScale = new Vector3(-1f, 1f, 1f);
        //else
        //    enemySprite.localScale = new Vector3(1f, 1f, 1f);
    }
}
