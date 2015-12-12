using UnityEngine;
using System.Collections;

public class send_all_select : MonoBehaviour {

	//private Color selected_color = new Color();
	private Color origin_color = new Color();
	private GameObject selected_player;

	// Do when script starts
	void Awake(){
		while (GameObject.Find("nickname") != null) {
			GameObject.Find ("nickname").GetComponent<MeshRenderer>().sortingOrder = 4;
			GameObject.Find ("nickname").name = "nicknameChanged";
		}
	}

	// Use this for initialization
	void Start () {
	//	ColorUtility.TryParseHtmlString ("#B2B6B6FF", out selected_color);
		ColorUtility.TryParseHtmlString ("#FFFFFFFF", out origin_color);
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	//Test playerstack
	void OnTouchUp(){
		Debug.Log (selected_player);
	}

	void CheckSelected(){
		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Player")) {
			if(selected_player != null){
				if(g.name != selected_player.name){
					g.GetComponent<SpriteRenderer>().color = origin_color;
				}
			}
		}
	}

	void UpdateSelected(GameObject g){
	/*	foreach (GameObject g in GameObject.FindGameObjectsWithTag("Player")) {
			if(g.GetComponent<SpriteRenderer>().color == selected_color){
				selected_player = g;
			}
		}*/
		selected_player = g;
	}

	void Clear(){
		selected_player = null;
	}
}
