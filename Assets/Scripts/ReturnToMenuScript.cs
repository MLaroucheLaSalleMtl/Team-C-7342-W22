using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenuScript : MonoBehaviour
{
    public void LoadMainMenu()
    {
        StartCoroutine(AsyncLoad((int)GameManager.Levels.LVL_MAINMENU));
    }


    //check needs to be added so that you can't click the continue button if there is no save file


    IEnumerator AsyncLoad(int lvl)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(lvl);

        while (!operation.isDone)
        {
            Debug.Log(operation.progress);

            //waits a frame as to not enter infinite loop
            yield return null;
        }
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LoadMainMenu();
        }
    }
}
