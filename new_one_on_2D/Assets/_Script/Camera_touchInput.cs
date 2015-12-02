using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Camera_touchInput : MonoBehaviour {
	public LayerMask touchInputMask;

	private List<GameObject> touchList = new List<GameObject>();
	private GameObject[] touchsOld;

	private Camera c;

	//private TextMesh test;

	// Start is called once per script
	void Start(){
		c = GetComponent<Camera> ();
	}

	// Update is called once per frame
	void Update () {
		//test = GameObject.FindGameObjectWithTag("press to continue").GetComponent<TextMesh>();
		//input.touchcount returns the number of the point is now touching

		if (Input.touchCount > 0) {
			touchsOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchsOld);
			touchList.Clear();

			foreach(Touch t in Input.touches) {
				Ray ray = c.ScreenPointToRay(t.position);
				RaycastHit hit;

				if(Physics.Raycast(ray,out hit,touchInputMask)){
				
					GameObject recipient = hit.transform.gameObject;
					touchList.Add(recipient);

					if(t.phase == TouchPhase.Began){
						recipient.SendMessage("OnTouchDown",hit.point,SendMessageOptions.DontRequireReceiver);
					}
					if(t.phase == TouchPhase.Ended){
						recipient.SendMessage("OnTouchUp",hit.point,SendMessageOptions.DontRequireReceiver);
					}
					if(t.phase == TouchPhase.Stationary || t.phase == TouchPhase.Moved){
						recipient.SendMessage("OnTouchStay",hit.point,SendMessageOptions.DontRequireReceiver);
					}
					if(t.phase == TouchPhase.Canceled){
						recipient.SendMessage("OnTouchExit",hit.point,SendMessageOptions.DontRequireReceiver);
					}
				}
			}
		}
	}
}
