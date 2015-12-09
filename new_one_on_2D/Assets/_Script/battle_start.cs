using UnityEngine;
using System.Collections;

public class battle_start : MonoBehaviour {

	public string battle_prepare_level;
	public GameObject loading_prefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTouchDown(){
		PlayerPrefs.SetString ("nextlevel",battle_prepare_level);
		PlayerPrefs.SetInt ("call_loading",1);
		Instantiate(loading_prefab,new Vector3(0.0f,0.0f,0.0f),new Quaternion());
	}
}
