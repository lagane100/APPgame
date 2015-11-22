using UnityEngine;
using System.Collections;

public class login_text_shine : MonoBehaviour {
	private float time;
	private bool isShow = false;

	// Use this for initialization
	void Start () {
		time = Time.time;
	}
	
	// Update is called once per frame
	void onGUI () {
		if ((Time.time - time > 0.2f) || (Time.time - time < 0.5f)) {
			isShow = true;
		} else if (Time.time - time > 0.5f) {
			time = Time.time;
			isShow = false;
		}
	}
}
