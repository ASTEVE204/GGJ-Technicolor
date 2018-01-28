using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismSpawn : MonoBehaviour {

    //Boolean to check if win condition met
    bool levelComplete = false;

    //White light particle effect
    public GameObject whiteLight;

    //Array to store required colours for level completion
    public string[] allColours;

    //List to 'tick off' colours found
    public List<string> remaingColours;

	// Use this for initialization
	void Start () {
        remaingColours = new List<string>();
        whiteLight.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (levelComplete == true) {
            whiteLight.SetActive(true);
        } else {
            whiteLight.SetActive(false);
        }
	}

    //check the tag of the particles hitting the prism
    void OnParticleCollision (GameObject other) {
        string objectTag = other.tag;
        for (int i = 0; i < remaingColours.Count; i++) {
            //and remove them from the list of colours still to hit the prism
            if (objectTag == remaingColours[i]) {
                remaingColours.RemoveAt(i);
                //and if that clears out the list completely, trigger the endgame
                if (remaingColours == null) {
                    levelComplete = true;
                }
            }
        }
    }

    //refill the list of colours still to hit the prism
    public void MakeTheList () {
        foreach (string colour in allColours) {
            remaingColours.Add(colour);
        }
    }
}
