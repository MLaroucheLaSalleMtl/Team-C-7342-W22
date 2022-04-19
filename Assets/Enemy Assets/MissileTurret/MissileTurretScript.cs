using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Elizabeth D'Avignon at first, but Coleman took over

public class MissileTurretScript : MonoBehaviour
{
    Vector2 direction;
    // Start is called before the first frame update
    
    [SerializeField]
    private float missileCooldown;
    [SerializeField]
    private GameObject missile;
    [SerializeField]
    private GameObject missileSpawn;

    public EnemyLineOfSight los;

    private float missileTimer;

    void Start()
    {
        missileTimer = missileCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
        foreach(Transform visibleTargets in los.visibleTargets)
        {
            if (missileTimer > 0)
            {
                missileTimer -= Time.deltaTime;
                //Debug.Log("cooldown: " + missileTimer);
            }
            // Just putting an "else" creates several nonsensical errors that don't affect functionality
            else if (missileTimer < 0)
            {
                missileTimer = missileCooldown;
                ShootMissile();
            }
        }
    }

    public void ShootMissile()
    {
        Instantiate(missile, missileSpawn.transform.position, transform.rotation);
        SoundManager.playSound?.Invoke(SoundManager.SoundType.MissileFire, transform.position);
    }

    void LookAtPlayer()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        direction = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y);


        transform.right = direction;
    }
}
