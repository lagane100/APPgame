using UnityEngine;
using System.Collections;

public class set_hands_place : MonoBehaviour {

	private int count;
	private float range;
	private float for_x;
	private Transform[] childrens;

	// Use this for initialization
	void Start () {
		childrens = GetComponentsInChildren<Transform> ();
		count = transform.childCount;
		Debug.Log (count);
		if (count < 6) {
			range = (float)4 / (count - 1);
			Debug.Log(range);
			for(int i = 0; i<childrens.Length;i++){
				if(i != 0){
					childrens[i].localPosition = new Vector3(-2.0f + (i-1) * range,-1.0f,0.0f);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
