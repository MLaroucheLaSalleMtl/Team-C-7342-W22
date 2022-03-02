using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class ShieldScript : MonoBehaviour
{
    [SerializeField]
    private GameObject shield;
    private GameObject summonedShield;
    bool shieldButtonPressed;
    bool shieldState;
    private bool tempControllerCheck = false;
    private Vector3 mousePos;
    [SerializeField]
    private float shieldChargeMax;
    private float shieldChargeCurrent;
    private bool shieldOvercharged = false;




    // Start is called before the first frame update

    void Start()
    {
        // should be unneccesary, but just to be safe in case something needs the mouse pos on start
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        summonedShield = Instantiate(shield, transform) as GameObject;
        summonedShield.SetActive(false);
        shieldChargeCurrent = shieldChargeMax;
    }

    // Update is called once per frame
    void Update()
    {
     
        //ChargeDrain
        if(shieldState)
        {
            shieldChargeCurrent = Mathf.Max(shieldChargeCurrent - Time.deltaTime, 0);
        }
        else
        {
            shieldChargeCurrent = Mathf.Min(shieldChargeCurrent + Time.deltaTime, shieldChargeMax);
        }
        if (shieldChargeCurrent == 0)
        {
            shieldOvercharged = true;
            summonedShield.SetActive(false);
        }
        if (shieldChargeCurrent == shieldChargeMax && shieldOvercharged)
        {
            shieldOvercharged = false;
        }

        if (shieldChargeCurrent != shieldChargeMax) Debug.Log("charge: " + shieldChargeCurrent);

        //Shield facing
        if (tempControllerCheck)
        {

        }
        else
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            LookAtMouse();
        }


    }


    public void SummonShield(InputAction.CallbackContext context)
    {
         shieldButtonPressed = context.performed;
        //Debug.Log(shieldState);



        if(shieldButtonPressed && !shieldOvercharged)
        {
            shieldState = true;
            summonedShield.gameObject.SetActive(true);
        }
        else
        {
            shieldState = false;
            summonedShield.gameObject.SetActive(false);
        }
    }

    private void LookAtMouse()
    {
        Vector2 aimDirection = (mousePos - summonedShield.transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + 32.5f;
        summonedShield.transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
