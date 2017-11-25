using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtons : MonoBehaviour {
	public Button leftButton;
	public Button rightButton;
    public Button testButton;
    private Main main;

	// Use this for initialization
	void Start () {
        main = FindObjectOfType(typeof(Main)) as Main;
        leftButton.onClick.AddListener(PreviousLevelPress);
		rightButton.onClick.AddListener(NextLevelPress);
        testButton.onClick.AddListener(TestLevel);
    }

	void PreviousLevelPress() {
        main.LoadPreviousLevel();
	}

	void NextLevelPress() {
        main.LoadNextLevel();
	}

    void TestLevel() {
        main.InitiateCheck();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
