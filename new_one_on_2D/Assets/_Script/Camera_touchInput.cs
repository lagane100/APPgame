using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Camera_touchInput : MonoBehaviour {
	public LayerMask touchInputMask;

	private Camera c;
	private List<GameObject> touchList = new List<GameObject>();
	private GameObject[] touchsOld;

	RaycastHit hit;

	//private TextMesh test;

	// Start is called once per script
	void Start(){
		c = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
		//test = GameObject.FindGameObjectWithTag("testTextMesh").GetComponent<TextMesh>();
	}

	// Update is called once per frame
	void Update () {

#if UNITY_EDITOR
		if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)) {

			touchsOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchsOld);
			touchList.Clear();

			Ray ray = c.ScreenPointToRay(Input.mousePosition);
			Debug.Log (Physics.Raycast(ray,out hit,touchInputMask));
			if(Physics.Raycast(ray, out hit, touchInputMask)){

				GameObject recipient = hit.transform.gameObject;
				touchList.Add(recipient);

				if(Input.GetMouseButtonDown(0)){
					recipient.SendMessage("OnTouchDown",hit.point,SendMessageOptions.DontRequireReceiver);
				}
				if(Input.GetMouseButtonUp(0)){
					recipient.SendMessage("OnTouchUp",hit.point,SendMessageOptions.DontRequireReceiver);
				}
				if(Input.GetMouseButton(0)){
					recipient.SendMessage("OnTouchStay",hit.point,SendMessageOptions.DontRequireReceiver);
				}
			}
			
			foreach(GameObject g in touchsOld){
				if(!touchList.Contains(g) && g){
					g.SendMessage("OnTouchExit",hit.point,SendMessageOptions.DontRequireReceiver);
				}
			}
		}
#else
		//input.touchcount returns the number of the point is now touching
		if (Input.touchCount > 0) {
			touchsOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchsOld);
			touchList.Clear();

			foreach(Touch t in Input.touches) {
				Ray ray = c.ScreenPointToRay(t.position);

				if(Physics.Raycast(ray,out hit,touchInputMask)){
				
					GameObject recipient = hit.transform.gameObject;
					touchList.Add(recipient);

					if(t.phase == TouchPhase.Began){
						recipient.SendMessage("OnTouchDown",hit.point,SendMessageOptions.DontRequireReceiver);
					//	test.text = "test";
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

			foreach(GameObject g in touchsOld){
				if(!touchList.Contains(g) && g){
					g.SendMessage("OnTouchExit",hit.point,SendMessageOptions.DontRequireReceiver);
				}
			}
		}
#endif
	}
}
