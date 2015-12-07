using UnityEngine;
using System.Collections;
using System.Timers;

public class Login_word_shining : MonoBehaviour {

	private int timeCount = 0;
	private bool isShow = false;
	private GameObject Enter;
//	private GameObject Error;

	// Use this for initialization
	void Start () {
		Enter = GameObject.FindGameObjectWithTag ("press to continue");
//		Error = GameObject.FindGameObjectWithTag ("Error");
	}
	
	// Update is called once per frame
	void Update () {
		timeCount = timeCount + 1;
		if (timeCount < 60) {
			isShow = true;
		} else if (timeCount < 120) {
			isShow = false;
		} else {
			timeCount = timeCount - 120;
		}
		Enter.SetActive (isShow);
//		Error.SetActive (isShow);
	}
}
