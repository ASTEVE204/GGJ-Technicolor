using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TellyControl : MonoBehaviour {

    //Game Object for emitters
    public GameObject redLaser;
    public GameObject greenLaser;
    public GameObject blueLaser;

    //Boolean for on/off switch
    public bool powerOn = false;

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

    void OnMouseDown () {
        GameObject powerSwitch = this.gameObject;
        if (powerOn == false) {
            powerSwitch.transform.eulerAngles = new Vector3(0, -11.25f, 0);
            powerOn = true;
        } else {
            powerSwitch.transform.eulerAngles = new Vector3(0, 11.25f, 0);
            powerOn = false;
        }
    }
}
