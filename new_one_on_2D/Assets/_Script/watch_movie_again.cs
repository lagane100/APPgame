using UnityEngine;
using System.Collections;

public class watch_movie_again : MonoBehaviour {

	private string path = "http://128.199.87.70/movie_retry2.mp4";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator OnTouchDown(){
		Handheld.PlayFullScreenMovie (path, Color.black, FullScreenMovieControlMode.CancelOnInput, FullScreenMovieScalingMode.Fill);
		yield return new WaitForEndOfFrame();
	}
}
