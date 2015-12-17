using UnityEngine;
using System.Collections;

public class set_hands_place : MonoBehaviour {

	private int count;
	private float range;
	private float for_x;
	private Transform[] childrens;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		childrens = GetComponentsInChildren<Transform> ();
		count = transform.childCount;
		if (count == 1) {
			childrens [1].localPosition = new Vector3 (0.0f, -1.0f, 0.0f);
		} else if (count < 6) {
			range = (float)4 / (count - 1);
			for (int i = 0; i<childrens.Length; i++) {
				if (i % 3 == 1) {
					childrens [i].localPosition = new Vector3 (-2.0f + (i / 3) * range, -1.0f, 0.0f);
				}
			}
		} else {
			//give one hand to others
		}
	}
}
