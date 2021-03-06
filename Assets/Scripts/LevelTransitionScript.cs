using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;


public class LevelTransitionScript : MonoBehaviour
{
    //Made by Elizabeth D'Avignon

    //Need to figure out how to get this to be a variable in the editor, otherwise scene transitions will need to be hard-coded for each instance
    [SerializeField]
    private int[] SceneArray;

    public void Start()
    {
        
    }

    public void LoadLevel()
    {
        StartCoroutine(AsyncLoad((int)GameManager.Levels.LVL_TUTORIAL));
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Collider detected player");
            LoadLevel();
        }
        
    }

}
