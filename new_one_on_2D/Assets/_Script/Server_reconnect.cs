using UnityEngine;
using System.Collections;

public class Server_reconnect : MonoBehaviour {
	private string things = "1234";

	public GameObject Text;
	public GameObject OK;
	// Use this for initialization
	void Start () {
		Text.SetActive (false);
		OK.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")/*change to server connect error*/) {
			StartCoroutine(reconnectToServer(things));
		}
	}

	IEnumerator reconnectToServer(string thing_to_send){
		Text.SetActive (true);
		OK.SetActive (true);

		yield return 0;
	}
}