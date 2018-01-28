using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterVolume : MonoBehaviour {

	// Use this for initialization
	void Start() {
		
	}

    // Update is called once per frame
    void Update() {
        //determines if persistent data exists, and the master volume is assigned from it to the audio listener in the scene
        GameObject gameData = GameObject.Find("GameDataObject");
        if (gameData != null) {
            GameData gameDataScript = gameData.GetComponent<GameData>();
            AudioListener.volume = gameDataScript.masterVolume;
        }
    }
}
