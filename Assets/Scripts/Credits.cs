using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {

    //plays an audio clip and then switches to the main level when a button is clicked
    IEnumerator MenuAfterAudio()
    {
        //audio.Play();
        yield return new WaitForSeconds(/*audio.clip.length*/1);
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
