using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobControl : MonoBehaviour {

    //Game Object for emitters
    public GameObject laser;

    //Rotation of control knob and emitter
    public Quaternion rot;

    //TV switch script to reference
    public TellyControl tellyControl;

    //Use this for initialization
    void Start () {
        rot = transform.rotation;
	}
	
	//Update is called once per frame
	void Update () {
        //Rotations for knobs and emitters are updated
        rot = transform.rotation;
        laser.transform.rotation = rot;
    }

    //For turning the knobs
    void OnMouseDown () {
        //Knob, when tapped, rotates by 22.5° around y-axis
        if (tellyControl.powerOn == false) {
            GameObject knob = this.gameObject;
            Vector3 clickedEuler = knob.transform.eulerAngles;
            if (clickedEuler.y < 157.5f) {
                knob.transform.eulerAngles = new Vector3(0, clickedEuler.y + 22.5f, 0);
            } else {
                knob.transform.eulerAngles = new Vector3(0, 22.5f, 0);
            }
            rot = knob.transform.rotation;
        }
    }
}
