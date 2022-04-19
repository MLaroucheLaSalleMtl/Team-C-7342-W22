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

    public EnemyLineOfSight los;
    public Transform target;
    [SerializeField] float proximityRadius = 5f;
    [SerializeField] private float speed = 200f;
    [SerializeField] private float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;

    Seeker seeker;
    Rigidbody2D rigid;

    //Timer for FollowTarget
    public float timer;
    public float cooldown = 1f;

    //Variables to flip sprite
    [SerializeField] private SpriteRenderer headSprite;

    // Start is called before the first frame update
    void Start()
    {
        los = GetComponentInChildren<EnemyLineOfSight>();
        seeker = GetComponent<Seeker>();
        rigid = GetComponent<Rigidbody2D>();
        timer = cooldown;
        headSprite = GetComponentInChildren<SpriteRenderer>(GameObject.Find("FlyingTurretHead"));

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

    // Update is called once per frame
    void FixedUpdate()
    {
        if(los.target != null)
            target = los.target;

        if (path == null)
            return;

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rigid.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rigid.AddForce(force);

        float distance = Vector2.Distance(rigid.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
            currentWaypoint++;

        if (direction.x >= 0.01f)
            headSprite.flipX = true;
        else
            headSprite.flipX = false;
    }
}
