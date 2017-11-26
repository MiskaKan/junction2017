﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTextManager : MonoBehaviour {
	public static InfoTextManager self = null;
	public static bool showText = false;
	public SpriteRenderer[] sprites = new SpriteRenderer[0];
	public int activesLeft = -1;
	public int activesStart = 60;
	private Vector3 originalScale = Vector3.zero;
	private GameObject current = null;

	// Use this for initialization
	void Start () {
		self = this;
		originalScale = self.transform.localScale;
	}

	public void displayText(string _text){
		activesLeft = activesStart;
		showText = true;
	}

	// Update is called once per frame
	void Update () {
		self.gameObject.SetActive (showText);
		if (showText) {
			if (activesStart == 0) {
				showText = false;
			} else {
				self.gameObject.transform.localScale *= (Mathf.Max(activesStart - activesLeft, 1) * 1.01f);
			}
			activesStart--;
		}
	}
}