using UnityEngine;
using System.Collections;
using ExitGames.Client.Photon;

public class NewBehaviourScript : IPhotonPeerListener {

	PhotonPeer peer;

	public bool Connect()
	{
		peer = new PhotonPeer (this, ConnectionProtocol.Udp);
		if( peer.Connect("app.exitgamescloud.com:5055","912399f0-c8d8-4d11-bf0a-88924aa6ba31"))
		{
			return true;
		}
		return false;
	}
	public void DebugReturn (DebugLevel level, string message)
	{
		throw new System.NotImplementedException ();
	}

	public void OnOperationResponse (OperationResponse operationResponse)
	{
		throw new System.NotImplementedException ();
	}

	
	public void OnStatusChanged (StatusCode statusCode)
	{
		Debug.Log (statusCode.ToString ());
		switch (statusCode)
		{
		case StatusCode.Connect: 					// connect success
			Debug.Log("connect success");
			break;
		case StatusCode.Disconnect: 				// disconnected
			Debug.Log("disconnect from server");
			break;
		case StatusCode.DisconnectByServerUserLimit: //  limit on connected user
			Debug.Log ("room full");
			break;
		case StatusCode.ExceptionOnConnect:			//	error on connection
			Debug.Log("connection error");
			break;
		case StatusCode.DisconnectByServer:			// disconnected by server
			Debug.Log("disconnect by server");
			break;
		case StatusCode.TimeoutDisconnect:			// disconnected while timeout
			Debug.Log("time out");
			break;
		case StatusCode.Exception:					// other exception
		case StatusCode.ExceptionOnReceive:
			Debug.Log("unexpect error");
			break; 
		}
	}

	public void OnEvent (EventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	public void Disconnect()
	{
		peer.Disconnect ();
	}

	public void Service()
	{
		peer.Service ();
	}
}
