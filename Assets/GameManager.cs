using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;




//Made by Elizabeth

//Save system heavily based on Code Monkey's tutorial series: https://www.youtube.com/playlist?list=PLzDRvYVwl53vRrMuPBkNNZUmnl1jCHcHs


public class GameManager : MonoBehaviour
{
    //This needs to be updated as we get more levels
    public enum Levels
    {
        LVL_PRELOADER,
        LVL_MAINMENU,
        LVL_LEVELONE,
        LVL_PROJECTILE
    }

    private static GameManager instance;
    public static bool hasSave = false;
    public static int levelToLoad = (int)Levels.LVL_MAINMENU;
    public static int checkpointToLoad = 0;
    public static GameManager Instance
    {
        get { return instance; }
    }
    private static PlayerSave playerSave;
    Scene currentScene;

    //temporary save testing vars
    int tempCheckpoint;
    int tempScene;


private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        tempCheckpoint = 0;
        tempScene = 0;
        if (File.Exists(Application.dataPath + "/Save.txt"))
        {
            hasSave = true;
        }

        if (currentScene.buildIndex != (int)Levels.LVL_PRELOADER || currentScene.buildIndex != (int)Levels.LVL_MAINMENU)
        {
            if (GameObject.Find("PlayerPrefab") != null)
            {
                Debug.Log("Player found");
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        //temporary save / load triggers
        if (Input.GetKeyDown(KeyCode.S))
        {
            WriteSave(tempCheckpoint, tempScene);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadSave();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            tempCheckpoint += 1;
            Debug.Log("Checkpoint increase button pressed. tempCheckpoint now at: " + tempCheckpoint);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            tempScene += 1;
            Debug.Log("Scene increase button pressed. tempScene now at: " + tempScene);
        }

    }

    public static void LoadSave()
    {
        Debug.Log("Load function triggered");
        if (File.Exists(Application.dataPath + "/Save.txt"))
        {
            hasSave = true;
            string loadResult = File.ReadAllText(Application.dataPath + "/Save.txt");
            playerSave = JsonUtility.FromJson<PlayerSave>(loadResult);
            Debug.Log("loaded checkpoint: " + playerSave.checkpoint);
            Debug.Log("loaded level: " + playerSave.level);

            levelToLoad = playerSave.level;
            checkpointToLoad = playerSave.checkpoint;
        }
        else
        {
            hasSave = false;
            Debug.Log("No save file detected.");
        }
    }

    public static void WriteSave(int checkpoint, int scene)
    {
        
        playerSave = new PlayerSave
        {
            checkpoint = checkpoint,
            level = scene,
        };
        string json = JsonUtility.ToJson(playerSave);
        Debug.Log("Save button pressed. " + json + " saved.");
        File.WriteAllText(Application.dataPath + "/Save.txt", json);
    }

    public static void DeleteSave()
    {
        playerSave = new PlayerSave
        {
            checkpoint = 0,
            level = 0,
        };
        hasSave = false;
        if (File.Exists(Application.dataPath + "/Save.txt"))
        {
            File.Delete(Application.dataPath + "/Save.txt");
        }
        //The editor says to ensure to also delete this file
        if (File.Exists(Application.dataPath + "/Save.txt.meta"))
        {
            File.Delete(Application.dataPath + "/Save.txt.meta");
        }
        Debug.Log("DeleteSave ran");
    }


    private class PlayerSave
    {
        public int checkpoint;
        public int level;
    }
}
