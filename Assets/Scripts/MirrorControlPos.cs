using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorControlPos : MonoBehaviour {

    //If mirror is to move horizontally or vertically
    public bool vertical = true;

    //Maximum x- or y-coordinate of parent to reach
    public float maxPoint;

    //Mirror to be moved (parent)
    public GameObject mirror;

    //TV switch script to reference
    public TellyControl tellyControl;

    // Use this for initialization
    void Start() {

    }
	
	// Update is called once per frame
	void Update() {

	}

    void OnMouseDown() {
        if (tellyControl.powerOn == false) {
            //determines if persistent data exists; displays the player's name, health and score values, and calculates a final score from it; then assigns the information to different text fields
            GameObject gameData = GameObject.Find("GameDataObject");
            if (gameData != null) {
                GameData gameDataScript = gameData.GetComponent<GameData>();
                gameDataScript.totalClicks++;
            }
            Vector3 clickedPos = mirror.transform.position;
            if (vertical == true) {
                if (clickedPos.y < maxPoint - 0.1f) {
                    mirror.transform.position = new Vector3(clickedPos.x, clickedPos.y + 0.5f, clickedPos.z);
                }
            } else {
                if (clickedPos.x < maxPoint - 0.1f) {
                    mirror.transform.position = new Vector3(clickedPos.x + 0.5f, clickedPos.y, clickedPos.z);
                }
            }
        }
    }
}
