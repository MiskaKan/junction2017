using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Globals : MonoBehaviour {
	public static Globals self;
	public GameObject boneMother = null;
	public GameObject mainPole = null;
	public Vector3 mainPoleOriginalPosition = Vector3.zero;
	public GameObject fire = null;
	public float heatingRadius = 0.5f;
	public float heatingStrength = 0.001f;
	public float movingSpeed = 0.001f;
	public Vector3 gravityDirection = Vector3.down;
	public Text text = null;
	public StateSaver state = new StateSaver ();
	private float yRotation;
	private float xRotation;
	private float zRotation;
	public ArrayList bones = new ArrayList();
	public ArrayList poleMeshes = new ArrayList();
	public float poleMoved = 0f;
	public bool introDone = false;

	// Use this for initialization
	void Start () {
		self = this;
		Input.gyro.enabled = true;
		mainPoleOriginalPosition = mainPole.transform.position;

		for (int i = 1; i < mainPole.transform.childCount; i++) {
			poleMeshes.Add (mainPole.transform.GetChild (i).gameObject);
		}

		var loopSafe = 1000;
		var boneChild = new PolePiece(boneMother.transform.GetChild(0).gameObject);
		while (true && loopSafe-- > 0) {
			bones.Add (boneChild);
			if (boneChild.goBone.transform.childCount > 0) {
				boneChild = new PolePiece (boneChild.goBone.transform.GetChild (0).gameObject);
			} else {
				break;
			}
		}

		InfoTextManager.self.displayText ("Jooo");
	}
	
	// Update is called once per frame
	void Update () {
		gravityDirection = Input.gyro.gravity;
	}

	public static void resetPole(){
		LevelButtons.showButtons = true;
		for (var i = 0; i < Globals.self.bones.Count; i++) {
			(Globals.self.bones[i] as PolePiece).reset();
		}
		Globals.self.poleMoved = 0f;
		Globals.self.mainPole.transform.position = Globals.self.mainPoleOriginalPosition;
	}

	/*Threshold could be maybe between 0.3 to 1.0*/
	public static ArrayList getBonesCloseEnoughFire(float threshold){
		ArrayList approved = new ArrayList ();
		for (var i = 0; i < Globals.self.bones.Count; i++) {
			var single = Globals.self.bones [i] as PolePiece;
			var distance = Vector3.Distance (single.goBone.transform.position, Globals.self.fire.transform.position);
			if (distance < threshold) {
				approved.Add (new Tuple<PolePiece, float> (single, distance));
			}
		}
		return approved;
	}

	public static GameObject getMeshCloseToBone(Vector3 _position){
		GameObject approved = new GameObject ();
		float minimumDist = float.MaxValue;
		for (var i = 0; i < Globals.self.poleMeshes.Count; i++) {
			var single = Globals.self.poleMeshes [i] as GameObject;
			var distance = Vector3.Distance (single.GetComponent<SkinnedMeshRenderer>().bounds.center, _position);
			if (distance < minimumDist) {
				minimumDist = distance;
				approved = single;
			}
		}
		return approved;
	}
}
