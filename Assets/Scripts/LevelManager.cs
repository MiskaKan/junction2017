using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;
    private Main main;

    List<GameObject> levels;

    GameObject clone;

    void Start() {
        main = FindObjectOfType(typeof(Main)) as Main;
    }

    void Update() {
        //Level completed
        if (clone.transform.position.z < -0.2f) {
            //Do stuff
            main.LoadNextLevel();
        }  
    }

    public void SetupScene(int level) {
        DestoryClones();
        levels = new List<GameObject>() { level1, level2, level3, level4, level5 };

        if (level > -1 && level < levels.Count) {
            if (level == 0) {
                clone = Instantiate(levels[level], new Vector3(5.0f, 3.9f, 1), Quaternion.Euler(180, 0, 180));
                clone.gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            } else if (level == 1) {
                clone = Instantiate(levels[level], new Vector3(2.5f, 4.8f, 1), Quaternion.Euler(0, 180, 0));
                clone.gameObject.transform.localScale = new Vector3(4f, 4f, 4f);
            } else if (level == 2) {
                clone = Instantiate(levels[level], new Vector3(5.0f, 4.8f, 1), Quaternion.Euler(180, 0, 180));
                clone.gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            } else if (level == 3) {
                clone = Instantiate(levels[level], new Vector3(5.0f, 4f, 1), Quaternion.Euler(180, 0, 180));
                clone.gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            } else if (level == 4) {
                clone = Instantiate(levels[level], new Vector3(5.0f, 4.1f, 1), Quaternion.Euler(180, 0, 180));
                clone.gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
        }

        clone.gameObject.tag = "clone";
        clone.SetActive(true);

    }

    public void DestoryClones() {
        var clones = GameObject.FindGameObjectsWithTag("clone");
        foreach (var clone in clones){
            Destroy(clone);
        }
    
    }

    public void StartMovingPlane() {
        clone.GetComponent<Rigidbody>().AddForce(0, 0, -5.0f);
    }
}
