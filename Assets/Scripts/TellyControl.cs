using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TellyControl : MonoBehaviour {

    //Array of prism scripts
    public PrismSpawn[] prismSpawns;

    //Game Object for emitters
    public GameObject redLaser;
    public GameObject greenLaser;
    public GameObject blueLaser;

    //Boolean for on/off switch
    public bool powerOn = false;

    //Audio for on/off switch
    public AudioClip sound;

    IEnumerator OnOff() {
        GetComponent<AudioSource>().PlayOneShot(sound);
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
    }

    // Use this for initialization
    void Start () {
        //particle lasers will be turned off
        redLaser.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
        greenLaser.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
        blueLaser.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (powerOn == true) {
            //if the power switch is toggled on, particle lasers will be turned on
            redLaser.gameObject.GetComponent<ParticleSystem>().enableEmission = true;
            greenLaser.gameObject.GetComponent<ParticleSystem>().enableEmission = true;
            blueLaser.gameObject.GetComponent<ParticleSystem>().enableEmission = true;
        } else {
            //if the power switch is toggled off, particle lasers will be turned off
            redLaser.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
            greenLaser.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
            blueLaser.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
        }
    }

    //When clicking on the switch
    void OnMouseDown () {
        StartCoroutine(OnOff());
         if (powerOn == false) {
            //turn the TV on
            this.gameObject.transform.eulerAngles = new Vector3(-90f, 0, -32.773f);
            powerOn = true;
            //and refill the list of colours still to hit the prism
            foreach (PrismSpawn prismSpawn in prismSpawns) {
                prismSpawn.MakeTheList();
            }
        } else {
            //turn the TV off
            this.gameObject.transform.eulerAngles = new Vector3(-90f, 0, 32.773f);
            powerOn = false;
            //and clear out the list of colours still to hit the prism
            foreach (PrismSpawn prismSpawn in prismSpawns) {
                prismSpawn.remaingColours.Clear();
            }
        }
    }
}
