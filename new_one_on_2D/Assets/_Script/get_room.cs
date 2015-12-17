using UnityEngine;
using System.Collections;

public class get_room : MonoBehaviour {

	public GameObject room;
	private float y_position;
	private TextMesh changeName;
	private RoomInfo[] roomlist;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnReceivedRoomListUpdate(){
		y_position = 2.5f;
		roomlist = PhotonNetwork.GetRoomList ();
		foreach (RoomInfo roomName in PhotonNetwork.GetRoomList()) {
			Debug.Log (roomName.name);
			room.GetComponent<TextMesh> ().text = roomName.name;
			Instantiate (room, new Vector3 (0.5f, y_position, 0.0f), new Quaternion ());
			y_position = y_position - 0.5f;
		}
	}
}