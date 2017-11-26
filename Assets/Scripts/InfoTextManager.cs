using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTextManager : MonoBehaviour {
	public static InfoTextManager self = null;
	public static bool showText = false;
	public SpriteRenderer[] sprites = new SpriteRenderer[0];
	public int activesLeft = -1;
	public int activesStart = 100;
	private Vector3 originalScale = Vector3.zero;
	private GameObject current = null;

	// Use this for initialization
	void Start () {
		self = this;
		current = sprites [0].gameObject;
		originalScale = current.transform.localScale;
	}

	public void displayText(int text){
		current.transform.localScale = originalScale;
		activesLeft = activesStart;
		originalScale = self.transform.localScale;
		current = sprites [text].gameObject;
		showText = true;
		self.gameObject.SetActive (true);
		self.current.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
		self.gameObject.SetActive (showText);
		self.current.SetActive (showText);
		if (showText) {
			if (activesLeft == 0) {
				showText = false;
			} else {
				current.transform.localScale *= 1.01f;
			}
			activesLeft--;
		}
	}
}
