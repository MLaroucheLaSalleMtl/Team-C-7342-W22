using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System;




//Made by Elizabeth D'Avignon

//Save system heavily based on Code Monkey's tutorial series: https://www.youtube.com/playlist?list=PLzDRvYVwl53vRrMuPBkNNZUmnl1jCHcHs


public class GameManager : MonoBehaviour
{
    //This needs to be updated as we get more levels
    public enum Levels
    {
        LVL_PRELOADER,
        LVL_MAINMENU,
        LVL_TUTORIAL,
        LVL_FINAL
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

    public static GameObject player;
    private static PlayerInput playerInput;
    private static bool controllerCheck;
    private static GameObject[] checkpoints;
    


private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        SoundManager.Initialize(); //Initialize the Dictionary in Sound Manager --Coleman--
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }


    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("Level Loaded");
        //Debug.Log(scene.name);
        //Debug.Log(mode);
        player = null;

        currentScene = SceneManager.GetActiveScene();

        if (File.Exists(Application.dataPath + "/Save.txt"))
        {
            Debug.Log("save found");
            hasSave = true;
            LoadSave();
        }

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            Debug.Log("Player found");
            player = GameObject.FindGameObjectWithTag("Player");
            playerInput = player.GetComponent<PlayerInput>();
        }
        else
        {
            Debug.Log("No Player Found");
        }

        if (player && hasSave)
        {
            Transform playerT = player.GetComponent<Transform>();
            Debug.Log("Player x: " + playerT.position.x + " Player y:" + playerT.position.y);
            if (scene.buildIndex == levelToLoad)
            {
                Debug.Log("Right Scene to load");
                checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
                foreach(GameObject cp in checkpoints)
                {
                    Debug.Log("checkpoint :" + cp.GetComponent<CheckpointScript>().GetCheckpointNumber());
                    Debug.Log("Checking checkpoint");
                    if (cp.GetComponent<CheckpointScript>().GetCheckpointNumber() == checkpointToLoad)
                    {
                        
                        Debug.Log("Checkpoint x: " + cp.transform.position.x + " Checkpoint y:" + cp.transform.position.x);
                        playerT.position = cp.transform.position;
                        break;
                    }
                }
            }
        }

        


    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            UpdateControlScheme();
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

    public static bool CheckControlScheme()
    {
        return controllerCheck;
    }

    private static void UpdateControlScheme()
    {
        if (playerInput.currentControlScheme == "Xbox Controller")
        {
            controllerCheck = true;
        }
        else
        {
            controllerCheck = false;
        }
    }

}
