using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Main : MonoBehaviour
{                  
    public static Main instance = null;
    private LevelManager levelScript;                       
    private int level = 1;                                  

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        levelScript = GetComponent<LevelManager>();
        InitGame();
    }

    void OnLevelWasLoaded(int index) {
        level = index;
        InitGame();
    }

    void InitGame() {
        levelScript.SetupScene(level);
    }

    void Update() {
    }

    public void GameOver() {
        enabled = false;
    }
}