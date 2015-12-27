using UnityEngine;
using System.Collections;

public class deck_manage : Photon.MonoBehaviour {

	private GameObject item1;
	private GameObject item2;
	private GameObject item3;
	private GameObject item4;
	private GameObject item5;
	private GameObject item6;
	private GameObject item7;
	private GameObject item8;
	private GameObject item9;
	private GameObject item10;
	private GameObject item11;
	private GameObject item12;
	private GameObject item13;
	private GameObject item14;
	private GameObject item15;
	private GameObject item16;
	private GameObject item17;
	private GameObject item18;
	private GameObject item19;
	private GameObject item20;
	private GameObject item21;

	private GameObject[] itemDeck = new GameObject[21];

	// Use this for initialization
	void Start () {
		item1 = GameObject.FindGameObjectWithTag ("broken_mirror");
		item1.SetActive (false);
		itemDeck [0] = item1;
		item2 = GameObject.FindGameObjectWithTag ("bullwhip");
		item2.SetActive (false);
		itemDeck [1] = item2;
		item3 = GameObject.FindGameObjectWithTag ("coat");
		item3.SetActive (false);
		itemDeck [2] = item3;
		item4 = GameObject.FindGameObjectWithTag ("cutter");
		item4.SetActive (false);
		itemDeck [3] = item4;
		item5 = GameObject.FindGameObjectWithTag ("dark_jewel");
		item5.SetActive (false);
		itemDeck [4] = item5;
		item6 = GameObject.FindGameObjectWithTag ("dictionary");
		item6.SetActive (false);
		itemDeck [5] = item6;
		item7 = GameObject.FindGameObjectWithTag ("glove");
		item7.SetActive (false);
		itemDeck [6] = item7;
		item8 = GameObject.FindGameObjectWithTag ("golden_ring");
		item8.SetActive (false);
		itemDeck [7] = item8;
		item9 = GameObject.FindGameObjectWithTag ("knife");
		item9.SetActive (false);
		itemDeck [8] = item9;
		item10 = GameObject.FindGameObjectWithTag ("privilege");
		item10.SetActive (false);
		itemDeck [9] = item10;
		item11 = GameObject.FindGameObjectWithTag ("secret_bag_grail");
		item11.SetActive (false);
		itemDeck [10] = item11;
		item12 = GameObject.FindGameObjectWithTag ("secret_bag_key");
		item12.SetActive (false);
		itemDeck [11] = item12;
		item13 = GameObject.FindGameObjectWithTag ("sextent");
		item13.SetActive (false);
		itemDeck [12] = item13;
		item14 = GameObject.FindGameObjectWithTag ("single_glass");
		item14.SetActive (false);
		itemDeck [13] = item14;
		item15 = GameObject.FindGameObjectWithTag ("solo_declare_ring");
		item15.SetActive (false);
		itemDeck [14] = item15;
		item16 = GameObject.FindGameObjectWithTag ("key 1");
		item16.SetActive (false);
		itemDeck [15] = item16;
		item17 = GameObject.FindGameObjectWithTag ("key 2");
		item17.SetActive (false);
		itemDeck [16] = item17;
		item18 = GameObject.FindGameObjectWithTag ("key 3");
		item18.SetActive (false);
		itemDeck [17] = item18;
		item19 = GameObject.FindGameObjectWithTag ("grail 1");
		item19.SetActive (false);
		itemDeck [18] = item19;
		item20 = GameObject.FindGameObjectWithTag ("grail 2");
		item20.SetActive (false);
		itemDeck [19] = item20;
		item21 = GameObject.FindGameObjectWithTag ("grail 3");
		item21.SetActive (false);
		itemDeck [20] = item21;

		foreach (PhotonPlayer player in PhotonNetwork.playerList) {
			if(player.name.Equals(PlayerPrefs.GetString("nickname"))){
				int num = Random.Range(0,20);
				itemDeck [num].SetActive (true);
				GameObject.FindGameObjectWithTag (itemDeck [num].name).transform.parent = GameObject.FindGameObjectWithTag ("Cards").transform;
				photonView.RPC("moveDeck",PhotonTargets.Others, num);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	[PunRPC]
	public void moveDeck(int num){
		Debug.Log (itemDeck[num]);
		itemDeck [num].SetActive (true);
		Destroy (GameObject.FindGameObjectWithTag (itemDeck [num].name));
	}
}
