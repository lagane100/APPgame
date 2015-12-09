﻿using UnityEngine;
using System.Collections;

public class victory : MonoBehaviour {

	private TextMesh t;
	private Color change_color = new Color();

	// Use this for initialization
	void Start () {
		t = GameObject.FindGameObjectWithTag ("testTextMesh").GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<SpriteRenderer>().color = change_color;
		if(PlayerPrefs.GetInt("have_dark_jewel") == 1){
			ColorUtility.TryParseHtmlString ("#9D5C5CFF", out change_color);
		}
		if (PlayerPrefs.GetInt ("have_dark_jewel") == 0) {
			ColorUtility.TryParseHtmlString ("#FFFFFF", out change_color);
		}
	}

	void OnTouchDown(){
		t.text = "test";
		PlayerPrefs.SetInt ("have_dark_jewel", 1);
	}
}