using UnityEngine;
using System.Collections;

public class card_effect : MonoBehaviour {

	private Vector3 biggest_scale = new Vector3(2.0f,2.0f,2.0f);
	private int Counter = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localScale == biggest_scale) {
			Counter++;
		}
		if (Counter == 0) {
			transform.localScale += new Vector3(0.05f,0.05f,0.05f);
		}
		if (Counter == 1) {
			transform.localScale -= new Vector3(0.05f,0.05f,0.05f);
		}
		if (Counter == 1 && transform.localScale == new Vector3 (1.0f, 1.0f, 1.0f)) {
			this.enabled = false;
		}
	}
}