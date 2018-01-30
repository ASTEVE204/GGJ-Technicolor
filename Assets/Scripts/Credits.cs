using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {

    //Audio for buttons
    public AudioClip sound;

    //plays an audio clip and then switches to the main level when a button is clicked
    IEnumerator MenuAfterAudio() {
        GetComponent<AudioSource>().PlayOneShot(sound);
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        Application.LoadLevel("MainMenu");
    }

    //starts the corresponding coroutine when the button to which it is assigned is clicked
    public void BackToMenu()
    {
        StartCoroutine(MenuAfterAudio());
    }

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }
}
