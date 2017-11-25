using UnityEngine;
using System.Collections;

public class PolePiece {
	public GameObject goBone;
	public GameObject goMesh;
	public Material visualGoMaterial;
	public float heat = 0.0f;
	public bool isDestroyed = false;

	public PolePiece(GameObject _go){
		goBone = _go;
		goMesh = Globals.getMeshCloseToBone (goBone.transform.position);
		visualGoMaterial = new Material (Shader.Find("Specular"));
		goMesh.GetComponent<Renderer> ().material = visualGoMaterial;
	}

	public float addHeat(float toAdd){
		if (!isDestroyed) {
			heat += toAdd;
			return heat;
		} else {
			return 0f;
		}
	}

	public float doTwist(){
		if (!isDestroyed) {
			float gravityMultiplier = getGravityMultiplier ();
			float twistAmount = Mathf.Pow (heat, 3f) * gravityMultiplier * Globals.self.heatingStrength;
			goBone.transform.Rotate (new Vector3 (goBone.transform.rotation.x, goBone.transform.rotation.y, twistAmount));
			return gravityMultiplier;
		} else {
			return 0f;
		}
	}

	public float coolDown(){			
		if (!isDestroyed) {
			heat = Mathf.Abs(heat) * 0.99f;
			visualGoMaterial.color = new Color (0.2f + heat / 25f, 0.2f, 0.2f); 
			return heat;
		} else {
			return 0f;
		}
	}

	public float getGravityMultiplier(){
		return Vector3.Cross(Globals.self.gravityDirection, goBone.transform.right).z;
	}
}

