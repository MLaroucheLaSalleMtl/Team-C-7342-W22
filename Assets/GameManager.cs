using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Levels
    {
        LVL_PRELOADER,
        LVL_MAINMENU,
        LVL_LEVELONE
    }

    private static GameManager instance;
    public static bool hasSave = false;
    public static int levelToLoad = (int)Levels.LVL_MAINMENU;
    public static int checkpointToLoad = 0;
    public static GameManager Instance
    {
        get { return instance; }
    }

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSave()
    {

    }

    public void WriteSave()
    {

    }
}
