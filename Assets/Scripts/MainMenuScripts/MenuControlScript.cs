using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Made by Elizabeth

public class MenuControlScript : MonoBehaviour
{
    private GameObject mmCanvas;
    private GameObject optionsCanvas;
    private GameObject creditsCanvas;
    private bool foundSave;
    private void Start()
    {
        mmCanvas = GameObject.Find("MainMenuCanvas");
        optionsCanvas = GameObject.Find("OptionsMenuCanvas");
        creditsCanvas = GameObject.Find("CreditsCanvas");
        if(GameManager.hasSave)
        {
            foundSave = true;
        }
        else
        {
            GameObject.Find("ContinueButton").GetComponent<Button>().interactable = false;
            
            foundSave = false;
        }
    }


    public void NewGameButton()
    {
        gameObject.GetComponent<SceneManagerScript>().NewGame();
    }

    public void ContinueGameButton()
    {
        gameObject.GetComponent<SceneManagerScript>().ContinueGame();
    }
    public void OpenOptions()
    {
        mmCanvas.GetComponent<Canvas>().enabled = false;
        optionsCanvas.GetComponent<Canvas>().enabled = true;
    }

    public void OpenCredits()
    {
        mmCanvas.GetComponent<Canvas>().enabled = false;
        creditsCanvas.GetComponent<Canvas>().enabled = true;
    }

    public void ReturnToMM()
    {
        mmCanvas.GetComponent<Canvas>().enabled = true;
        optionsCanvas.GetComponent<Canvas>().enabled = false;
        creditsCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void ExitGame()
    {

        if (Application.isPlaying & !Application.isEditor) Application.Quit();


        //remember to set to set to true to test closing the game in the editor, otherwise it prevents the build from being made
#if false
        else
            UnityEditor.EditorApplication.isPlaying = false;
#endif

    }
}
