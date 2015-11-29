using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using MiniJSON;

public class Login_to_main : MonoBehaviour {

	//private AndroidJavaObject TM = new AndroidJavaObject("android.telephony.TelephonyManager");
	public string IMEI = "359279065155027";

	// Start is called once per script
	void Start(){
		//string IMEI = TM.Call<string>("getDeviceId");
	}

	// Update is called once per frame
	void Update () {
		MouseInput ();
	}
	void MouseInput(){
		if (Input.GetKeyDown("space")) {
			WWWForm form = new WWWForm();
			form.AddField("IMEI", IMEI);
			WWW test_connect = new WWW ("128.199.83.67/APPgame/backside/php/test.php",form);
			StartCoroutine(login(test_connect));
		}
	}

	//login coroutine
	IEnumerator login(WWW test_connect){
		yield return test_connect;
		if (test_connect.error != null) {
			print ("Connection_error by: " + test_connect.error);
			yield break;
		} else {
			//var results = Json.Deserialize(test_connect.text) as Dictionary<string,object>;

			IDictionary search = (IDictionary)Json.Deserialize(test_connect.text);
			print (search["UID"]);
			//IList tweets = (IList) search["results"];
			//Debug.Log(search);
			//Debug.Log(tweets);

			//foreach (IDictionary tweet in tweets) {
			//	Debug.Log(string.Format("tweet: {0} : {1}", tweet["0"], tweet["UID"]));
			//}

			yield break;
		}
	}
}

