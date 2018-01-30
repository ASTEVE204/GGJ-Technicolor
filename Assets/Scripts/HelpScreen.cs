using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreen : MonoBehaviour {

    //Audio for buttons
    public AudioClip sound;

    //plays through the tutorial clips
    IEnumerator RunTutorial() {
        GetComponent<AudioSource>().PlayOneShot(sound);
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        Tutorial();
    }

    //plays an audio clip and then switches to the main level when a button is clicked
    IEnumerator MenuAfterAudio() {
        GetComponent<AudioSource>().PlayOneShot(sound);
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
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
        Tutorial();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Used to start the tutorial clips
    void Tutorial() {
        StartCoroutine(RunTutorial());
    }
}
