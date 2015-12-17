using UnityEngine;
using System.Collections;

public class add_to_room : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchDown(){
		PhotonNetwork.JoinRandomRoom ();
	}
}
