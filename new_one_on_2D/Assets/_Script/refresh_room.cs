using UnityEngine;
using System.Collections;

public class refresh_room : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchDown(){
		foreach (GameObject g in GameObject.FindGameObjectsWithTag("defaultTextMesh")) {
			Destroy(g);
		}
		GameObject.Find ("room list").SendMessage ("OnReceivedRoomListUpdate", SendMessageOptions.DontRequireReceiver);
	}
}
