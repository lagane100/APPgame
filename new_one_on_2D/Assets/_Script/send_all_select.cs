using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class send_all_select : MonoBehaviour {

	private Color selected_color = new Color();
	private List<GameObject> player_stack = new List<GameObject>();

	// Do when script starts
	void Awake(){
		while (GameObject.Find("nickname") != null) {
			GameObject.Find ("nickname").GetComponent<MeshRenderer>().sortingOrder = 4;
			GameObject.Find ("nickname").name = "test";
		}
	}

	// Use this for initialization
	void Start () {
		ColorUtility.TryParseHtmlString ("#B2B6B6FF", out selected_color);
	}
	
	// Update is called once per frame
	void Update () {

	}

	// Send all selected player to server
	void OnTouchDown(){
		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Player")) {
			if(g.GetComponent<SpriteRenderer>().color == selected_color){
				player_stack.Add(g);
			}
			else{
				if(player_stack.Contains(g)){
					player_stack.Remove(g);
				}
			}
		}
	}

	//Test playerstack
	void OnTouchUp(){
		foreach (GameObject g in player_stack) {
			Debug.Log(g.name);
		}
	}

	void clearList(){
		player_stack.Clear ();
	}
}
