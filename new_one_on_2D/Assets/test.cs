using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	private TextMesh testing;

	void Update(){
		testing = GameObject.FindGameObjectWithTag("press to continue").GetComponent<TextMesh>();
	}
	void OnTouchDown(){
		testing.text = "12345";
	}
}
