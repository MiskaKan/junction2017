using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTextManager : MonoBehaviour {
	public static InfoTextManager self = null;
	public static bool showText = false;
	public SpriteRenderer[] sprites = new SpriteRenderer[0];
	public GameObject parent = null;
	public int activesLeft = -1;
	public int activesStart = 100;
	private GameObject current = null;

	// Use this for initialization
	void Start () {
		InfoTextManager.self = this;
		current = sprites [0].gameObject;
	}

	public void displayText(int text){
		if (self != null) {
			self.current.SetActive (false);
			self.activesLeft = self.activesStart;
			self.current = InfoTextManager.self.sprites [text].gameObject;
			InfoTextManager.showText = true;
			self.parent.SetActive (true);
			self.current.SetActive (true);
		}
	}

	// Update is called once per frame
	void Update () { 
		self.gameObject.SetActive (showText);
		self.current.SetActive (showText);
		if (showText) {
			if (activesLeft == 0) {
				showText = false;
			}
			activesLeft--;
		}
	}
}
