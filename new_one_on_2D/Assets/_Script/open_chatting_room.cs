using UnityEngine;
using System.Collections;

public class open_chatting_room : MonoBehaviour {

	private GameObject chatroom;
	// Use this for initialization
	void Start () {
		chatroom = GameObject.FindGameObjectWithTag("chatroom");
		chatroom.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchDown(){
		chatroom.SetActive (!chatroom.activeSelf);
	}
}
