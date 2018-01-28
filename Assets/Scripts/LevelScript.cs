using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour {
	
	public GameObject snow;
	public PrismSpawn[] prismSpawns;
	bool levelComplete = false;
	bool[] prismsComplete;
	bool[] finisheds;

// Use this for initialization
void Start () {
	audio.Play();
	finisheds = new bool[prismSpawns.length];
	foreach (bool finished in finisheds) {
		finished = true;
	}
}
	
// Update is called once per frame
    void Update() {
        //changes volume of sound to match volume stored in pers.data
        GameObject gameData = GameObject.Find("GameDataObject");
        if (gameData != null) {
            	GameData gameDataScript = gameData.GetComponent<GameData>();
            	gameDataScript.lastLevel = "";
        }
	for (int i = 0; i < prismSpawns.length; i++) {
		if (prismSpawns[i].levelComplete == true) {
			prismsComplete[i] = true;
		}
	}
	levelComplete = ArrayEquals(prismSpawns, finisheds);
	if (levelComplete == true) {
		snow.setActive(true);
	}
    }
}
