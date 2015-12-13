using UnityEngine;
using System.Collections;

public class set_button_unclicked : MonoBehaviour {
	private GameObject[] buttons = new GameObject[4];

	// Start is called once per script
	void Start(){
		buttons[0] = GameObject.Find("attack");
		buttons[1] = GameObject.Find("trade");
		buttons[2] = GameObject.Find("end");
		buttons[3] = GameObject.Find ("victory");
	}

	// Update is called once per frame
	void Update(){
		if (!GameObject.FindGameObjectWithTag ("choseWho") && !GameObject.FindGameObjectWithTag ("skipTurn")) {
			foreach (GameObject g in buttons) {
				g.GetComponent<BoxCollider> ().enabled = true;
			}
		} else {
			foreach(GameObject g in buttons){
				g.GetComponent<BoxCollider>().enabled = false;
			}
		}
	}
}
