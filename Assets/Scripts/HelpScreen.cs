using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreen : MonoBehaviour {

    //plays an audio clip and then switches to the main level when a button is clicked
    IEnumerator GameAfterAudio() {
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        Application.LoadLevel("Main Menu");
    }

    //starts the corresponding coroutine when the button to which it is assigned is clicked
    public void QuitGame() {
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
		    volume = 0.5f;
		    //... otherwise, the player's name and the master volume are assigned from it to the private variables
		}
		//determines if persistent data exists...
		GameObject musicObject = GameObject.Find("MusicObject");
		//... if it does not, an object in which to store persistent data is created, and the background music to be stored in it is played
		if (musicObject == null) {
		    musicObject = new GameObject("MusicObject");
		    musicObject.AddComponent<MusicControl>();
		    AudioSource menuMusic = musicObject.AddComponent<AudioSource>();
		    menuMusic.clip = Resources.Load("Sound/ArcticMonkeys-SecretDoor") as AudioClip;
		    menuMusic.loop = true;
		    menuMusic.Play();
		}

		if (musicObject != null) {
		    MusicControl musicScript = musicObject.GetComponent<MusicControl>();
		    musicScript.gameLevel = false;
		}
    	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
