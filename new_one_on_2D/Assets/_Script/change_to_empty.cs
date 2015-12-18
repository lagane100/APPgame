using UnityEngine;
using System.Collections;

public class change_to_empty : MonoBehaviour {

	public Sprite empty;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.childCount == 0) {
			gameObject.GetComponent<SpriteRenderer>().sprite = empty;
		}
	}
}
