using UnityEngine;
using System.Collections;

public class let_mesh_float : MonoBehaviour {

	void Awake(){
		GameObject.Find ("exp_main").GetComponent<SpriteRenderer> ().sortingOrder = 3;
		GameObject.Find ("level_main").GetComponent<SpriteRenderer> ().sortingOrder = 3;
	}
}
	