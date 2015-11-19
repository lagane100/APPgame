using UnityEngine;
using System.Collections;

public class pass_scene_loading : MonoBehaviour {

	public string levelToLoad;

	public GameObject background;
	public GameObject loading_bar;
	public GameObject text;

	private int loadProgress = 0;

	// Use this for initialization
	void Start () {
		background.SetActive (false);
		loading_bar.SetActive (false);
		text.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			StartCoroutine(DisplayLoadingScreen(levelToLoad));
		}
	}

	// Display the loading screen while the scene is changing
	IEnumerator DisplayLoadingScreen(string level){
		background.SetActive (true);
		loading_bar.SetActive (true);
		text.SetActive (true);

		loading_bar.transform.localScale = new Vector3 (loadProgress, loading_bar.transform.position.y, loading_bar.transform.position.z);

		TextMesh textObject = GameObject.Find ("text").GetComponent<TextMesh> ();
		textObject.text = "Now Loading " + loadProgress + "%";

		AsyncOperation async = Application.LoadLevelAsync (level);
		while (!async.isDone) {
			loadProgress = (int)(async.progress * 100);
			textObject.text = "Now Loading " + loadProgress + "%"; 
			loading_bar.transform.localScale = new Vector3 (async.progress, loading_bar.transform.position.y, loading_bar.transform.position.z);
			yield return null;
		}
	}
}
