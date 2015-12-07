using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using MiniJSON;

public class Login_to_main : MonoBehaviour {

	private string android_ID;// = "665c8c8937b9da30078e964ba84921";
	//private TextMesh show_android_ID;
	private GameObject Error;
	public string login_success_level;
	public string register_level;
	public GameObject loading_prefab;
	public GameObject error_prefab;

	// Start is called once per script
	void Start(){
		//show_android_ID = GameObject.FindGameObjectWithTag ("press to continue").GetComponent<TextMesh>();
		//show_android_ID.text = android_ID;
		Error = GameObject.FindGameObjectWithTag ("Error");
	}
	
	/*void OnMouseDown(){
		//insert ();
		if (Input.touchSupported) {
			Debug.Log("supported");
		}
		if (Input.touchCount > 0) {
			Debug.Log(Input.touchCount);
		}
	}*/

	void Update(){
		if (Input.GetMouseButtonDown(0)) {
			WWWForm form = new WWWForm();
			form.AddField("android_ID", "665c8c8937b9da30078e964ba8492182");
			WWW login_data = new WWW ("http://128.199.83.67/APPgame/backside/php/login.php",form);
			StartCoroutine(login(login_data));
		}
	}

	/*void MobileInput(){
		if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended) {
			WWWForm form = new WWWForm();
			form.AddField("android_ID", android_ID);
			WWW login_data = new WWW("http://128.199.83.67/APPgame/backside/php/login.php",form);
		 	StartCoroutine(login(login_data));
		}
	}*/

	void OnTouchDown(){
		PlayerPrefs.DeleteAll ();
		android_ID = (string)SystemInfo.deviceUniqueIdentifier;
		PlayerPrefs.SetString ("android_ID", android_ID);
		//show_android_ID.text = android_ID;
		WWWForm form = new WWWForm();
		form.AddField("android_ID", android_ID);
		WWW login_data = new WWW("http://128.199.83.67/APPgame/backside/php/login.php",form);
		StartCoroutine(login(login_data)); 
	}

	//login coroutine
	public IEnumerator login(WWW login_data){
		Instantiate(loading_prefab,new Vector3(0.0f,0.0f,0.0f),new Quaternion());
		Destroy(GameObject.FindGameObjectWithTag("press to continue"));
		yield return login_data;
		//show_android_ID.text = login_data.error;
		Debug.Log (login_data.text);
		PlayerPrefs.SetString ("test",login_data.text);
		if (login_data.error != null) {
			Debug.Log ("Connection_error by: " + login_data.error);
			Destroy(loading_prefab);
			//Instantiate(error_prefab,new Vector3(0.0f,0.0f,0.0f),new Quaternion());
			//show_android_ID.text = login_data.error;
			Error.SetActive(true);
			yield break;
		}
		else if(login_data.text.Equals("need new account")){
			PlayerPrefs.SetString("nextlevel",register_level);
			PlayerPrefs.SetInt("call_loading",1);
			yield break;
		}
		else {
			IDictionary<string,object> results = (IDictionary<string,object>)Json.Deserialize(login_data.text);
			WWWForm form = new WWWForm();
			form.AddField("UID", int.Parse(results["UID"].ToString()));
			WWW user_data = new WWW("http://128.199.83.67/APPgame/backside/php/getleveldata.php",form);
			yield return user_data;
			IDictionary<string,object> data = (IDictionary<string,object>)Json.Deserialize(user_data.text);
			string nickname = results["nickname"].ToString();
			string level = data["level"].ToString();
			string exp = data["exp"].ToString();
			string win = data["win"].ToString();
			string lose = data["lose"].ToString();
		 	PlayerPrefs.SetString("nickname", nickname);
			PlayerPrefs.SetInt("level", int.Parse(level));
			PlayerPrefs.SetInt("exp",int.Parse(exp));
			PlayerPrefs.SetInt("win",int.Parse(win));
			PlayerPrefs.SetInt("lose",int.Parse(lose));
			/*IList tweets = (IList) search["results"];
			 * 
			foreach (IDictionary tweet in tweets) {
				Debug.Log(string.Format("tweet: {0} : {1}", tweet["0"], tweet["UID"]));
			}*/
			PlayerPrefs.SetString("nextlevel",login_success_level);
			PlayerPrefs.SetInt("call_loading",1);
			yield break;
		}
	}
}

