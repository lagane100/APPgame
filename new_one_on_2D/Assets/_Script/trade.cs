﻿using UnityEngine;
using System.Collections;

public class trade : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// start trading
	void OnTouchDown(){
		GameObject.FindGameObjectWithTag("testTextMesh").GetComponent<TextMesh>().text = "test";
	}
}