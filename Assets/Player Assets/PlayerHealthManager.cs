using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private float playerHealth = 100.0f;
    private float playerMaxHealth = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void HealthChange(float change)
    {
        playerHealth += change;

        if(playerHealth < 0)
            //Death()
        if(playerHealth > playerMaxHealth)
            playerHealth = playerMaxHealth;
    }

    public void TakeDamage(float damage)
    {
        HealthChange(damage);
    }

    public void Heal(float heal)
    {
        HealthChange(heal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
