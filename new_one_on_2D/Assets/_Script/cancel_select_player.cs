using UnityEngine;
using System.Collections;

public class cancel_select_player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchDown(){
		GameObject.FindGameObjectWithTag ("enter").SendMessage ("clearList",SendMessageOptions.DontRequireReceiver);
		Destroy(GameObject.FindGameObjectWithTag("choseWho"));
	}
}
