using UnityEngine;
using System.Collections;

public class get_player_nickname : Photon.MonoBehaviour {

	private string player = "player";

	// Use this for initialization
	void Start () {
		player = player + PhotonNetwork.player.ID;
		if (transform.FindChild (player)) {
			photonView.viewID = PhotonNetwork.player.ID;
		}

		photonView.RPC ("getNickname", PhotonTargets.All, player);
	}
	
	// Update is called once per frame
	void Update () {

	}

	[PunRPC]
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
	}
}
