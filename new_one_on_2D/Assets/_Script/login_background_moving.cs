using UnityEngine;
using System.Collections;

public class login_background_moving : MonoBehaviour {
	public float speed;
	private int counter;

	// Start is called once per script
	void Start(){
	
	}

	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.x > 6.2 || gameObject.transform.position.x < -6.2) {
			counter = counter + 1;
		}
		if (counter % 2 == 1) {
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x - speed, gameObject.transform.position.y, gameObject.transform.position.z);
		} else {
			gameObject.transform.position = new Vector3 (gameObject.transform.position.x + speed, gameObject.transform.position.y, gameObject.transform.position.z);
		}
	}
}
