using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour {
	public Button leftButton;
	public Button rightButton;
	// Use this for initialization
	void Start () {
		leftButton.onClick.AddListener(PreviousLevelPress);
		rightButton.onClick.AddListener(NextLevelPress);
	}

	void PreviousLevelPress() {
		Debug.Log ("Prev. pressed");
	}

	void NextLevelPress() {
		Debug.Log ("Next pressed");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
