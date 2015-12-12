using UnityEngine;
using System.Collections;

public class trade : MonoBehaviour {

	public GameObject select_player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// start trading
	void OnTouchDown(){
		Instantiate (select_player, new Vector3 (0.0f, 0.0f, 0.0f), new Quaternion ());
	}
}
