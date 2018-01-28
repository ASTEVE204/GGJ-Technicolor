using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {

    //variables declared as public to be accessed by other scripts
    public bool hasGun;
    public bool hasTorch;
    public float masterVolume;
    public int playerHealth;
    public int targetsDestroyed;
    public int cumulativeScore;
    public int loadedAmmo;
    public int reserveAmmo;
    public string lastLevel;
    public string playerName;

    // Use this for initialization
    void Start() {
        //will ensure that the object containing this script is not destroyed when the scene changes
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update() {

    }
}
