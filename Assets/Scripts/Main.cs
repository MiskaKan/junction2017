using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
	public GameObject boneMother = null;
	private ArrayList bones = new ArrayList();

	// Use this for initialization
	void Start () {
		var loopSafe = 1000;
		var boneChild = new PolePiece(boneMother.transform.GetChild(0).gameObject);
		while (true && loopSafe-- > 0) {
			bones.Add (boneChild);
			if (boneChild.go.transform.childCount > 0)
				boneChild = new PolePiece(boneChild.go.transform.GetChild (0).gameObject);
			else
				break;
		}
			
	}

	// Update is called once per frame
	void Update () {
		updateHeating ();
		coolDownPole ();
		twistPole ();
		if (Input.GetKey(KeyCode.LeftArrow)) {
			moveHolePole (-0.01f);
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			moveHolePole (0.01f);
		}

	}

	private void moveHolePole(float byX){
		var pp = Globals.self.mainPole.transform.position;
		Globals.self.mainPole.transform.position = new Vector3 (pp.x + byX, pp.y, pp.z);
	}

	private void updateHeating(){
		var tmpBones = getBonesCloseEnoughFire (Globals.self.heatingRadius);
		for (var i = 0; i < tmpBones.Count; i++) {
			var single = (tmpBones[i] as Tuple<PolePiece, float>);
			single.First.addHeat (single.Second);
		}
	}

	private void twistPole(){
		for (var i = 0; i < bones.Count; i++) {
			(bones[i] as PolePiece).doTwist();
		}
	}

	private void coolDownPole(){
		for (var i = 0; i < bones.Count; i++) {
			(bones[i] as PolePiece).coolDown();
		}
	}

	/*Threshold could be maybe between 0.3 to 1.0*/
	private ArrayList getBonesCloseEnoughFire(float threshold){
		ArrayList approved = new ArrayList ();
		for (var i = 0; i < bones.Count; i++) {
			var single = bones [i] as PolePiece;
			var distance = Vector3.Distance (single.go.transform.position, Globals.self.fire.transform.position);
			if (distance < threshold) {
				approved.Add (new Tuple<PolePiece, float> (single, distance));
			}
		}
		return approved;
	}
}
