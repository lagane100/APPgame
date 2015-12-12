using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	public AudioClip audioClip;
	private AudioSource source;

	void Start(){
		source = GetComponent<AudioSource> ();
	}
	void OnTouchDown(){
		source.PlayOneShot(audioClip);
	}
}
