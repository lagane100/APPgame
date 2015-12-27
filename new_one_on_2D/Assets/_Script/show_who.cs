using UnityEngine;
using System.Collections;

public class show_who : MonoBehaviour {

	public GameObject red;
	public GameObject blue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchDown(){
		if (PlayerPrefs.GetString ("states").Equals ("red")) {
			Instantiate(red,new Vector3(0.0f,0.0f,0.0f),new Quaternion());
		}
		if (PlayerPrefs.GetString ("states").Equals ("blue")) {
			Instantiate(blue,new Vector3(0.0f,0.0f,0.0f),new Quaternion());
		}
	}
}
