using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PullTextManager : MonoBehaviour {
	public static PullTextManager self = null;
	public SpriteRenderer sprite = null;
	private Animator animator = null;

	// Use this for initialization
	void Start () {
		self = this;
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		self.gameObject.SetActive (LevelButtons.showButtons);
	}
}
