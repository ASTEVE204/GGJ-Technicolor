using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndGame : MonoBehaviour {

    //the variables declared as public are defined in the Unity Editor, the variable left private is used to store data below
    public Button next;
    public Button menu;
    public Texture bitchin;
    public Texture groovy;
    public RawImage background;
    public Text complete;
    int clicks;
    string nextScene;

    //processes and displays from persistent data while playing audio
    IEnumerator AudioAndStamp() {
        //determines if persistent data exists; displays the player's name, health and score values, and calculates a final score from it; then assigns the information to different text fields
        GameObject gameData = GameObject.Find("GameDataObject");
        if (gameData != null) {
            GameData gameDataScript = gameData.GetComponent<GameData>();
            clicks = gameDataScript.totalClicks;
        }
        //delays between displaying information by enabling text fields (accompanied by audio) that were disabled in the Start method
        complete.text = "level completed\nin " + clicks.ToString() + " clicks";
        yield return new WaitForSeconds(1.5f);
        if (nextScene != "MainMenu") {
            next.enabled = true;
        } else {
            menu.enabled = true;
        }
    }

    //plays an audio clip and then switches to the main menu when a button is clicked
    IEnumerator NextAfterAudio() {
        //determines if persistent data exists; displays the player's name, health and score values, and calculates a final score from it; then assigns the information to different text fields
        GameObject gameData = GameObject.Find("GameDataObject");
        if (gameData != null) {
            GameData gameDataScript = gameData.GetComponent<GameData>();
            gameDataScript.totalClicks = 0;
        }
        //audio.PlayOneShot(buttonClick);
        yield return new WaitForSeconds(/*audio.clip.length*/1);
        Application.LoadLevel(nextScene);
    }

    //starts the corresponding coroutine when the button to which it is assigned is clicked
    public void LoadNext() {
        StartCoroutine(NextAfterAudio());
    }

    // Use this for initialization
    void Start() {
        next.enabled = false;
        menu.enabled = false;
        //determines if persistent data exists...
        GameObject musicObject = GameObject.Find("MusicObject");
        if (musicObject != null) {
            MusicControl musicScript = musicObject.GetComponent<MusicControl>();
            musicScript.gameLevel = false;
        }
        //determines if persistent data exists...
        GameObject gameData = GameObject.Find("GameData");
        if (gameData != null) {
            GameData gameDataScript = gameData.GetComponent<GameData>();
            if (gameDataScript.lastLevel == "Level 1") {
                nextScene = "Level 2";
                background.texture = groovy;
                StartCoroutine(AudioAndStamp());
            } else if (gameDataScript.lastLevel == "Level 2") {
                nextScene = "Level 3";
                background.texture = groovy;
                StartCoroutine(AudioAndStamp());
            } else if (gameDataScript.lastLevel == "Level 3") {
                nextScene = "MainMenu";
                background.texture = bitchin;
                StartCoroutine(AudioAndStamp());
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
