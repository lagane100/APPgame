using UnityEngine;
using System.Collections;

public class join_room : MonoBehaviour {

	private string text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		text = gameObject.GetComponent<TextMesh> ().text;
	}
	
	void OnTouchDown(){
		Debug.Log (text);
		PhotonNetwork.JoinRoom (text);
	}
	
	void OnJoinedRoom(){
		Debug.Log ("JoinedRoom");
	}
}
