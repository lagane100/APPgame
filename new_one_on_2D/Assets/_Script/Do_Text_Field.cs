using UnityEngine;
using System.Collections;

public class Do_Text_Field : MonoBehaviour {

	private string edit_to_enter = "Enter your name(English only)";
	private string edit_to_send = "Press to continue";
	private WWW register_data;
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
		edit_to_enter = GUI.TextField (new Rect (Screen.width/4, Screen.height/2 - Screen.height/10, Screen.width/2,Screen.height/15), edit_to_enter, 40);
		GUI.skin.textField.fontSize = 80;

		if (GUI.Button (new Rect (Screen.width * 3 / 8, Screen.height / 2, Screen.width / 4, Screen.height / 16), edit_to_send)) {
			StartCoroutine(register_new(edit_to_enter));
		}
		GUI.skin.button.fontSize = 40;
	}

	public IEnumerator register_new(string check_nick){
		string temp = check_nick;
		check_nick.Replace ("'", string.Empty);
		check_nick.Replace ("<", string.Empty);
		check_nick.Replace (">", string.Empty);
		check_nick.Replace ("-", string.Empty);
		if (!temp.Equals (check_nick)) {
			edit_to_enter = "Error message";
		}
		WWWForm form = new WWWForm ();
		form.AddField("android_ID",PlayerPrefs.GetString("android_ID"));
		//edit_to_send = PlayerPrefs.GetString ("android_ID");
		form.AddField ("nickname", check_nick);
		register_data = new WWW ("http://128.199.83.67/APPgame/backside/php/register.php",form);
		yield return register_data;
		if (register_data.text.Equals ("Success")) {
			PlayerPrefs.SetInt("EXP",0);
			PlayerPrefs.SetInt("level",0);
			PlayerPrefs.SetString("nickname",check_nick);
			yield return StartCoroutine (start_change_scene_to_main ());
		}
	}

	public IEnumerator start_change_scene_to_main(){
		yield return register_data;
		if (register_data.error != null) {
			Debug.Log (register_data.error);
		} else {
			PlayerPrefs.SetString ("nextlevel", login_success_level);
			Instantiate (loading_prefab, new Vector3 (0.0f, 0.0f, 0.0f), new Quaternion ());
			yield break;
		}
	}
}
