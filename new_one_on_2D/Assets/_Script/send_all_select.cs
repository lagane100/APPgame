using UnityEngine;
using System.Collections;

public class send_all_select : MonoBehaviour {

	private Color selected_color = new Color();
	// Use this for initialization
	void Start () {
		ColorUtility.TryParseHtmlString ("#B2B6B6FF", out selected_color);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Send all selected player to server
	void OnTouchDown(){

	}
}
