using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using MiniJSON;

public class Login_to_main : MonoBehaviour {

	//private AndroidJavaObject TM = new AndroidJavaObject("android.telephony.TelephonyManager");


	// Start is called once per script
	void Start(){
		//string IMEI = TM.Call<string>("getDeviceId");
		//string IMEI = "359279065155027";
	}

	// Update is called once per frame
	void Update () {
		MouseInput ();
//#if UNITY_EDITOR_OSX || UNITY_STANDALONE
//		MouseInput();	//control by mouse
//#elif UNITY_ANDROID 
//		MobileInput(); //control by finger
//#endif
	}
	void MouseInput(){
		if (Input.GetKeyDown("space")) {
			StartCoroutine(login());
		}
	}
//	void MobileInput(){
//	}
	IEnumerator login(){
		WWW test_connect = new WWW ("128.199.83.67/APPgame/backside/php/connect.php");
		yield return test_connect;

		if (test_connect.error != null) {
			print ("Connection_error by: " + test_connect.error);
		} else {
			IDictionary jsonDictionary = (IDictionary)Json.Deserialize(test_connect.text);
			print (1);
			print (jsonDictionary);
			IList jsonList = (IList) jsonDictionary["Objects"];

			foreach(IDictionary data in jsonList){
				print(string.Format("data: {0} : {1}", data[1], data[2]));
			}
			yield break;
		}
	}
}

