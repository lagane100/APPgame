using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class get_data : MonoBehaviour {

	private WWW data;
	// Use this for initialization
	void Start () {
		WWWForm form = new WWWForm ();
		form.AddField("UID",1);
		data = new WWW ("http://128.199.83.67/APPgame/backside/php/getleveldata.php", form);
		StartCoroutine (get_data_from_mysql (data));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator get_data_from_mysql(WWW data){
		yield return data;
		GameObject.Find ("UID").GetComponent<TextMesh>().text = PlayerPrefs.GetInt ("UID").ToString();
		IDictionary<string,object> results = (IDictionary<string,object>)Json.Deserialize(data.text);
		GameObject.Find("level").GetComponent<TextMesh>().text = results["level"].ToString();
		GameObject.Find("exp now").GetComponent<TextMesh>().text = results["exp"].ToString();
		GameObject.Find("win").GetComponent<TextMesh>().text = results["win"].ToString();
		GameObject.Find("lose").GetComponent<TextMesh>().text = results["lose"].ToString();
		GameObject.Find ("total").GetComponent<TextMesh> ().text = (int.Parse (results ["win"].ToString()) + int.Parse (results ["lose"].ToString())).ToString ();
		GameObject.Find ("nickname").GetComponent<TextMesh>().text = PlayerPrefs.GetString("nickname");
		if (GameObject.Find ("total").GetComponent<TextMesh> ().text.Equals ("0")) {
			GameObject.Find ("win rate").GetComponent<TextMesh> ().text = "0%";
		} else {
			GameObject.Find ("win rate").GetComponent<TextMesh>().text = (int.Parse(results["win"].ToString()) / (int.Parse(results["win"].ToString()) + int.Parse(results["lose"].ToString()))).ToString();
		}
	}
}
