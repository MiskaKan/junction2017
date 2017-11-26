using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			InfoTextManager.self.displayText (1);
			PullTextManager.self.gameObject.SetActive (true);
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            LevelManager levels = FindObjectOfType(typeof(LevelManager)) as LevelManager;
            levels.SetupScene();
        }    
    }
}
