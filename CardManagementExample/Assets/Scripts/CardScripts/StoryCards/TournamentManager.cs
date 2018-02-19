using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameController;

public class TournamentManager: GameManager {
	
	// Use this for initialization
	//Users ht;
	//Users the = gameUsers.getUsers();
	bool pressed=false;
	int ai=0;
	List<Users> Kards;
	List<GameObject> Players= getplayers();
	void Start () {
		foreach (GameObject currentPlayer in Players) {
			//if the current player pressed the button
			//if (currentPlayer != ai && pressed == true) {
				//collect the cards from their hands they wish to play
					
			//}
		//Debug.Log(ht.getUsers();
		//Debug.Log(.getUsers());
		}
	}
	
	// Update i called once per frame
	void Update () {
		//myUsers.getUsers ();
	}

	//Collect a list of users
	//ask each player if they want to part-take and collect their cards
	//do some math can see who won.

	public void collectcards(){
		//
		}
	}