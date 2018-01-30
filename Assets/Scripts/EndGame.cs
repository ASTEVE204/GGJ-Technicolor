using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndGame : MonoBehaviour {
    
    //Buttons that will appear depending on level completed
    public GameObject next;
    public GameObject menu;

    //Textures that will appear depending on number of moves in level completed; background they are applied to
    public Texture bitchin;
    public Texture groovy;
    public RawImage background;

    //Message showing number of moves used to complete the level
    public Text complete;

    //The next scene to show
    public int noOfLevels;
    string nextScene;

    //Audio clips to be assigned in Editor
    public AudioClip button;
    public AudioClip groovySound;
    public AudioClip bitchinSound;
    
    //Audio clip to be used as level reaction
    AudioClip sound;

    //processes and displays from persistent data while playing audio
    IEnumerator DisplayResults() {
        GetComponent<AudioSource>().PlayOneShot(sound);
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        //delays between displaying information by enabling text fields (accompanied by audio) that were disabled in the Start method
        yield return new WaitForSeconds(1.5f);
        if (nextScene != "MainMenu") {
            next.SetActive(true);
        } else {
            menu.SetActive(true);
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
        GetComponent<AudioSource>().PlayOneShot(button);
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        Application.LoadLevel(nextScene);
    }

    //starts the corresponding coroutine when the button to which it is assigned is clicked
    public void LoadNext() {
        StartCoroutine(NextAfterAudio());
    }

    // Use this for initialization
    void Start() {
        //determines if persistent data exists...
        GameObject musicObject = GameObject.Find("MusicObject");
        if (musicObject != null) {
            MusicControl musicScript = musicObject.GetComponent<MusicControl>();
            musicScript.gameLevel = false;
        }
        //determines if persistent data exists...
        GameObject gameData = GameObject.Find("GameDataObject");
        if (gameData != null) {
            GameData gameDataScript = gameData.GetComponent<GameData>();
            string tempS = gameDataScript.lastLevel;
            int tempI = 0;
            if (tempS.Length == 7) {
                tempI = int.Parse(tempS[6].ToString());
            } else if (tempS.Length == 8) {
                tempI = int.Parse((tempS[6].ToString()+tempS[7].ToString()));
            } else if (tempS.Length == 9) {
                tempI = int.Parse((tempS[6].ToString()+tempS[7].ToString()+tempS[8].ToString()));
            }
            if (gameDataScript.totalClicks == gameDataScript.minClicks) {
                background.texture = bitchin;
                sound = bitchinSound;
            } else {
                background.texture = groovy;
                sound = groovySound;
            }
            if (tempI + 1 > noOfLevels) {
                nextScene = "MainMenu";
            } else {
                nextScene = "Level " + (tempI + 1).ToString();
            }
            complete.text = "level completed\nin " + gameDataScript.totalClicks.ToString() + " moves";
        }
        StartCoroutine(DisplayResults());
    }

    // Update is called once per frame
    void Update() {

    }
}
