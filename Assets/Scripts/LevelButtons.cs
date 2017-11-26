using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtons : MonoBehaviour {
	public static bool showButtons = false;
	public Button leftButton;
	public Button rightButton;
    public Button testButton;
    private LevelManager levels;

	// Use this for initialization
	void Start () {
        levels = FindObjectOfType(typeof(LevelManager)) as LevelManager;
        leftButton.onClick.AddListener(PreviousLevelPress);
		rightButton.onClick.AddListener(NextLevelPress);
        testButton.onClick.AddListener(TestLevel);
    }

	void PreviousLevelPress() {
		if (levels.level > 0) {
			levels.level--;
			levels.SetupScene();
		}
	}

	void NextLevelPress() {
		if (levels.level < 3 && levels.level < Globals.self.state.maxLevel) {
			levels.level++;
			levels.SetupScene ();
		}
    }

    void TestLevel() {
        levels.StartMovingPlane();
    }
	
	// Update is called once per frame
	void Update () {
		if (Globals.self.introDone) {
			if(leftButton != null)
				leftButton.gameObject.SetActive (showButtons);
			if(rightButton != null)
				rightButton.gameObject.SetActive (showButtons);
		}
	}
}
