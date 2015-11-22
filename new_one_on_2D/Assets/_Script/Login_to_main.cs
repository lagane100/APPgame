using UnityEngine;
using System.Collections;

public class Login_to_main : MonoBehaviour {

	private AndroidJavaObject TM = new AndroidJavaObject("android.telephony.TelephonyManager");


	// Start is called once per script
	void Start(){
		string IMEI = TM.Call<string>("getDeviceId");
	}

	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR_OSX || UNITY_STANDALONE
		MouseInput();	//control by mouse
#elif UNITY_ANDROID 
		MobileInput(); //control by finger
#endif
	}
	void MouseInput(){
		if (Input.GetKeyDown("space")) {

		}
	}

	void MobileInput(){

	}	
}

