using UnityEngine;
using System.Collections;

public class card_selected : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchDown(){
		transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
	}
}
