using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerUIController : MonoBehaviour
{

    /*---------------------------------------------
     * Code written by Coleman Ostach
     ---------------------------------------------*/

    [SerializeField] private Image healthFillable;
    [SerializeField] private Image abiltiyFillable;
    [SerializeField] private TextMeshProUGUI levelText;

    PlayerHealthManager health;
    ShieldScript shield;

    bool returnToMenu = false;

    private void HealthBar()
    {
        healthFillable.fillAmount = health.playerHealth * 0.01f;
    }

    private void AbilityBar()
    {
        abiltiyFillable.fillAmount = (shield.shieldChargeCurrent / shield.shieldChargeMax * 100) * 0.01f;
    }

    private void CurrentLevel()
    {
        levelText.text = SceneManager.GetActiveScene().name;
    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        returnToMenu = context.performed;
    }

    private void ReturnToMenu()
    {
        if (returnToMenu)
        {
            SceneManager.LoadSceneAsync(1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<PlayerHealthManager>();
        shield = GetComponent<ShieldScript>();

        CurrentLevel();
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar();
        AbilityBar();
        ReturnToMenu();
    }
}
