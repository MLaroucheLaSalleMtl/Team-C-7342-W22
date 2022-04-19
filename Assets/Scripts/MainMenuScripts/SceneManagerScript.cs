using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//Based on Brackeys Tutorial
// https://youtu.be/YMj2qPq9CP8?list=PLEDpBDupek8zWPy-CU6b6GJfTBhJVoH1h

public class SceneManagerScript : MonoBehaviour
{
    public int levelToResumeFrom;
    private int checkpointToResumeFrom;

    //Made by Elizabeth D'Avignon

    public void NewGame()
    {
        StartCoroutine(AsyncLoad((int)GameManager.Levels.LVL_TUTORIAL));   
    }


    //check needs to be added so that you can't click the continue button if there is no save file
    public void ContinueGame()
    {
        levelToResumeFrom = GameManager.levelToLoad;
        Debug.Log("resuming level " + levelToResumeFrom);
        checkpointToResumeFrom = GameManager.checkpointToLoad;
        StartCoroutine(AsyncLoad(levelToResumeFrom));
    }

    IEnumerator AsyncLoad(int lvl)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(lvl);

        while(!operation.isDone)
        {
            Debug.Log(operation.progress);

            //waits a frame as to not enter infinite loop
            yield return null;
        }
    }

}
