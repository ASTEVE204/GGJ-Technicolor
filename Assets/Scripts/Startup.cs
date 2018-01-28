using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Startup : MonoBehaviour {
	
	public RawImage background;
	public RawImage fadefromBlack;
	public Color black;
	public Color clear;
	public Texture ggjSplash;
	public Texture teamSplash;
	public Texture gameSplash;

	IEnumerator StartUpGame() {
		background.texture = ggjSplash;
		yield return new WaitForSeconds(1);
		fadeFromBlack.color = black;
		background.texture = teamSplash;
		yield return new WaitForSeconds(1);
		fadeFromBlack.color = black;
		background.texture = gameSplash;
		yield return new WaitForSeconds(1);
		background.color = black;
		Application.LoadLevel("MainMenu");
	}
	
	// Use this for initialization
	void Start () {
		StartCoroutine("StartUpGame");
	}
	
	// Update is called once per frame
	void Update () {
		if (fadeFromBlack.color != clear) {
			fadeFromBlack.color = Color.Lerp(black, clear, Mathf.PingPong(Time.time, 1));
		}
	}
}
