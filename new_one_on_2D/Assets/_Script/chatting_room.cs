using UnityEngine;
using System.Collections;

public class chatting_room : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			if (PhotonNetwork.room != null) {
				foreach (PhotonPlayer player in PhotonNetwork.playerList) {
					Debug.Log (player.name);
				}
			}
		}
	}

	void OnTouchDown(){

	}
}
