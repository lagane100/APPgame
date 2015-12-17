// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorkerMenu.cs" company="Exit Games GmbH">
//   Part of: Photon Unity Networking
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using UnityEngine;
using Random = UnityEngine.Random;
public class test : MonoBehaviour
{
	int LoadCount = 1;
	public GUISkin Skin;
	int W = Screen.width;
	int H = Screen.height;
	Vector2 WidthAndHeight ;
	Rect GameLobby ;
	Rect CreateRoom ;
	Rect Room ;
	Rect FullScreen;
	Rect TopBar;
	Rect PersonInfo;
	Rect RoomList;
	Vector2 RoomListItemMargin;
	Vector2 JoinButton;
	Vector2 JoinButtonMargin;
	Vector2 MapMargin;
	float RoomListItemHeight;
	public static bool Creator = false;
	Vector2 scrollPosition = Vector2.zero;
	private string roomName = "myRoom";
	private Vector2 scrollPos = Vector2.zero;
	private bool connectFailed = false;
	public static readonly string SceneNameMenu = "DemoWorker-Scene";
	public static readonly string SceneNameGame = "DemoWorkerGame-Scene";
	public static readonly string SceneNameWait = "WaitingRoom";
	private string errorDialog;
	private double timeToClearDialog;
	public string ErrorDialog
	{
		get 
		{ 
			return errorDialog; 
		}
		private set
		{
			errorDialog = value;
			if (!string.IsNullOrEmpty(value))
			{
				timeToClearDialog = Time.time + 4.0f;
			}
		}
	}
	public void Awake()
	{
		// this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
		PhotonNetwork.automaticallySyncScene = true;
		// the following line checks if this client was just created (and not yet online). if so, we connect
		if (PhotonNetwork.connectionStateDetailed == PeerState.PeerCreated)
		{
			// Connect to the photon master-server. We use the settings saved in PhotonServerSettings (a .asset file in this project)
			PhotonNetwork.ConnectUsingSettings("0.9");
		}
		// generate a name for this player, if none is assigned yet
		if (String.IsNullOrEmpty(PhotonNetwork.playerName))
		{
			PhotonNetwork.playerName = "Guest" + Random.Range(1, 9999);
		}
		// if you wanted more debug out, turn this on:
		// PhotonNetwork.logLevel = NetworkLogLevel.Full;
		
	}
	void Start(){
		Cursor.visible = true;
		roomName = PhotonNetwork.playerName+"'s Room";
		print (roomName);
		WidthAndHeight = new Vector2(W,H);
		GameLobby = new Rect (W * 3 / 8, 2, W / 4, H / 8);
		CreateRoom = new Rect (W *4/5, 2, W/6 , H / 8);
		FullScreen = new Rect(0,0,W,H);
		TopBar = new Rect(0,0,W,H/6);
		PersonInfo = new Rect(W*65/1024,H*150/640,W*200/1024,H*430/640);
		RoomList = new Rect(W*270/1024,H*150/640,W*700/1024,H*430/640);
		RoomListItemMargin = new Vector2 (W*14/1024, H*14/640);
		Room = new Rect (W*270/1024+RoomListItemMargin.x,H*150/640+RoomListItemMargin.y, W*700/1024-RoomListItemMargin.x*2 , H*142/640);
		RoomListItemHeight = H*142/640+RoomListItemMargin.y;
		JoinButton = new Vector2 (W*120/1024, H*100/640);
		JoinButtonMargin = new Vector2 (W*500/1024, H*20/640);
		MapMargin = new Vector2 (W*45/1024, H*20/640);
		this.scrollPos = new Vector2 (W / 4, H / 6);
	}
	public void OnGUI()
	{
		if (this.Skin != null)
		{
			GUI.skin = this.Skin;
		}
		if (!PhotonNetwork.connected)
		{
			if (PhotonNetwork.connecting)
			{
				GUILayout.Label("Connecting to: " + PhotonNetwork.ServerAddress);
				GUI.DrawTexture(FullScreen,Resources.Load<Texture2D> ("UIpic/loading_"+LoadCount));
				LoadCount++;
				if(LoadCount==9)LoadCount = 1;
			}
			else
			{
				GUILayout.Label("Not connected. Check console output. Detailed connection state: " + PhotonNetwork.connectionStateDetailed + " Server: " + PhotonNetwork.ServerAddress);
			}
			
			if (this.connectFailed)
			{
				GUILayout.Label("Connection failed. Check setup and use Setup Wizard to fix configuration.");
				GUILayout.Label(String.Format("Server: {0}", new object[] {PhotonNetwork.ServerAddress}));
				GUILayout.Label("AppId: " + PhotonNetwork.PhotonServerSettings.AppID);
				
				if (GUILayout.Button("Try Again", GUILayout.Width(100)))
				{
					this.connectFailed = false;
					PhotonNetwork.ConnectUsingSettings("0.9");
				}
			}
			return;
		}
		Rect content = new Rect(0, 0, WidthAndHeight.x, WidthAndHeight.y);
		//GUI.Box(content,"GAME LOBBY");
		/*if (GUI.Button(new Rect(Screen.width*0.75f,0,Screen.width*0.25f,Screen.width*0.2f),"Create Room"))
		{
			//PhotonNetwork.CreateRoom(this.roomName, new RoomOptions() { maxPlayers = 10 }, null);
		}*/
		//GUI.Button (FullScreen, "");
		GUI.Box (FullScreen,"",Skin.GetStyle("LobbyBackground"));
		//GUI.Button (TopBar,"");
		GUI.Box (PersonInfo,"",Skin.GetStyle("PersonInfo"));
		GUI.Box (RoomList,"",Skin.GetStyle("RoomList"));
		//GUI.Box(GameLobby,"Game Lobby");
		if (GUI.Button (CreateRoom, "Create Room")) {
			PhotonNetwork.CreateRoom(this.roomName, new RoomOptions() { maxPlayers = 10 }, null);
		}
		int i = 0;
		//scrollPosition = GUI.BeginScrollView(RoomList, scrollPosition, new Rect(0, 0, 220, 200));
		foreach (RoomInfo roomInfo in PhotonNetwork.GetRoomList()) {
			Room = new Rect (W*270/1024+RoomListItemMargin.x,H*150/640+RoomListItemMargin.y+i*RoomListItemHeight, W*700/1024-RoomListItemMargin.x*2 , H*142/640);
			//Room = new Rect (W*270/1024+RoomListItemMargin.x,H*150/640+RoomListItemMargin.y, W*700/1024-RoomListItemMargin.x*2 , H*142/640);
			Rect joinbutton = new Rect(Room.x+JoinButtonMargin.x,Room.y+JoinButtonMargin.y+i*RoomListItemHeight,JoinButton.x,JoinButton.y);
			Rect map = new Rect(Room.x+MapMargin.x,Room.y+MapMargin.y+i*RoomListItemHeight,JoinButton.x,JoinButton.y);
			GUI.Box (Room,"",Skin.GetStyle("Room"));
			GUI.Box (map,"愛歐尼亞",Skin.GetStyle("Map"));
			if(GUI.Button (joinbutton,"Join")){
				print ("JoinRoom");
				PhotonNetwork.JoinRoom(roomInfo.name);
				//PlayerPrefs.SetInt("RoomMonitor",0);
			}
			i++;
		}
		//GUI.EndScrollView();
		//GUI.Button (Room,"ROOM");
		/*scrollPosition = GUI.BeginScrollView(new Rect(10, 300, 100, 100), scrollPosition, new Rect(0, 0, 220, 200));
		GUI.Button(new Rect(0, 0, 100, 20), "Top-left");
		GUI.Button(new Rect(120, 0, 100, 20), "Top-right");
		GUI.Button(new Rect(0, 180, 100, 20), "Bottom-left");
		GUI.Button(new Rect(120, 180, 100, 20), "Bottom-right");
		GUI.EndScrollView();*/
		// GUILayout.BeginArea(RoomList);
		// GUILayout.Space(100);
		
		
		//GUILayout.Label("Player name:", GUILayout.Width(150));
		//PhotonNetwork.playerName = GUILayout.TextField(PhotonNetwork.playerName);
		
		//GUILayout.Space(158);
		/*if (GUI.changed)
		        {
		            PlayerPrefs.SetString("playerName", PhotonNetwork.playerName);
		        }*/
		
		// Join room by title
		//GUILayout.BeginHorizontal();
		//GUILayout.Label("Roomname:", GUILayout.Width(150));
		
		/*if (GUILayout.Button("Create Room", GUILayout.Width(150)))
        {
            PhotonNetwork.CreateRoom(this.roomName, new RoomOptions() { maxPlayers = 10 }, null);
        }*/
		//GUILayout.EndHorizontal();
		// Create a room (fails if exist!)
		//GUILayout.BeginHorizontal();
		//GUILayout.FlexibleSpace();
		//this.roomName = GUILayout.TextField(this.roomName);
		/*if (GUILayout.Button("Join Room", GUILayout.Width(150)))
        {
            PhotonNetwork.JoinRoom(this.roomName);
        }*/
		//GUILayout.EndHorizontal();
		/*if (!string.IsNullOrEmpty(this.ErrorDialog))
        {
            GUILayout.Label(this.ErrorDialog);
            if (timeToClearDialog < Time.time)
            {
                timeToClearDialog = 0;
                this.ErrorDialog = "";
            }
        }
        GUILayout.Space(15);
        // Join random room
        GUILayout.BeginHorizontal();
        GUILayout.Label(PhotonNetwork.countOfPlayers + " users are online in " + PhotonNetwork.countOfRooms + " rooms.");
        GUILayout.FlexibleSpace();
       
        
        GUILayout.EndHorizontal();
        GUILayout.Space(15);
        if (PhotonNetwork.GetRoomList().Length == 0)
        {
            GUILayout.Label("Currently no games are available.");
            GUILayout.Label("Rooms will be listed here, when they become available.");
        }
        else
        {
            //GUILayout.Label(PhotonNetwork.GetRoomList().Length + " rooms available:");
            // Room listing: simply call GetRoomList: no need to fetch/poll whatever!
            this.scrollPos = GUILayout.BeginScrollView(this.scrollPos);
            foreach (RoomInfo roomInfo in PhotonNetwork.GetRoomList())
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(roomInfo.name + " " + roomInfo.playerCount + "/" + roomInfo.maxPlayers);
                if (GUILayout.Button("Join", GUILayout.Width(150)))
                {
                    PhotonNetwork.JoinRoom(roomInfo.name);
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndScrollView();
        }
        GUILayout.EndArea();*/
	}
	// We have two options here: we either joined(by title, list or random) or created a room.
	public void OnJoinedRoom()
	{
		Debug.Log("OnJoinedRoom");
	}
	public void OnPhotonCreateRoomFailed()
	{
		this.ErrorDialog = "Error: Can't create room (room name maybe already used).";
		Debug.Log("OnPhotonCreateRoomFailed got called. This can happen if the room exists (even if not visible). Try another room name.");
	}
	public void OnPhotonJoinRoomFailed(object[] cause)
	{
		this.ErrorDialog = "Error: Can't join room (full or unknown room name). " + cause[1];
		Debug.Log("OnPhotonJoinRoomFailed got called. This can happen if the room is not existing or full or closed.");
	}
	public void OnPhotonRandomJoinFailed()
	{
		this.ErrorDialog = "Error: Can't join random room (none found).";
		Debug.Log("OnPhotonRandomJoinFailed got called. Happens if no room is available (or all full or invisible or closed). JoinrRandom filter-options can limit available rooms.");
	}
	public void OnCreatedRoom()
	{
		Debug.Log("OnCreatedRoom");
		PhotonNetwork.LoadLevel(SceneNameWait);
	}
	public void OnDisconnectedFromPhoton()
	{
		Debug.Log("Disconnected from Photon.");
	}
	public void OnFailedToConnectToPhoton(object parameters)
	{
		this.connectFailed = true;
		Debug.Log("OnFailedToConnectToPhoton. StatusCode: " + parameters + " ServerAddress: " + PhotonNetwork.networkingPeer.ServerAddress);
	}
}
