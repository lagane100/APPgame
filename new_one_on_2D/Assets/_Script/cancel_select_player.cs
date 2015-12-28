using UnityEngine;
using System.Collections;

public class cancel_select_player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (!PhotonNetwork.isMasterClient) {
			Destroy(GameObject.FindGameObjectWithTag("choseWho"));
		}
	}

	void OnTouchDown(){
		Destroy(GameObject.FindGameObjectWithTag("choseWho"));
	}
}
