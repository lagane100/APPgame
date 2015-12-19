using UnityEngine;
using System.Collections;

public class click_destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchDown(){
		Destroy (gameObject);
	}
}
