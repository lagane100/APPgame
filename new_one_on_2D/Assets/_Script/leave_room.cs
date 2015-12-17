using UnityEngine;
using System.Collections;

public class leave_room : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (PhotonNetwork.room.name);
	}

	void OnTouchDown(){
		PhotonNetwork.LeaveRoom ();
		Destroy (transform.parent.gameObject);
	}
}
