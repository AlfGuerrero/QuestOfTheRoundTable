using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMasterScript : MonoBehaviour {

	//Things to keep track of: Num players, Order of play

	int numPlayers;
	public int playerPlaying;
	AdventureDeckManager adm;
	public Canvas [] Players;
	//public List<Canvas> Players = new List<Canvas>();


	// Use this for initialization
	void Start () {
		adm =  GameObject.Find ("AdventureDeck").GetComponent<AdventureDeckManager> ();
		InitializeGame ();

		numPlayers = 2;
		playerPlaying = 1;

		//get PLayer's canvases
		Players = GameObject.FindObjectsOfType<Canvas>();

		SwitchPlayers ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void InitializeGame(){

	}

	public void SwitchPlayers(){


		for (int i = 0; i < Players [playerPlaying-1].transform.childCount; i++) {
			Players [playerPlaying-1].transform.GetChild (i).gameObject.SetActive (false);
		}

		if(playerPlaying>=numPlayers){
			playerPlaying = 1;
		}else{
			playerPlaying++;
		}

		//Debug.Log (playerPlaying-1);

		for (int i = 0; i < Players [playerPlaying-1].transform.childCount; i++) {
			//Debug.Log (Players [playerPlaying-1].transform.childCount);
			Players [playerPlaying-1].transform.GetChild (i).gameObject.SetActive (true);
		}
			
		adm.DrawACard (Players[playerPlaying - 1], adm.TempCard);
	}
}
