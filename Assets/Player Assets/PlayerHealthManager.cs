using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{

    /*---------------------------------------------
     * Code written by Coleman Ostach
     ---------------------------------------------*/


    public float playerHealth = 100.0f;
    private float playerMaxHealth = 100.0f;

    //Variable change needs to be negative float for damage and positive float for healing
    void HealthChange(float change)
    {
        playerHealth += change;

        if (playerHealth <= 0)
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
        SoundManager.playSound?.Invoke(SoundManager.SoundType.Death, transform.position);
        SceneManager.LoadSceneAsync(2);
    }
}
