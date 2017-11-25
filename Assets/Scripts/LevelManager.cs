using UnityEngine;
using System;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;

    List<GameObject> levels;

    public void SetupScene(int level) {
        levels = new List<GameObject>() { level1, level2, level3, level4, level5 };
        Instantiate(levels[level], new Vector3(0,0,0), Quaternion.identity);
    }
}
