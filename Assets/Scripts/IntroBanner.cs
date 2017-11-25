using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBanner : MonoBehaviour {
	public GameObject me = null;
	public GameObject leftArr = null;
	public GameObject rightArr = null;

	// Use this for initialization
	IEnumerator  Start () {
		yield return StartCoroutine(WaitAndRun(2.0f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator WaitAndRun(float waitTime){
		yield return new WaitForSeconds(waitTime);
		Globals.self.introDone = true;
		me.SetActive (false);
	}
}
