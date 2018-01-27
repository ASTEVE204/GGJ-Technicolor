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
        //set emitters to no particle effect
	}
	
	// Update is called once per frame
	void Update () {
        if (powerOn == true) {
            //set emitters to have particle effect
        } else {
            //set emitters to no particle effect
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
