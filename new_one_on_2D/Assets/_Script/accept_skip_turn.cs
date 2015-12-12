using UnityEngine;
using System.Collections;

public class accept_skip_turn : MonoBehaviour {

	private GameObject end_turn_prefab;
	// Use this for initialization
	void Start () {
		end_turn_prefab = GameObject.FindGameObjectWithTag("skipTurn");
	}

	void OnTouchDown(){
		//code to Send WWW message
		if (end_turn_prefab) {
			Destroy(end_turn_prefab);
		}
	}
}
