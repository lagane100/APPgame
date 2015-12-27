using UnityEngine;
using System.Collections;

public class set_using : MonoBehaviour {
	private GameObject[] four_buttons; 

	// Use this for initialization
	void Start () {
		four_buttons = new GameObject[4];
		four_buttons [0] = GameObject.Find ("trade");
		four_buttons [1] = GameObject.Find ("attack");
		four_buttons [2] = GameObject.Find ("victory");
		four_buttons [3] = GameObject.Find ("end");
	}
	
	// Update is called once per frame
	void Update () {
		if (!PhotonNetwork.isMasterClient) {
			foreach (GameObject g in four_buttons) {
				g.GetComponent<BoxCollider>().enabled = false;
			}
		} else {
			foreach(GameObject g in four_buttons){
				g.GetComponent<BoxCollider>().enabled = true;
			}
		}
	}
}
