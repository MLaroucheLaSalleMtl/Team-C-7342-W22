using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{

    /*---------------------------------------------
     * Code written by Coleman Ostach
     ---------------------------------------------*/

    [SerializeField] private Image healthFillable;
    [SerializeField] private Image abiltiyFillable;

    PlayerHealthManager health;
    ShieldScript shield;

    private void HealthBar()
    {
        healthFillable.fillAmount = health.playerHealth * 0.01f;
    }

    private void AbilityBar()
    {
        abiltiyFillable.fillAmount = (shield.shieldChargeCurrent / shield.shieldChargeMax * 100) * 0.01f;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<PlayerHealthManager>();
        shield = GetComponent<ShieldScript>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar();
        AbilityBar();
    }
}
