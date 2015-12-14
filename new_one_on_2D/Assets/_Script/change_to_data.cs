using UnityEngine;
using System.Collections;

public class change_to_data : MonoBehaviour {

	public string data_level;
	public GameObject loading_prefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchDown(){
		Instantiate(loading_prefab,new Vector3(0.0f,0.0f,0.0f),new Quaternion());
		PlayerPrefs.SetString("nextlevel",data_level);
		PlayerPrefs.SetInt("call_loading",1);
	}
}
