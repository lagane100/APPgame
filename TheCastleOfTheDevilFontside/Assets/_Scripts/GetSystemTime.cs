using UnityEngine;
using System.Collections;
using System;

public class GetSystemTime : MonoBehaviour {
	public TextMesh text;
	
	// Update is called once per frame
	void Update () {
		text = (TextMesh)GetComponent ("TextMesh");
		text.text = DateTime.Now.ToString("HH:mm");
	}
}
