using UnityEngine;
using System.Collections;

public class let_background_stay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag ("waiting room")) {
			GameObject.Find ("create room").GetComponent<BoxCollider> ().enabled = false;
			GameObject.Find ("back to main").GetComponent<BoxCollider> ().enabled = false;
			GameObject.Find ("start battle").GetComponent<BoxCollider> ().enabled = false;
			GameObject.Find ("refresh").GetComponent<BoxCollider> ().enabled = false;
			GameObject.Find ("friends").GetComponent<BoxCollider> ().enabled = false;
		} else {
			GameObject.Find("create room").GetComponent<BoxCollider>().enabled = true;
			GameObject.Find("back to main").GetComponent<BoxCollider>().enabled = true;
			GameObject.Find("start battle").GetComponent<BoxCollider>().enabled = true;
			GameObject.Find("refresh").GetComponent<BoxCollider>().enabled = true;
			GameObject.Find("friends").GetComponent<BoxCollider>().enabled = true;
		}
	}
}
