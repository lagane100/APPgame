using UnityEngine;
using System.Collections;

public class victory : MonoBehaviour {

	private TextMesh t;

	// Use this for initialization
	void Start () {
		t = GameObject.FindGameObjectWithTag ("testTextMesh").GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		//9D5C5CFF
	}

	void OnTouchDown(){
		t.text = "test";
	}
}
