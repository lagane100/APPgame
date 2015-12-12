using UnityEngine;
using System.Collections;

public class playerselected : MonoBehaviour {

	private Color selected_color = new Color();
	private Color origin_color = new Color();

	// Use this for initialization
	void Start () {
		ColorUtility.TryParseHtmlString ("#B2B6B6FF", out selected_color);
		ColorUtility.TryParseHtmlString ("#FFFFFFFF", out origin_color);
	}

	// Update is called once per frame
	void Update () {
		GameObject.FindGameObjectWithTag ("enter").SendMessage ("CheckSelected",SendMessageOptions.DontRequireReceiver);
	}

	// Click to select
	IEnumerator OnTouchDown(){
		if (gameObject.GetComponent<SpriteRenderer> ().color == origin_color) {
			gameObject.GetComponent<SpriteRenderer> ().color = selected_color;
			GameObject.FindGameObjectWithTag ("enter").SendMessage ("UpdateSelected",gameObject, SendMessageOptions.RequireReceiver);
			yield break;
		}
		if (gameObject.GetComponent<SpriteRenderer> ().color == selected_color) {
			gameObject.GetComponent<SpriteRenderer> ().color = origin_color;
			GameObject.FindGameObjectWithTag ("enter").SendMessage ("Clear",gameObject, SendMessageOptions.RequireReceiver);
			yield break;
		}
	}
}
