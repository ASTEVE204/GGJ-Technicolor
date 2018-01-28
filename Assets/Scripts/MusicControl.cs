using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour {

    public bool gameLevel;
    static bool musicPlaying = false;

    // Use this for initialization
    void Start() {
        //if the boolean above is false, music is played, the boolean is declared to be true, and the object containing the script is ensured to not be destroyed when the scene changes
        if (!musicPlaying) {
            audio.Play();
            audio.mute = false;
            DontDestroyOnLoad(this);
            musicPlaying = true;
        }
    }

    // Update is called once per frame
    void Update() {
        //if the last loaded level is not the main game level, the background music is not muted
        if (gameLevel == false) {
            audio.mute = false;
        }
        if (gameLevel == true) {
            audio.mute = true;
        }
    }
}
