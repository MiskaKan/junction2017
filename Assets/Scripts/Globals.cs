using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Globals : MonoBehaviour {
	public static Globals self;
	public GameObject mainPole = null;
	public GameObject fire = null;
	public float heatingRadius = 0.5f;
	public float heatingStrength = 0.001f;
	public float movingSpeed = 0.001f;
	public Vector3 gravityDirection = Vector3.down;
	public Text text = null;
	private float yRotation;
	private float xRotation;
	private float zRotation;

	// Use this for initialization
	void Start () {
		self = this;
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		xRotation = Input.gyro.rotationRateUnbiased.x;
		yRotation = Input.gyro.rotationRateUnbiased.y;
		zRotation = Input.gyro.rotationRateUnbiased.z;
		text.text = xRotation + " - " + yRotation + " - " + zRotation;
		gravityDirection = new Vector3(0f, Input.gyro.rotationRateUnbiased.z, 0f);
	}
}
