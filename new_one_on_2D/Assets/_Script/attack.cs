using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {

	public GameObject select_player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//start attack
	void OnTouchDown(){
		if (PhotonNetwork.isMasterClient) {
			GameObject selector = Instantiate (select_player, new Vector3 (0.0f, 0.0f, 0.0f), new Quaternion ()) as GameObject;
			selector.transform.parent = gameObject.transform;
		}
	}

	void StartDoStuff(){
		Debug.Log (12345);
	}
}
