using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Main : MonoBehaviour
{                  
    public static Main instance = null;
    private LevelManager levelScript;                       
    private int level = -1;                                  

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        levelScript = GetComponent<LevelManager>();
        LoadNextLevel();
    }

    public void LoadNextLevel() {
        level++;
        levelScript.SetupScene(level);
    }

    public void LoadPreviousLevel()
    {
        level--;
        levelScript.SetupScene(level);
    }

    void Update() {
    }

    public void GameOver() {
        enabled = false;
    }
}