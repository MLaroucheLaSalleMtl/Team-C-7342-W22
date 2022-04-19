using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineOfSight : MonoBehaviour
{

    /*---------------------------------------------
     * Code written by Coleman Ostach
     ---------------------------------------------*/

    public float viewRadius;
    public Transform target;
    [Range(0,360)]public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    /*[HideInInspector]*/
    public List<Transform> visibleTargets = new List<Transform>();

    private void Start()
    {
        StartCoroutine("FindTargetWithDelay", 0.2f);
    }

    IEnumerator FindTargetWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTarget();
        }
    }

    void FindVisibleTarget()
    {
        visibleTargets.Clear();

        Collider2D[] targetInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);

        for(int i = 0; i < targetInViewRadius.Length; i++)
        {
            target = targetInViewRadius[i].transform;
            Vector2 dirToTarget = (target.position - transform.position).normalized;

            if(Vector2.Angle(-transform.up, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                }
                else
                {
                    target = null;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
