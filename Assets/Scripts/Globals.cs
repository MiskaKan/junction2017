using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour {
	public static Globals self;
	public GameObject mainPole = null;
	public GameObject fire = null;
	public float heatingRadius = 0.5f;
	public float heatingStrength = 0.001f;
	public Vector3 gravityDirection = Vector3.down;

	// Use this for initialization
	void Start () {
		self = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
