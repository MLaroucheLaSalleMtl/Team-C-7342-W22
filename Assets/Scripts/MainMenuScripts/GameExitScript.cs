using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExitScript : MonoBehaviour
{
    //Made by Elizabeth

    public void Exit()
    {
        
        if (Application.isPlaying & !Application.isEditor)  Application.Quit();
            

            //remember to set to set to true to test closing the game in the editor, otherwise it prevents the build from being made
        #if false
        else
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        
    }
}
