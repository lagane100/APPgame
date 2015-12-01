using UnityEngine;
using System.Collections;

public class Server_reconnect : MonoBehaviour {
	private string things = "1234";

	public Texture2D buttonImage;
	public GameObject Text;
	// Use this for initialization
	void Start () {
		Text.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")/*change to server connect error*/) {
			StartCoroutine(reconnectToServer(things));
		}
	}

	IEnumerator reconnectToServer(string thing_to_send){
		Text.SetActive (true);
		yield return 0;
	}

	void OnGUI (){
		if (GUI.Button (new Rect (100, 235, buttonImage.width/2, buttonImage.height/2), buttonImage)) {
			//server reconnect
		}
	}
}