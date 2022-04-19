using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SignScript : MonoBehaviour
{
    [SerializeField]
    private GameObject KnMText;
    private TextMeshPro KnMTMP;

    [SerializeField]
    private GameObject controllerText;
    private TextMeshPro controllerTMP;

    private void Start()
    {
        KnMTMP = KnMText.GetComponent<TextMeshPro>();
        controllerTMP = controllerText.GetComponent<TextMeshPro>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            if (GameManager.CheckControlScheme())
            {
                controllerTMP.enabled = true;
            }
            else
            {
                KnMTMP.enabled = true;
            }
            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            if (GameManager.CheckControlScheme())
            {
                controllerTMP.enabled = false;
            }
            else
            {
                KnMTMP.enabled = false;
            }

        }

    }

}
