using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobControl : MonoBehaviour
{
    //If rotation is positive or negative
    public bool positive = true;

    //Game Object for emitters
    public GameObject emitter;

    //Rotation of control knob and emitter
    public float rot;

    //TV switch script to reference
    public TellyControl tellyControl;

    //Use this for initialization
    void Start() {
        rot = transform.eulerAngles.z;
    }

    //Update is called once per frame
    void Update() {
        //Rotations for knobs and emitters are updated
        if (positive == true) {
            emitter.transform.eulerAngles = new Vector3(emitter.transform.eulerAngles.x, emitter.transform.eulerAngles.y, rot);
        } else {
            emitter.transform.eulerAngles = new Vector3(emitter.transform.eulerAngles.x, emitter.transform.eulerAngles.y, rot * -1f);
        }
    }

    //For turning the knobs
    void OnMouseDown() {
        //Knob, when tapped, rotates by 22.5° around z-axis
        if (tellyControl.powerOn == false) {
            //determines if persistent data exists; displays the player's name, health and score values, and calculates a final score from it; then assigns the information to different text fields
            GameObject gameData = GameObject.Find("GameDataObject");
            if (gameData != null) {
                GameData gameDataScript = gameData.GetComponent<GameData>();
                gameDataScript.totalClicks++;
            }
            Vector3 clickedEuler = this.gameObject.transform.eulerAngles;
            if (clickedEuler.z < 157.5f) {
                this.gameObject.transform.eulerAngles = new Vector3(clickedEuler.x, clickedEuler.y, clickedEuler.z + 22.5f);
            } else {
                this.gameObject.transform.eulerAngles = new Vector3(clickedEuler.x, clickedEuler.y, 22.5f);
            }
            rot = this.gameObject.transform.eulerAngles.z;
        }
    }
}
