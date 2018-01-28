using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorControl : MonoBehaviour {

    //If mirror is to move horizontally or vertically
    public bool vertical = true;

    //Minimum & maximum x- or y-coordinates
    public float maxPoint;
    public float minPoint;

    //Buttons that control movement (children)
    public GameObject buttonP;
    public GameObject buttonN;

    //TV switch script to reference
    public TellyControl tellyControl;

    // Use this for initialization
    void Start() {

    }
	
	// Update is called once per frame
	void Update() {
        if (tellyControl.powerOn == false) {
            if (vertical == true) {
                if (this.gameObject.transform.position.y > maxPoint - 0.1f) {
                    buttonP.SetActive(false);
                    buttonN.SetActive(true);
                } else if (this.gameObject.transform.position.y < minPoint + 0.1f) {
                    buttonP.SetActive(true);
                    buttonN.SetActive(false);
                } else {
                    buttonP.SetActive(true);
                    buttonN.SetActive(true);
                }
            } else {
                if (this.gameObject.transform.position.x > maxPoint - 0.1f) {
                    buttonP.SetActive(false);
                    buttonN.SetActive(true);
                } else if (this.gameObject.transform.position.x < minPoint + 0.1f) {
                    buttonP.SetActive(true);
                    buttonN.SetActive(false);
                } else {
                    buttonP.SetActive(true);
                    buttonN.SetActive(true);
                }
            }
        } else {
            buttonP.SetActive(false);
            buttonN.SetActive(false);
        }
	}
}
