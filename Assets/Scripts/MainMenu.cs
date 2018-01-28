using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    //the variable declared as public to be defined in the Unity Editor, the variables left private are used to store data below
    public Text subjectName;
    float volume;
    string nameText;

    //plays an audio clip and then switches to the main level when a button is clicked
    IEnumerator MainLevelAfterAudio() {
        //determines if persistent data exists and assigns to it the data from the private variables
        GameObject gameData = GameObject.Find("GameDataObject");
        if (gameData != null) {
            GameData gameDataScript = gameData.GetComponent<GameData>();
            gameDataScript.playerName = nameText;
            gameDataScript.masterVolume = volume;

        }
        //audio.Play();
        yield return new WaitForSeconds(/*audio.clip.length*/1);
        Application.LoadLevel("Experiment1");
    }

    //plays an audio clip and then switches to the options menu when a button is clicked
    IEnumerator OptionsAfterAudio() {
        //determines if persistent data exists and assigns to it the data from the private variables
        GameObject gameData = GameObject.Find("GameDataObject");
        if (gameData != null) {
            GameData gameDataScript = gameData.GetComponent<GameData>();
            gameDataScript.playerName = nameText;
            gameDataScript.masterVolume = volume;
        }
        //audio.Play();
        yield return new WaitForSeconds(/*audio.clip.length*/1);
        Application.LoadLevel("Options");
    }

    //plays an audio clip and then exits the game when a button is clicked
    IEnumerator QuitAfterAudio() {
        //audio.Play();
        yield return new WaitForSeconds(/*audio.clip.length*/1);
        Application.Quit();
    }

    //starts the corresponding coroutine when the button to which it is assigned is clicked
    public void LoadMainLevel() {
        StartCoroutine(MainLevelAfterAudio());
    }

    //starts the corresponding coroutine when the button to which it is assigned is clicked
    public void LoadOptionsMenu() {
        StartCoroutine(OptionsAfterAudio());
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
            nameText = "89P13";
            volume = 0.5f;
            //... otherwise, the player's name and the master volume are assigned from it to the private variables
        } else {
            GameData gameDataScript = gameData.GetComponent<GameData>();
            nameText = gameDataScript.playerName;
            volume = gameDataScript.masterVolume;
            gameDataScript.masterVolume = volume;
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
        //assigns the player's name after the word 'Subject' to a text field
        subjectName.text = "Subject " + nameText;
    }

    // Update is called once per frame
    void Update() {
        //determines if persistent data exists, and the player's name, and the master volume are assigned from it to the private variables
        GameObject gameData = GameObject.Find("GameDataObject");
        if (gameData != null) {
            GameData gameDataScript = gameData.GetComponent<GameData>();
            gameDataScript.playerName = nameText;
            gameDataScript.masterVolume = volume;
        }
    }
}
