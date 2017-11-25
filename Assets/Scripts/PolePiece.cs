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
		visualGoMaterial = new Material (Shader.Find("Legacy Shaders/Specular"));
		goMesh.GetComponent<Renderer> ().material = visualGoMaterial;
		goMesh.GetComponent<SkinnedMeshRenderer> ().rootBone = goBone.transform;

		var boxCollider = goBone.AddComponent<BoxCollider>();
		var rigidBody = goBone.AddComponent<Rigidbody>();
		rigidBody.useGravity = false;
		boxCollider.center = Vector3.zero;
		boxCollider.size = new Vector3 (0.2f, 0.2f, 0.2f);
		boxCollider.isTrigger = true;
		boxCollider.tag = "Player";
	}

	public float addHeat(float toAdd){
		if (!isDestroyed) {
			heat += toAdd;
			return heat;
		} else {
			return 0f;
		}
	}

	public void reset(){
		heat = 0.0f;
		goBone.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
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

