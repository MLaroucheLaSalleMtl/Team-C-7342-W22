using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PreloaderScript : MonoBehaviour
{

    //Made by Elizabeth

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LoadMainMenu();
    }
}
