using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Camera_touchInput : MonoBehaviour {

	private TextMesh test;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		test = GameObject.FindGameObjectWithTag("press to continue").GetComponent<TextMesh>();
		test.text = ""+Input.touchCount;
		//input.touchcount returns the number of the point is now touching
	}
}
