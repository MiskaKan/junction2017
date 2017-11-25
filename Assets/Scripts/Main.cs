using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Main : MonoBehaviour
{                  
    public static Main instance = null;
    private LevelManager levelScript;                       
    private int level = -1;
    public GameObject boneMother = null;
    private ArrayList bones = new ArrayList();

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        levelScript = GetComponent<LevelManager>();
        LoadNextLevel();
    }

    public void LoadNextLevel() {
        level++;
        levelScript.SetupScene(level);
    }

    public void LoadPreviousLevel()
    {
        level--;
        levelScript.SetupScene(level);
    }

    public void InitiateCheck() {
        levelScript.StartMovingPlane();
    }

    public void GameOver() {
        enabled = false;
    }

    // Use this for initialization
    void Start()
    {
        var loopSafe = 1000;
        var boneChild = new PolePiece(boneMother.transform.GetChild(0).gameObject);
        while (true && loopSafe-- > 0)
        {
            bones.Add(boneChild);
            if (boneChild.go.transform.childCount > 0)
                boneChild = new PolePiece(boneChild.go.transform.GetChild(0).gameObject);
            else
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        checkMoveListeners();
        updateHeating();
        coolDownPole();
        twistPole();
    }

    private void checkMoveListeners()
    {
        if (Input.touchCount > 0)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            if (touchDeltaPosition.x > 0f)
            {
                moveHolePole(touchDeltaPosition.x * 0.0045f/*Globals.self.movingSpeed*/);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveHolePole(0.1f * Globals.self.movingSpeed);
        }
    }

    private void moveHolePole(float byX, float byY = 0f)
    {
        var pp = Globals.self.mainPole.transform.position;
        Globals.self.mainPole.transform.position = new Vector3(pp.x + byX, pp.y + byY, pp.z);
    }

    private void updateHeating()
    {
        var tmpBones = getBonesCloseEnoughFire(Globals.self.heatingRadius);
        for (var i = 0; i < tmpBones.Count; i++)
        {
            var single = (tmpBones[i] as Tuple<PolePiece, float>);
            if (single.Second != 0f)
            {
                single.First.addHeat(Globals.self.heatingRadius - single.Second);
            }
        }
    }

    private void twistPole()
    {
        for (var i = 0; i < bones.Count; i++)
        {
            (bones[i] as PolePiece).doTwist();
        }
    }

    private void coolDownPole()
    {
        for (var i = 0; i < bones.Count; i++)
        {
            (bones[i] as PolePiece).coolDown();
        }
    }

    /*Threshold could be maybe between 0.3 to 1.0*/
    private ArrayList getBonesCloseEnoughFire(float threshold)
    {
        ArrayList approved = new ArrayList();
        for (var i = 0; i < bones.Count; i++)
        {
            var single = bones[i] as PolePiece;
            var distance = Vector3.Distance(single.go.transform.position, Globals.self.fire.transform.position);
            if (distance < threshold)
            {
                approved.Add(new Tuple<PolePiece, float>(single, distance));
            }
        }
        return approved;
    }
}
	

