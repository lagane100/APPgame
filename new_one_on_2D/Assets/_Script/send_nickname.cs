using UnityEngine;
using System.Collections;

public class send_nickname : MonoBehaviour {
	private GameObject textfield;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchDown(){
		textfield = GameObject.FindGameObjectWithTag ("textfield");
		textfield.SendMessage ("register_new", SendMessageOptions.DontRequireReceiver);
	}
}
