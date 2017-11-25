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

    List<GameObject> levels;

    public void SetupScene(int level) {
        DestoryClones();
        levels = new List<GameObject>() { level1, level2, level3, level4, level5 };
        if (level > -1 && level < levels.Count) {
            GameObject clone = Instantiate(levels[level], new Vector3(0, 0, 0), Quaternion.Euler(90,0,180));
            clone.gameObject.tag = "clone";
        }
        
    }

    public void DestoryClones() {
        var clones = GameObject.FindGameObjectsWithTag("clone");
        foreach (var clone in clones){
            Destroy(clone);
        }
    
    }
}
