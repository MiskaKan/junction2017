using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour {
	public Button leftButton;
	public Button rightButton;
	private Main MainScript;
	// Use this for initialization
	void Start () {
		MainScript = GetComponent<Main>();
		leftButton.onClick.AddListener(PreviousLevelPress);
		rightButton.onClick.AddListener(NextLevelPress);
	}



	void PreviousLevelPress() {
		MainScript.LoadPreviousLevel ();
	}

	void NextLevelPress() {
		MainScript.LoadNextLevel ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
