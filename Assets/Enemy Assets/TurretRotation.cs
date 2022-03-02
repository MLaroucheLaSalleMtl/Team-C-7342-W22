using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    /*---------------------------------------------
     * Code written by Coleman Ostach
     ---------------------------------------------*/

    [SerializeField] private float rotationSpeed = 5f; //Speed of the turret head rotation
    public Transform target; //Target of the rotation (Can be set to static object or even player)

    private Vector2 direction;
    private float angle;
    private Quaternion rotation;
    [SerializeField] private float offset = 0.16f; //Offset in order to correctly rotate from the head pivot point

    EnemyLineOfSight los;

    // Start is called before the first frame update
    void Start()
    {
        los = GetComponent<EnemyLineOfSight>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = target.position - transform.position;
        angle = Mathf.Atan2((direction.y - offset), direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}