using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour {

    //Plane displaying 'tv snow'
    public GameObject snow;

    //Boolean changes if correct particles hit the object
    public bool levelComplete = false;

    //Audio for level success
    public AudioClip sound;

    IEnumerator LevelCompleted() {
        yield return new WaitForSeconds(0.5f);
        GetComponent<AudioSource>().PlayOneShot(sound);
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        snow.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        Application.LoadLevel("EndGame");
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (levelComplete == true) {
            GetComponent<Collider>().enabled = false;
            levelComplete = false;
            StartCoroutine("LevelCompleted");
        }
    }

    //check the tag of the particles hitting the prism
    void OnParticleCollision(GameObject other) {
        if (other.tag == "EndParticles") {
            levelComplete = true;
        }
    }
}
