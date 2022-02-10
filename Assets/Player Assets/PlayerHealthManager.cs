using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{

    /*---------------------------------------------
     * Code written by Coleman Ostach
     ---------------------------------------------*/


    [SerializeField] private float playerHealth = 100.0f;
    private float playerMaxHealth = 100.0f;

    [SerializeField] LevelTransitionScript SceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Variable change needs to be negative float for damage and positive float for healing
    void HealthChange(float change)
    {
        playerHealth += change;

        if (playerHealth < 0)
            PlayerDeath();
        else
        if (playerHealth > playerMaxHealth)
            playerHealth = playerMaxHealth;
    }

    public void TakeDamage(float damage)
    {
        HealthChange(damage);
    }

    public void Heal(float healAmount)
    {
        HealthChange(healAmount);
    }

    void PlayerDeath()
    {
        if(playerHealth <= 0)
        {
            print("The player has died");
            SceneLoader.LoadLevel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
