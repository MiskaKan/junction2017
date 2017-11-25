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
            Debug.Log("Hit the pole");
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }    
    }
}
