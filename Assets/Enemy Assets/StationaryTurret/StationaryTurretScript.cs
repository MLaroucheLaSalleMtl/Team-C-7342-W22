using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryTurretScript : MonoBehaviour
{

    [SerializeField]
    private GameObject missile;
    [SerializeField]
    private GameObject missileSpawn;
    [SerializeField]
    private float fireRate;
    private float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = fireRate;
    }

    // Update is called once per frame
    void Update()
    {

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            //Debug.Log("cooldown: " + missileTimer);
        }
        // Just putting an "else" creates several nonsensical errors that don't affect functionality
        else if (cooldown < 0)
        {
            cooldown = fireRate;
            ShootMissile();
        }
        
    }

    public void ShootMissile()
    {
        Instantiate(missile, missileSpawn.transform.position, transform.rotation);
        SoundManager.playSound?.Invoke(SoundManager.SoundType.MissileFire, transform.position);
    }
}
