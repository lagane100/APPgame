﻿using UnityEngine;
using System.Collections;

public class pass_scene_loading : MonoBehaviour {

	public GameObject background;
	public GameObject loading_bar;
	public GameObject text;

	private int loadProgress = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update(){
		if (PlayerPrefs.GetInt ("call_loading") == 1) {
			PlayerPrefs.SetInt("call_loading", 0);
			StartCoroutine(DisplayLoadingScreen(PlayerPrefs.GetString("nextlevel")));
		}
	}

	// Display the loading screen while the scene is changing
	public IEnumerator DisplayLoadingScreen(string level){
		//loading_bar.transform.localScale = new Vector3 (loadProgress, loading_bar.transform.position.y, loading_bar.transform.position.z);

		text.SetActive (true);
		TextMesh textObject = GameObject.Find ("text").GetComponent<TextMesh> ();
		textObject.GetComponent<Renderer> ().sortingOrder = 21;
		textObject.text = "Now Loading " + loadProgress + "%";

		AsyncOperation async = Application.LoadLevelAsync (level);
		while (!async.isDone) {
			loadProgress = (int)(async.progress * 100);
			textObject.text = "Now Loading " + loadProgress + "%"; 
			//loading_bar.transform.localScale = new Vector3 (async.progress, loading_bar.transform.position.y, loading_bar.transform.position.z);
			yield return null;
		}
	}
}
