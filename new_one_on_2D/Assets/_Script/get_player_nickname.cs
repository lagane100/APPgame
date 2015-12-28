using UnityEngine;
using System.Collections;

public class get_player_nickname : MonoBehaviour {

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) {
			if(child.name != "nicknameChanged"){
				TextMesh nicknameChange = transform.Find("nicknameChanged").GetComponent<TextMesh>();
				nicknameChange.text = GameObject.FindGameObjectWithTag(child.name).name;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	/*[PunRPC]
	public void getNickname(string playerNum){
		if (transform.FindChild (playerNum)) {
			Debug.Log(playerNum);
			photonView.RPC("sendNicknameBack",PhotonTargets.All,PlayerPrefs.GetString("nickname"));
		}
	}

	[PunRPC]
	public void sendNicknameBack(string nickname){
		Debug.Log (12345);
		TextMesh nicknameChange = transform.Find("nicknameChanged").GetComponent<TextMesh>();
		nicknameChange.text = nickname;
	}*/
}
