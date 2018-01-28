using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour {

    // Use this for initialization
    void Start () {
        //determines if persistent data exists...
        GameObject gameData = GameObject.Find("GameData");
        if (gameData != null) {
            GameData gameDataScript = gameData.GetComponent<GameData>();
            gameDataScript.lastLevel = Application.loadedLevelName;
        }
        //determines if persistent data exists...
        GameObject musicObject = GameObject.Find("MusicObject");
	    if (musicObject != null) {
	        MusicControl musicScript = musicObject.GetComponent<MusicControl>();
	        musicScript.gameLevel = true;
	    }
	    //audio.Play();
    }

    // Update is called once per frame
    void Update() {

    }
}
