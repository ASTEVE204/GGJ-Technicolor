using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour {

    public GameObject snow;
    public bool levelComplete = false;

    IEnumerator LevelCompleted() {
        //audio.Play();
        yield return new WaitForSeconds(/*audio.clip.length*/1);
        Application.LoadLevel("EndGame");
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        //changes volume of sound to match volume stored in pers.data
        GameObject gameData = GameObject.Find("GameDataObject");
        if (gameData != null) {
            GameData gameDataScript = gameData.GetComponent<GameData>();
            gameDataScript.lastLevel = Application.loadedLevelName;
        }
        if (levelComplete == true) {
            StartCoroutine("LevelCompleted");
        }

    }

    //check the tag of the particles hitting the prism
    void OnParticleCollision(GameObject other) {
        if (other.tag == "EndParticles") {
            snow.SetActive(true);
            levelComplete = true;
        }
    }
}
