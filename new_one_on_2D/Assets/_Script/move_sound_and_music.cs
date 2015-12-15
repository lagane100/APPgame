using UnityEngine;
using System.Collections;

public class move_sound_and_music : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchStay(Vector3 hitpoint){
		if (hitpoint.x > -1.1f && hitpoint.x < 2.45f && hitpoint.y > 3.65f && hitpoint.y < 3.95f) {
			GameObject.Find("sound").transform.position = new Vector3(hitpoint.x,3.8f,0.0f);
		}

		if (hitpoint.x > -1.1f && hitpoint.x < 2.45f && hitpoint.y > 1.55f && hitpoint.y < 1.85f) {
			GameObject.Find("music").transform.position = new Vector3(hitpoint.x,1.7f,0.0f);
		}
	}
}
