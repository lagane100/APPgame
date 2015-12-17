using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class create_room : MonoBehaviour {

	const string gameVersion = "1.0.1";
	private string roomName = "roomName";
	public GameObject roomPrefab;
	private string [] test;

	void Awake() {
		// this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
		PhotonNetwork.automaticallySyncScene = true;
		// the following line checks if this client was just created (and not yet online). if so, we connect
		if (PhotonNetwork.connectionStateDetailed == PeerState.PeerCreated)
		{
			// Connect to the photon master-server. We use the settings saved in PhotonServerSettings (a .asset file in this project)
			PhotonNetwork.ConnectUsingSettings(gameVersion);
		}
		// generate a name for this player, if none is assigned yet
		PhotonNetwork.playerName = PlayerPrefs.GetString ("nickname");
		// if you wanted more debug out, turn this on:
		// PhotonNetwork.logLevel = NetworkLogLevel.Full;
		
	}
	// Use this for initialization
	void Start () {
		roomName = Random.Range(1,9999) + " room";
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTouchDown(){
		RoomOptions option = new RoomOptions ();
		option.isOpen = true;
		option.isVisible = true;
		option.maxPlayers = 10;
		PhotonNetwork.CreateRoom (roomName, option, null);

	}

	void OnJoinedRoom(){
		Instantiate (roomPrefab, new Vector3 (0.0f, 0.0f, 0.0f), new Quaternion ());
		Debug.Log (PhotonNetwork.room.name);
	}

	void OnReceivedRoomListUpdate(){
		foreach (RoomInfo info in PhotonNetwork.GetRoomList()) {
			Debug.Log(info.name);
		}
	}
}
