using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{

    /*---------------------------------------------
     * Code written by Coleman Ostach
     ---------------------------------------------*/

    [SerializeField] private float enemyHealth = 1f;
    private float enemyMaxHealth;

    public void TakeHit()
    {
        enemyHealth--;

        if (enemyHealth < 0)
            EnemyDeath();
    }

    void EnemyDeath()
    {
        if (enemyHealth <= 0)
        {
            print("The enemy has died");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        enemyMaxHealth = enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
