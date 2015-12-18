using UnityEngine;
using System.Collections;

public class Do_Text_Field : MonoBehaviour {

	private string check_nick = "Enter your name(English only)";
	//private string edit_to_send = "Press to continue";
	private WWW register_data;
	private WWW UID_data;
	public GameObject loading_prefab;
	public string login_success_level;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//edit_to_send = PlayerPrefs.GetString ("test");
	}

	// Set textfield GUI
	void OnGUI(){
		check_nick = GUI.TextField (new Rect (Screen.width/3 - Screen.width/25, Screen.height/2 - Screen.height/25, 5 * Screen.width/12,Screen.height/15), check_nick, 20);
		GUI.skin.textField.fontSize = 80;

		/*if (GUI.Button (new Rect (Screen.width * 3 / 8, Screen.height / 2, Screen.width / 4, Screen.height / 16), edit_to_send)) {
			StartCoroutine(register_new(check_nick));
		}*/
		GUI.skin.button.fontSize = 40;
	}

	public IEnumerator register_new(){
		Instantiate (loading_prefab, new Vector3 (0.0f, 0.0f, 0.0f), new Quaternion ());
		string temp = check_nick;
		check_nick.Replace ("'", string.Empty);
		check_nick.Replace ("<", string.Empty);
		check_nick.Replace (">", string.Empty);
		check_nick.Replace ("-", string.Empty);
		if (!temp.Equals (check_nick)) {
			check_nick = "Error message";
		}
		WWWForm form = new WWWForm ();
		form.AddField("android_ID",PlayerPrefs.GetString("android_ID"));
		//edit_to_send = PlayerPrefs.GetString ("android_ID");
		form.AddField ("nickname", check_nick);
		register_data = new WWW ("http://128.199.83.67/APPgame/backside/php/register.php",form);
		yield return register_data;
		Debug.Log (register_data.error);
		if (register_data.text.Equals ("Success")) {
			PlayerPrefs.SetInt("EXP",0);
			PlayerPrefs.SetInt("level",1);
			PlayerPrefs.SetString("nickname",check_nick);
			//yield return StartCoroutine (getUID());
			yield return StartCoroutine (start_change_scene_to_main ());
		}
	}

	public IEnumerator start_change_scene_to_main(){
		yield return register_data;
		if (register_data.error != null) {
			Debug.Log (register_data.error);
		} else {
			PlayerPrefs.SetString ("nextlevel", login_success_level);
			PlayerPrefs.SetInt("call_loading",1);
			yield break;
		}
	}

	public IEnumerator getUID(){
		WWWForm ID = new WWWForm ();
		ID.AddField ("android_ID", PlayerPrefs.GetString ("android_ID"));
		UID_data = new WWW ("http://128.199.83.67/APPgame/backside/php/getUID.php", ID);
		yield return UID_data;
	}
}
