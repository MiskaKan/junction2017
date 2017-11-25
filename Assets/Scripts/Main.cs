using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		checkMoveListeners ();
		updateHeating ();
		coolDownPole ();
		twistPole ();
	}

	private void checkMoveListeners(){
		if (Input.touchCount > 0){
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			if (touchDeltaPosition.x > 0f) {
				moveHolePole (touchDeltaPosition.x * 0.0045f);
			}
		} else if(Input.GetKey(KeyCode.RightArrow)){
			moveHolePole (0.1f * Globals.self.movingSpeed);
		}
	}

	private void moveHolePole(float byX, float byY = 0f){
		var pp = Globals.self.mainPole.transform.position;
		Globals.self.mainPole.transform.position = new Vector3 (pp.x + byX, pp.y + byY, pp.z);
	}

	private void updateHeating(){
		var tmpBones = Globals.getBonesCloseEnoughFire (Globals.self.heatingRadius);
		for (var i = 0; i < tmpBones.Count; i++) {
			var single = (tmpBones[i] as Tuple<PolePiece, float>);
			if (single.Second != 0f) {
				single.First.addHeat (Globals.self.heatingRadius - single.Second);
			}
		}
	}

	private void twistPole(){
		for (var i = 0; i < Globals.self.bones.Count; i++) {
			(Globals.self.bones[i] as PolePiece).doTwist();
		}
	}

	private void coolDownPole(){
		for (var i = 0; i < Globals.self.bones.Count; i++) {
			(Globals.self.bones[i] as PolePiece).coolDown();
		}
	}
}
