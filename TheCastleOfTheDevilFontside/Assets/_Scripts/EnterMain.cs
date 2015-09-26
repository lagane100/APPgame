using UnityEngine;
using System.Collections;
using System.Threading;

public class EnterMain : MonoBehaviour {
	private TextMesh continueSign;
	private Color[] textColor = new Color[4]{Color.clear, Color.gray, Color.black, Color.gray};

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

		//for (int i = 0; i < textColor.Length; i++) {
		//	continueSign.color = textColor[i];
		//	Thread.Sleep(200);
		//}
	}
}
