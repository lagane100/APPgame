using UnityEngine;
using System.Collections;

public class change_to_start_and_start : Photon.MonoBehaviour {
	public Sprite ready;
	public Sprite unready;
	public string battle_level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PhotonNetwork.room != null) {
			//Debug.Log(PhotonNetwork.room.playerCount);
			if (PhotonNetwork.room.playerCount > 4) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = ready;
			}
			else {
				gameObject.GetComponent<SpriteRenderer>().sprite = unready;
			}
		}
	}

	void OnTouchDown(){
		if (PhotonNetwork.room != null) {
			if (PhotonNetwork.room.playerCount < 4) {
				PhotonNetwork.Instantiate ("loading_screen", new Vector3 (0.0f, 0.0f, 0.0f), new Quaternion (), 0);
				photonView.RPC("destroyBackground",PhotonTargets.All,null);
			}
		}
	}

	[PunRPC]
	public void destroyBackground(){
		Destroy (transform.parent.gameObject);
	}
}
