using UnityEngine;
using System.Collections;

public class check_win : MonoBehaviour {

	private int team;
	public GameObject loading_prefab;
	public string end_level;

	// Use this for initialization
	void Start () {
		for (int i=0; i<PhotonNetwork.playerList.Length; i++) {
			if(PhotonNetwork.playerList[i].name.Equals(PlayerPrefs.GetString("nickname"))){
				team = i;
			}
		}
		team = team % 2;
		if (team != gameObject.transform.position.x) {
			GameObject.FindGameObjectWithTag("testTextMesh").GetComponent<TextMesh>().text = "lose";
		} else {
			GameObject.FindGameObjectWithTag("testTextMesh").GetComponent<TextMesh>().text = "win";
		}
		StartCoroutine (to_end());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator to_end(){
		yield return new WaitForSeconds (5);
		Instantiate(loading_prefab,new Vector3(0.0f,0.0f,0.0f),new Quaternion());
		PlayerPrefs.SetString("nextlevel",end_level);
		PlayerPrefs.SetInt("call_loading",1);
	}
}
