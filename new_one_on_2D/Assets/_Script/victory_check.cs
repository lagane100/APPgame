using UnityEngine;
using System.Collections;

public class victory_check : MonoBehaviour {

	private int team;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchDown(){
		for (int i=0; i<PhotonNetwork.playerList.Length; i++) {
			if(PhotonNetwork.playerList[i].name.Equals(PlayerPrefs.GetString("nickname"))){
				team = i;
			}
		}
		team = team % 2;
		PhotonNetwork.Instantiate("counter",new Vector3((float)team,0.0f,0.0f),new Quaternion(), 0);
	}
}
