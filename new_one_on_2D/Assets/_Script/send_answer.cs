using UnityEngine;
using System.Collections;

public class send_answer : MonoBehaviour {

	private Color selected_color = new Color();
	private Color origin_color = new Color();

	void Awake(){
		while (GameObject.Find("nickname") != null) {
			GameObject.Find ("nickname").GetComponent<MeshRenderer>().sortingOrder = 4;
			GameObject.Find ("nickname").name = "nicknameChanged";
		}
	}

	// Use this for initialization
	void Start () {
		ColorUtility.TryParseHtmlString ("#B2B6B6FF", out selected_color);
		ColorUtility.TryParseHtmlString ("#FFFFFFFF", out origin_color);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
