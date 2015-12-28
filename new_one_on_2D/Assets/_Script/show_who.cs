using UnityEngine;
using System.Collections;

public class show_who : MonoBehaviour {

	public GameObject red;
	public GameObject blue;
	private bool counter = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (counter) {
			foreach (Transform child in transform) {
				child.gameObject.SetActive (false);
			}
		} else{
			foreach(Transform child in transform){
				child.gameObject.SetActive(true);
			}
		}
	}

	void OnTouchDown(){
		if (PlayerPrefs.GetString ("states").Equals ("red")) {
			Instantiate(red,new Vector3(0.0f,0.0f,0.0f),new Quaternion());
		}
		if (PlayerPrefs.GetString ("states").Equals ("blue")) {
			Instantiate(blue,new Vector3(0.0f,0.0f,0.0f),new Quaternion());
		}
		counter = !counter;
	}
}
