using UnityEngine;
using System.Collections;

public class eject_skin_turn : MonoBehaviour {

	private GameObject end_turn_prefab;
	// Use this for initialization
	void Start () {
		end_turn_prefab = GameObject.FindGameObjectWithTag("skipTurn");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchDown(){
		if (end_turn_prefab) {
			Destroy (end_turn_prefab);
		}
	}
}
