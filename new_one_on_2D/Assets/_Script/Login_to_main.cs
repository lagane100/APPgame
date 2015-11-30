using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using MiniJSON;

public class Login_to_main : MonoBehaviour {

	//private AndroidJavaObject TM = new AndroidJavaObject("android.telephony.TelephonyManager");
	private string IMEI = "359279065155027";

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
			WWW login_data = new WWW ("128.199.83.67/APPgame/backside/php/login.php",form);
			StartCoroutine(login(login_data));
		}
	}

	//login coroutine
	IEnumerator login(WWW login_data){
		yield return login_data;
		if (login_data.error != null) {
			print ("Connection_error by: " + login_data.error);
			yield break;
		}
		else if(login_data.text.Equals("need new account")){
			WWW register_data = new WWW("128.199.83.67/APPgame/backside/php/register.php");
			yield return StartCoroutine(register(register_data));
		}
		else {
			//IDictionary<string,object> results = (IDictionary<string,object>)Json.Deserialize(login_data.text);
			Debug.Log(login_data.text);
			/*IList tweets = (IList) search["results"];
			 * 
			foreach (IDictionary tweet in tweets) {
				Debug.Log(string.Format("tweet: {0} : {1}", tweet["0"], tweet["UID"]));
			}*/

			yield break;
		}
	}

	//register coroutine
	IEnumerator register(WWW register_data){
		yield return null;
	}

}

