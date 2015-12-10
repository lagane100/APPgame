using UnityEngine;
using System.Collections;

public class end : MonoBehaviour {
	
	public GameObject end_turn_prefab;

	//end the player turn
	void OnTouchDown(){
		Instantiate (end_turn_prefab, new Vector3 (0.0f, 0.0f, 0.0f), new Quaternion ());
	}	
}
