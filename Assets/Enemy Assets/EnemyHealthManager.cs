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

        if (enemyHealth <= 0)
            EnemyDeath();
    }

    void EnemyDeath()
    {
        SoundManager.playSound?.Invoke(SoundManager.SoundType.Death, transform.position);
        Destroy(gameObject);
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
