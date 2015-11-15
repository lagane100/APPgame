using UnityEngine;
using System.Collections;

public class spining : MonoBehaviour {
	public int rotateAngle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate (0, 0,rotateAngle * Time.deltaTime);	
	}
}
