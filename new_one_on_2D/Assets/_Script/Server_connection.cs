using UnityEngine;
using System.Collections;

public class Server_connection : MonoBehaviour {

	private RuntimePlatform platform = Application.platform;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (platform == RuntimePlatform.Android) {
			if (Input.touchCount > 0) {
				//PlayerPrefs.
			}
		}
	}
}
