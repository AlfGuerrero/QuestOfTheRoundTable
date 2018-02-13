﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour {
	/*
	 * Event Cards
	 * 1. King's Recoginition
	 * - This next player(s) to complete a Quest will receive 2 extra shields.
	 * 2. Queen's Favor
	 * - The lowest rank player(s) immediately receives 2 Adventure Cards.
	 * 3. Court Called to Camelot
	 * - All Allies in play must be discarded.
	 * 4. Pox
	 * - All players except the player drawing this card lose 1 shield.
	 * 5. Plague
	 * - Drawer loses 2 shields if possible.
	 * 6. Chivalrous Deed
	 * - Player(s) with both lowest rank and least amount of shields, receives 3 shields.
	 * 7. Prosperity Throughout the Realm
	 * - All players may immediately draw 2 Adventure Cards.
	 * 8. King's Call to Arms
	 * - The Highest Ranked Player(s) must place 1 weapon in the discard pile. If unable to do so 2 Foe Cards must be discarded.
	 *
	 * Shields
	 * Allys
	 * Adventure Cards
	 * Weapon Cards
	 * 2 Foe Cards
	*/

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void EventFunctions(Event card){

	}

	// 1. King's Recoginition
	// - This next player(s) to complete a Quest will receive 2 extra shields.
	public void Kings_Recoginition(User player, Users players){
		int shields = player.getShields () + 2;
		player.setShields (shields);
	}

	// 2. Queen's Favor
	// - The lowest rank player(s) immediately receives 2 Adventure Cards.
	public void Queens_Favor(User player, Users players){
		// function to find lowest rank player.

		// Call Adventure Deck to pick up 2 cards.

	}

	// 3. Court Called to Camelot
	// - All Allies in play must be discarded.
	public void Court_Called_To_Camelot(Users players){
		// Call Hand Manager from each user to discard all cards.

	}

	// 4. Pox
	// - All players except the player drawing this card lose 1 shield.
	public void Pox(User player, Users players){

		//Function to get all User Objects in users.
		// for (i = 0; i < players.getNumberOfUsers(); i++){
		// 	// if players[i] != player
		// 	// 		then  int rank = players[i].getRank() - 1;
		// 	// 					players[i].setRank(rank);
		// }


	}

	// 5. Plague
	// - Drawer loses 2 shields if possible.
	public void Plague(User player){
		int shields = player.getShields () - 2;
		player.setShields (shields);

	}

	// 6. Chivalrous Deed
	// - Player(s) with both lowest rank and least amount of shields, receives 3 shields.
	public void Chivalrous_Deed(User player, Users players){
		int shields = player.getShields () + 3;
		player.setShields (shields);

	}

	// 7. Prosperity Throughout the Realm
	// - All players may immediately draw 2 Adventure Cards.
	public void Prosperity_Throughout_The_Realm(Users players){

		// Call game manager. .....
	}

	// 8. King's Call to Arms
	// - The Highest Ranked Player(s) must place 1 weapon in the discard pile. If unable to do so 2 Foe Cards must be discarded.
	public void Kings_Call_To_Arms(User player, Users players){
	// function for highest rank player.
	/*
		User highestRankUser;
		for (int i = 0; i < players.getNumberOfUsers(); i++){
			player.getRank().compareTo(players[i].getRank()){

			}
		}
		/* In Event Manager Possibly.
		public static List<User> getAllUsers(){
			 return users;
		}
		*/
	//*/
	}
}