using UnityEngine;
using System.Collections;

public class change_to_start_and_start : MonoBehaviour {
	public Sprite ready;
	public Sprite unready;
	public string battle_level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PhotonNetwork.room != null) {
			Debug.Log(PhotonNetwork.room.playerCount);
			if (PhotonNetwork.room.playerCount > 4) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = ready;
			}
			if(PhotonNetwork.room.playerCount < 5){
				gameObject.GetComponent<SpriteRenderer>().sprite = unready;
			}
		}
		if (GameObject.FindGameObjectWithTag ("load screen")) {
			PhotonNetwork.room.open = false;
			for(int i=0;i<PhotonNetwork.room.playerCount;i++){
				if(PhotonNetwork.playerList[i].Equals(PlayerPrefs.GetString("nickname"))){
					PlayerPrefs.SetInt("playerNO",i);
				}
			}
			PlayerPrefs.SetString ("nextlevel", battle_level);
			PlayerPrefs.SetInt ("call_loading", 1);
		}
	}

	void OnTouchDown(){
		if (PhotonNetwork.room != null) {
			if (PhotonNetwork.room.playerCount > 4) {
				PhotonNetwork.Instantiate ("loading_screen", new Vector3 (0.0f, 0.0f, 0.0f), new Quaternion (), 0);
			}
		}
	}
}
