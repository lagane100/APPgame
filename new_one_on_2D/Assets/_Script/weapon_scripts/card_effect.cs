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
		if (transform.localScale.x > biggest_scale.x) {
			Counter++;
		}
		if (Counter == 0) {
			transform.localScale += new Vector3(0.05f,0.05f,0.05f);
		}
		if (Counter == 1) {
			transform.localScale -= new Vector3(0.05f,0.05f,0.05f);
		}
		if (Counter == 1 && transform.localScale.x < 0.75f) {
			Counter++;
			transform.localScale = new Vector3(0.75f,0.75f,1.0f);
		}
	}
}