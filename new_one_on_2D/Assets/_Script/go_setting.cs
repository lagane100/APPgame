using UnityEngine;
using System.Collections;

public class go_setting : MonoBehaviour {

	public string setting_level;
	public GameObject loading_prefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//go to setting scene
	void OnTouchDown(){
		PlayerPrefs.SetString ("nextlevel", setting_level);
		PlayerPrefs.SetInt ("call_loading", 1);
		Instantiate(loading_prefab,new Vector3(0.0f,0.0f,0.0f),new Quaternion());
	}
}
