using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour {

// Use this for initialization
void Start () {
		
}
	
// Update is called once per frame
    void Update() {
        //changes volume of sound to match volume stored in pers.data
        GameObject gameData = GameObject.Find("GameDataObject");
        if (gameData != null) {
            	GameData gameDataScript = gameData.GetComponent<GameData>();
            	gameDataScript.lastLevel = "";
        }
    }
}
