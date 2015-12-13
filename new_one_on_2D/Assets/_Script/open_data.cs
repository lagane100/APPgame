using UnityEngine;
using System.Collections;

public class open_data : MonoBehaviour {

	public GameObject data_info;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchDown(){
		Instantiate (data_info, new Vector3 (0.0f, 0.0f, 0.0f), new Quaternion ());
	}
}
