using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    //Volume to be edited by slider
    //public Slider volumeSlider;
    float volume = 0.5f;

    //plays an audio clip and then switches to the main level when a button is clicked
    IEnumerator GameAfterAudio() {
        //determines if persistent data exists and assigns to it the data from the private variables
        GameObject gameData = GameObject.Find("GameDataObject");
        if (gameData != null) {
            GameData gameDataScript = gameData.GetComponent<GameData>();
            gameDataScript.masterVolume = volume;

        }
        //audio.Play();
        yield return new WaitForSeconds(/*audio.clip.length*/1);
        Application.LoadLevel("Level 1");
    }

    //plays an audio clip and then switches to the options menu when a button is clicked
    IEnumerator HelpAfterAudio() {
        //determines if persistent data exists and assigns to it the data from the private variables
        GameObject gameData = GameObject.Find("GameDataObject");
        if (gameData != null)
        {
            GameData gameDataScript = gameData.GetComponent<GameData>();
            gameDataScript.masterVolume = volume;
        }
        //audio.Play();
        yield return new WaitForSeconds(/*audio.clip.length*/1);
        Application.LoadLevel("Help");
    }

    //plays an audio clip and then switches to the options menu when a button is clicked
    IEnumerator CreditsAfterAudio() {
        //determines if persistent data exists and assigns to it the data from the private variables
        GameObject gameData = GameObject.Find("GameDataObject");
        if (gameData != null)
        {
            GameData gameDataScript = gameData.GetComponent<GameData>();
            gameDataScript.masterVolume = volume;
        }
        //audio.Play();
        yield return new WaitForSeconds(/*audio.clip.length*/1);
        Application.LoadLevel("Credits");
    }

    //plays an audio clip and then exits the game when a button is clicked
    IEnumerator QuitAfterAudio() {
        //audio.Play();
        yield return new WaitForSeconds(/*audio.clip.length*/1);
        Application.Quit();
    }

    //starts the corresponding coroutine when the button to which it is assigned is clicked
    public void StartGame() {
        StartCoroutine(GameAfterAudio());
    }

    //starts the corresponding coroutine when the button to which it is assigned is clicked
    public void LoadHelp() {
        StartCoroutine(HelpAfterAudio());
    }

    //starts the corresponding coroutine when the button to which it is assigned is clicked
    public void LoadCredits() {
        StartCoroutine(CreditsAfterAudio());
    }

    //starts the corresponding coroutine when the button to which it is assigned is clicked
    public void QuitGame() {
        StartCoroutine(QuitAfterAudio());
    }

    // Use this for initialization
    void Start() {
        //determines if persistent data exists...
        GameObject gameData = GameObject.Find("GameDataObject");
        //... if it does not, an object in which to store persistent data is created...
        if (gameData == null) {
            gameData = new GameObject("GameDataObject");
            gameData.AddComponent<GameData>();
            volume = 0.5f;
        } else {
            GameData gameDataScript = gameData.GetComponent<GameData>();
            volume = gameDataScript.masterVolume;
            gameDataScript.masterVolume = volume;
        }
    }

    // Update is called once per frame
    void Update() {
        //determines if persistent data exists, and the player's name, and the master volume are assigned from it to the private variables
        GameObject gameData = GameObject.Find("GameDataObject");
        if (gameData != null) {
            GameData gameDataScript = gameData.GetComponent<GameData>();
            gameDataScript.masterVolume = volume;
        }

        //updates the assigned the value of volume to the volume slider each frame to allow for live interaction between the player-modifed volume and the playing music
        //volume = volumeSlider.value;
    }
}
