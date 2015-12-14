using UnityEngine;
using System.Collections;

public class card_selected : MonoBehaviour {

	private Vector3 origin_size = new Vector3 (0.75f, 0.75f, 0.75f);
	private Vector3 selected_size = new Vector3 (1.0f, 1.0f, 1.0f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchDown(){
		if (transform.localScale.x == origin_size.x) {
			transform.localScale = selected_size;
		}
		else if (transform.localScale.x == selected_size.x) {
			transform.localScale = origin_size;
		}
	}
}
