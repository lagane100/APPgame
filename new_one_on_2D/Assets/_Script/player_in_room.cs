﻿using UnityEngine;
using System.Collections;

public class player_in_room : MonoBehaviour {
	
	private GameObject player1;
	private GameObject player2;
	private GameObject player3;
	private GameObject player4;
	private GameObject player5;
	private GameObject player6;
	private GameObject player7;
	private GameObject player8;
	private GameObject player9;
	private GameObject player10;

	private GameObject[] players = new GameObject[10];

	// Use this for initialization


	void Start () {
		player1 = GameObject.FindGameObjectWithTag ("player1");
		player1.SetActive (false);
		players [0] = player1;
		player2 = GameObject.FindGameObjectWithTag ("player2");
		player2.SetActive (false);
		players [1] = player2;
		player3 = GameObject.FindGameObjectWithTag ("player3");
		player3.SetActive (false);
		players [2] = player3;
		player4 = GameObject.FindGameObjectWithTag ("player4");
		player4.SetActive (false);
		players [3] = player4;
		player5 = GameObject.FindGameObjectWithTag ("player5");
		player5.SetActive (false);
		players [4] = player5;
		player6 = GameObject.FindGameObjectWithTag ("player6");
		player6.SetActive (false);
		players [5] = player6;
		player7 = GameObject.FindGameObjectWithTag ("player7");
		player7.SetActive (false);
		players [6] = player7;
		player8 = GameObject.FindGameObjectWithTag ("player8");
		player8.SetActive (false);
		players [7] = player8;
		player9 = GameObject.FindGameObjectWithTag ("player9");
		player9.SetActive (false);
		players [8] = player9;
		player10 = GameObject.FindGameObjectWithTag ("player10");
		player10.SetActive (false);
		players [9] = player10;
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 10; i++) {
			if(PhotonNetwork.playerList.Length > i){
				players[i].SetActive(true);
			}
			else{
				players[i].SetActive(false);
			}
		}
	}
}
