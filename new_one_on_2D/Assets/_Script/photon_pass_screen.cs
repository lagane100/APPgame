using UnityEngine;
using System.Collections;

public class photon_pass_screen : MonoBehaviour {

	public GameObject background;
	public GameObject loading_bar;
	public GameObject loading_text;

	private int loading = 0;

	// Use this for initialization
	void Start () {
		background.SetActive (false);
		loading_bar.SetActive (false);
		loading_text.SetActive (false);
		StartCoroutine (PhotonDisplayLoadingScreen ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator PhotonDisplayLoadingScreen(){
		background.SetActive (true);
		loading_bar.SetActive (true);
		loading_text.SetActive (true);

		TextMesh textObject = GameObject.Find ("text").GetComponent<TextMesh> ();
		textObject.GetComponent<Renderer> ().sortingOrder = 21;
		textObject.text = "Now Loading " + loading + "%";

		AsyncOperation async = Application.LoadLevelAsync ("battle");
		while (!async.isDone) {
			loading = (int)(async.progress * 100);
			textObject.text = "Now Loading " + loading + "%";
			yield return null;
		}
	}
}
