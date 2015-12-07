using UnityEngine;
using System.Collections;

public class main_get_exp : MonoBehaviour {

	private string EXP;
	private TextMesh EXP_text;

	// Use this for initialization
	void Start () {
		EXP = PlayerPrefs.GetInt("EXP") + "%";
		EXP_text = GameObject.FindGameObjectWithTag ("exp").GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		EXP_text.text = EXP;
	}
}
