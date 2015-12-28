using UnityEngine;
using System.Collections;

public class trade : Photon.MonoBehaviour {

	public GameObject select_player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// start trading
	void OnTouchDown(){
		if (PhotonNetwork.isMasterClient) {
			photonView.RPC("getOtherNickname",PhotonTargets.All,null);
		}
	}

	[PunRPC]
	public void getOtherNickname(){
		GameObject selector = Instantiate (select_player, new Vector3 (0.0f, 0.0f, 0.0f), new Quaternion ()) as GameObject;
		selector.transform.parent = gameObject.transform;
	}
}
