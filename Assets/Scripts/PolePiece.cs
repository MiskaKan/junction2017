using UnityEngine;
using System.Collections;

public class PolePiece {
	public GameObject go;
	public float heat = 0.0f;

	public PolePiece(GameObject _go){
		go = _go;
	}

	public float addHeat(float toAdd){
		heat += toAdd;
		return heat;
	}

	public float doTwist(){
		float gravityMultiplier = getGravityMultiplier ();
		float twistAmount = Mathf.Pow(heat, 3f)*gravityMultiplier*Globals.self.heatingStrength;
		go.transform.Rotate (new Vector3 (go.transform.rotation.x, go.transform.rotation.y, twistAmount));
		//return twistAmount;
		return gravityMultiplier;
	}

	public float coolDown(){
		heat = Mathf.Abs(heat) * 0.99f;
		return heat;
	}

	public float getGravityMultiplier(){
		return Vector3.Cross(Globals.self.gravityDirection, go.transform.right).z;
	}
}

