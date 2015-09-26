using UnityEngine;
using System.Collections;

public class EnterMain : MonoBehaviour {
	private TextMesh continueSign;

	// Use this for initialization
	void Start () {
		continueSign = (TextMesh)GetComponent ("TextMesh");
		continueSign.text = "press anywhere to continue";
		continueSign.transform.position = new Vector3 (-7.8f,3.0f,-7.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel(0);
		}
	}
}
