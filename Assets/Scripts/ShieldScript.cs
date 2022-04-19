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
    
    private Vector3 mousePos;
    [SerializeField]
    public float shieldChargeMax; //Coleman, public for UI script
    public float shieldChargeCurrent; //Coleman, public for UI script
    private bool shieldOvercharged = false;

    //Variables for controller shield rotation (Coleman)
    
    [SerializeField] private float rotationSpeed = 5f;
    private float stickHorizontalInput = 0f;
    private float stickVerticalInput = 0f;


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

        //if (shieldChargeCurrent != shieldChargeMax) Debug.Log("charge: " + shieldChargeCurrent);

        

        //Shield facing
        if (GameManager.CheckControlScheme())
        {
            StickShieldRotation(); //Coleman
        }
        else
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            LookAtMouse();
        }

        if (shieldButtonPressed && !shieldOvercharged) // Coleman
        {
            SoundManager.playSound?.Invoke(SoundManager.SoundType.Shield, transform.position); //Coleman
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


    /*---------------------------------------------
     * The following written by Coleman Ostach
     ---------------------------------------------*/

    public void StickShieldRotation()
    {
        float angle = Mathf.Atan2(stickVerticalInput, stickHorizontalInput) * Mathf.Rad2Deg;
        summonedShield.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void LookAtJoystickPosition(InputAction.CallbackContext context)
    {
        Vector2 aimDirection = context.ReadValue<Vector2>();

        stickHorizontalInput = aimDirection.x;
        stickVerticalInput = aimDirection.y;
    }



    //----------------------------------------------
}
