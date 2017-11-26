using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    //public GameObject level5;
    private Main main;
    public int level;
//	LevelButtons buttons = FindObjectOfType(typeof(LevelButtons)) as LevelButtons;

    List<GameObject> levels;

    GameObject clone;

    void Start() {
        main = FindObjectOfType(typeof(Main)) as Main;
        Globals.self.state.Load();
        level = Globals.self.state.maxLevel;
        if (level < 0 || level > 3) {
            level = 0;
        }
        SetupScene();
    }

    void Update() {
        //Level completed
        if (clone.transform.position.z < -0.2f) {
            //Do stuff
			if (level == Globals.self.state.maxLevel && level < 3) {
                Globals.self.state.maxLevel++;
                Globals.self.state.Save();
            }
			InfoTextManager.self.displayText (3);

            //What happens after the last level has been completed?
			if (level < 3) level++;
            SetupScene();
        }  
    }

    public void SetupScene() {
        DestoryClones();
        Globals.resetPole();
        main.movementDisabled = false;
        levels = new List<GameObject>() { level1, level2, level3, level4 };

        if (level > -1 && level < levels.Count) {
            if (level == 0) {
				clone = Instantiate(levels[level], new Vector3(6.48f, 3.72f, 1), Quaternion.Euler(180, 0, 180));
                clone.gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.2f);
            }/* else if (level == 1) {
                clone = Instantiate(levels[level], new Vector3(2.5f, 4.8f, 1), Quaternion.Euler(0, 180, 0));
                clone.gameObject.transform.localScale = new Vector3(4f, 4f, 4f);
            }*/ else if (level == 1) {
                clone = Instantiate(levels[level], new Vector3(5.0f, 4.8f, 1), Quaternion.Euler(180, 0, 180));
                clone.gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            } else if (level == 2) {
                clone = Instantiate(levels[level], new Vector3(5.0f, 4f, 1), Quaternion.Euler(180, 0, 180));
                clone.gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            } else if (level == 3) {
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
		InfoTextManager.self.displayText (1);
        clone.GetComponent<Rigidbody>().AddForce(0, 0, -20.0f);
    }
}
