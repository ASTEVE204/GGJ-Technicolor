﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Startup : MonoBehaviour {
	
	public RawImage background;
	public Texture ggjSplash;
	public Texture teamSplash;
	public Texture gameSplash;
    public Text presenting;

	IEnumerator StartUpGame() {
        background.color = Color.black;
        yield return new WaitForSeconds(0.1f);
        background.color = Color.white;
        background.texture = ggjSplash;
		yield return new WaitForSeconds(2.1f);
        background.texture = teamSplash;
        presenting.enabled = true;
        yield return new WaitForSeconds(3.9f);
        presenting.enabled = false;
        background.texture = gameSplash;
		yield return new WaitForSeconds(3.65f);
		Application.LoadLevel("MainMenu");
	}
	
	// Use this for initialization
	void Start () {
        presenting.enabled = false;
        //determines if persistent data exists...
        GameObject musicObject = GameObject.Find("MusicObject");
        if (musicObject != null)
        {
            MusicControl musicScript = musicObject.GetComponent<MusicControl>();
            musicScript.gameLevel = false;
        }
        StartCoroutine("StartUpGame");
	}
	
	// Update is called once per frame
	void Update () {

	}
}
