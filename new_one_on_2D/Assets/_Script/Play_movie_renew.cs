﻿using UnityEngine;
using System.Collections;

public class Play_movie_renew : MonoBehaviour {

	//private TextMesh t;
	public string path;

	// Use this for initialization
	void Start () {
		//Handheld.PlayFullScreenMovie ("introduce.avi", Color.black, FullScreenMovieControlMode.Full);
		//t = GameObject.FindGameObjectWithTag ("test text mesh").GetComponent<TextMesh> ();
		StartCoroutine (movie_play ());
	}
	
	// Update is called once per frame
	void Update () {

	}

	// run the movie
	IEnumerator movie_play(){
		Handheld.PlayFullScreenMovie (path,Color.white,FullScreenMovieControlMode.CancelOnInput,FullScreenMovieScalingMode.Fill);
		yield return new WaitForEndOfFrame();
		Destroy (gameObject);
		GameObject.FindGameObjectWithTag ("ask for nickname").SetActive (true);
	}
}