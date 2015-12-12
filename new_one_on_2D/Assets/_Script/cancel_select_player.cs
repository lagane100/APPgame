using UnityEngine;
using System.Collections;

public class cancel_select_player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchDown(){
		Destroy(GameObject.FindGameObjectWithTag("choseWho"));
	}
}
