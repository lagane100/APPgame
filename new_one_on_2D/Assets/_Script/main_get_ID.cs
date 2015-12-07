using UnityEngine;
using System.Collections;

public class main_get_ID : MonoBehaviour {

	private string ID;
	private TextMesh ID_text;

	// Use this for initialization
	void Start () {
		ID = PlayerPrefs.GetString("nickname");
		ID_text = GameObject.FindGameObjectWithTag ("ID").GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		ID_text.text = ID;
	}
}
