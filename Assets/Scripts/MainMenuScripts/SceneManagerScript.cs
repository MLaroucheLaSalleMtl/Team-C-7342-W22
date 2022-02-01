using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//Based on Brackeys Tutorial
// https://youtu.be/YMj2qPq9CP8?list=PLEDpBDupek8zWPy-CU6b6GJfTBhJVoH1h

public class SceneManagerScript : MonoBehaviour
{
    public string levelToResumeFrom;
    private int checkpointToResumeFrom;


    public void LoadLevel()
    {
        StartCoroutine(AsyncLoad("SampleScene"));   
    }


    //check needs to be added so that you can't click the continue button if there is no save file
    public void ContinueGame()
    {
        levelToResumeFrom = "SampleScene";
        checkpointToResumeFrom = 0;
        Debug.Log("current checkpoint " + checkpointToResumeFrom);
        StartCoroutine(AsyncLoad(levelToResumeFrom));
    }

    IEnumerator AsyncLoad(string lvl)
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
