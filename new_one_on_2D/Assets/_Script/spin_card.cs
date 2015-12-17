using UnityEngine;
using System.Collections;

public class spin_card : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		/*gameObject.transform.Rotate(0,10 * Time.deltaTime,0);
		Debug.Log (transform.rotation.y);*/
		if (transform.rotation.y > 0.7 || transform.rotation.y < -0.7) {
			Debug.Log (transform.rotation.y);
			GameObject.Find ("background").GetComponent<SpriteRenderer>().sortingOrder = 3;
		}
		else{
			GameObject.Find("background").GetComponent<SpriteRenderer>().sortingOrder = 0;
		}
	}
}
