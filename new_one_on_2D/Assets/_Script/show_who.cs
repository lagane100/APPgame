using UnityEngine;
using System.Collections;

public class show_who : MonoBehaviour {

	public GameObject red;
	public GameObject blue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchDown(){
		for(int i = 0; i < PhotonNetwork.playerList.Length; i++){
			if(PhotonNetwork.playerList[i].name.Equals(PlayerPrefs.GetString("nickname"))){
				if(i%2 == 1){
					Instantiate(red, new Vector3(0.0f,0.0f,0.0f), new Quaternion());
				}
				else{
					Instantiate(blue,new Vector3(0.0f,0.0f,0.0f), new Quaternion());
				}
			}
		}
	}
}
