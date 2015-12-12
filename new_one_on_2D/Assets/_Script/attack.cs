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

	void OnTouchDown(){
		PlayerPrefs.SetInt ("have_dark_jewel", 0);
		Instantiate (select_player, new Vector3 (0.0f, 0.0f, 0.0f), new Quaternion ());
	}
}
