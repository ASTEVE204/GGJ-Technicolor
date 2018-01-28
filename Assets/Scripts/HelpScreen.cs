using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreen : MonoBehaviour {

    //plays an audio clip and then switches to the main level when a button is clicked
    IEnumerator MenuAfterAudio() {
        //audio.Play();
        yield return new WaitForSeconds(/*audio.clip.length*/1);
        Application.LoadLevel("MainMenu");
    }

    //starts the corresponding coroutine when the button to which it is assigned is clicked
    public void BackToMenu() {
        StartCoroutine(MenuAfterAudio());
    }

	// Use this for initialization
	void Start () {
		//determines if persistent data exists...
		GameObject gameData = GameObject.Find("GameDataObject");
		//... if it does not, an object in which to store persistent data is created...
		if (gameData == null) {
		    gameData = new GameObject("GameDataObject");
		    gameData.AddComponent<GameData>();
		}
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
