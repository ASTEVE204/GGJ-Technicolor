using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {

    //variables declared as public to be accessed by other scripts
    public float masterVolume;
    public int totalClicks;
    public int minClicks;
    public string lastLevel;

    // Use this for initialization
    void Start() {
        //will ensure that the object containing this script is not destroyed when the scene changes
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update() {

    }
}
