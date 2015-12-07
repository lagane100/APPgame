using UnityEngine;
using System.Collections;

public class ask_nickname_script : MonoBehaviour {

	public GameObject textfield;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < 1.5) {
			gameObject.transform.position += new Vector3 (0.0f, 0.03f, 0.0f);
		}
		if (gameObject.transform.position.y > 1.0) {
				textfield.SetActive(true);
		}
	}
}
