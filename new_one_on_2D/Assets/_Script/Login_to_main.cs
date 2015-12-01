using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using MiniJSON;

public class Login_to_main : MonoBehaviour {

	private string android_ID; //= "359279065155027";
	private TextMesh show_android_ID;
	public string login_success_level;
	public string register_level;
	public GameObject loading_prefab;

	// Start is called once per script
	void Start(){
		android_ID = (string)SystemInfo.deviceUniqueIdentifier;
		show_android_ID = GameObject.FindGameObjectWithTag ("press to continue").GetComponent<TextMesh>();
		//show_android_ID.text = android_ID;
	}

	// Update is called once per frame
	void Update () {
		MobileInput ();
//#if UNITY_EDITOR_OSX || UNITY_STANDALONE
//		MouseInput ();
//#elif UNITY_ANDROID
//		MobileInput();
//#endif
	}
	void MouseInput(){
		if (Input.GetMouseButtonDown(0)) {
			WWWForm form = new WWWForm();
			form.AddField("android_ID", android_ID);
			WWW login_data = new WWW ("128.199.83.67/APPgame/backside/php/login.php",form);
			StartCoroutine(login(login_data));
		}
	}

	void MobileInput(){
		if (!Input.touchSupported) {
			show_android_ID.text = "fuck";
		}
		if (Input.touchSupported) {
			show_android_ID.text = "fuckk";
		}
		if (Input.touches[0].tapCount == 2) {
			WWWForm form = new WWWForm();
			form.AddField("android_ID", android_ID);
			WWW login_data = new WWW("128.199.83.67/APPgame/backside/php/login.php",form);
		 	StartCoroutine(login(login_data));
		}

	}

	//login coroutine
	public IEnumerator login(WWW login_data){
		yield return login_data;
		Debug.Log (login_data.text);
		if (login_data.error != null) {
			Debug.Log ("Connection_error by: " + login_data.error);
			yield break;
		}
		else if(login_data.text.Equals("need new account")){
			PlayerPrefs.SetString("nextlevel",register_level);
			Instantiate(loading_prefab,new Vector3(0.0f,0.0f,0.0f),new Quaternion());
			yield break;
		}
		else {
			IDictionary<string,object> results = (IDictionary<string,object>)Json.Deserialize(login_data.text);
			Debug.Log(results["0"]);
			/*IList tweets = (IList) search["results"];
			 * 
			foreach (IDictionary tweet in tweets) {
				Debug.Log(string.Format("tweet: {0} : {1}", tweet["0"], tweet["UID"]));
			}*/
			PlayerPrefs.SetString("nextlevel",login_success_level);
			Instantiate(loading_prefab,new Vector3(0.0f,0.0f,0.0f),new Quaternion());
			yield break;
		}
	}
}

