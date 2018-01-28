using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndGame : MonoBehaviour {

    //the variables declared as public are defined in the Unity Editor, the variable left private is used to store data below
    public AudioClip buttonClick;
    public AudioClip textClick;
    public AudioClip textStamp;
    public Button mainMenu;
    public Text buttonText;
    public Text subjectName;
    public Text scoringInfo;
    public Text finalScore;
    public Text terminated;
    int a;

    //processes and displays from persistent data while playing audio
    IEnumerator AudioAndStamp() {
        //determines if persistent data exists; displays the player's name, health and score values, and calculates a final score from it; then assigns the information to different text fields
        GameObject gameData = GameObject.Find("GameDataObject");
        if (gameData != null) {
            GameData gameDataScript = gameData.GetComponent<GameData>();
            subjectName.text = "Subject " + gameDataScript.playerName;
            scoringInfo.text = "Score: " + gameDataScript.cumulativeScore.ToString() + "\nHealth level: " + gameDataScript.playerHealth.ToString() + "\nObstacles Destroyed: " + gameDataScript.targetsDestroyed.ToString();
            int b = gameDataScript.targetsDestroyed * gameDataScript.playerHealth;
            a = gameDataScript.cumulativeScore + b;
            finalScore.text = "Total Score: " + a.ToString();
        }
        //delays between displaying information by enabling text fields (accompanied by audio) that were disabled in the Start method
        yield return new WaitForSeconds(1.5f);
        scoringInfo.enabled = true;
        //audio.PlayOneShot(textClick);
        //yield return new WaitForSeconds(audio.clip.length + 1.5f);
        finalScore.enabled = true;
        //audio.PlayOneShot(textClick);
        //yield return new WaitForSeconds(audio.clip.length + 2.0f);
        terminated.enabled = true;
        //audio.PlayOneShot(textStamp);
        //yield return new WaitForSeconds(audio.clip.length + 1.5f);
        //when all necessary text fields are enabled, the button to return to the main menu is activated
        buttonText.enabled = true;
        mainMenu.interactable = true;
    }

    //plays an audio clip and then switches to the main menu when a button is clicked
    IEnumerator MenuAfterAudio() {
        //audio.PlayOneShot(buttonClick);
        yield return new WaitForSeconds(/*audio.clip.length*/1);
        Application.LoadLevel("MainMenu");
    }

    //starts the corresponding coroutine when the button to which it is assigned is clicked
    public void LoadMainMenu() {
        StartCoroutine(MenuAfterAudio());
    }

    // Use this for initialization
    void Start() {
        //determines if persistent data exists...
        GameObject musicObject = GameObject.Find("MusicObject");
        if (musicObject != null) {
            MusicControl musicScript = musicObject.GetComponent<MusicControl>();
            musicScript.gameLevel = false;
        }
        //deactivates the specified text fields and buttons on initialisation, then starts the corresponding coroutine
        mainMenu.interactable = false;
        buttonText.enabled = false;
        scoringInfo.enabled = false;
        finalScore.enabled = false;
        terminated.enabled = false;
        StartCoroutine(AudioAndStamp());
    }

    // Update is called once per frame
    void Update() {

    }
}
