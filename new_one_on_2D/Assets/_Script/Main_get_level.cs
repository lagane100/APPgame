using UnityEngine;
using System.Collections;

public class Main_get_level : MonoBehaviour {

	private string level;
	private TextMesh level_text;
	
	// Use this for initialization
	void Start () {
		level = PlayerPrefs.GetInt("level") + " ";
		level_text = GameObject.FindGameObjectWithTag ("level").GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		level_text.text = level;
	}
}
