using System.Collections;
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


	public void EventFunctions(Event card){

	}

	// 1. King's Recoginition
	// - This next player(s) to complete a Quest will receive 2 extra shields.
	public void Kings_Recoginition(User player, Users players){
		
		//int shields = player.getShields () + 2;
		//player.setShields (shields);
	}

	// 2. Queen's Favor
	// - The lowest rank player(s) immediately receives 2 Adventure Cards.
	public List<GameObject> Queens_Favor(Users players){

		// Call Adventure Deck to pick up 2 cards.
		List<GameObject> lowestRankPlayers = players.getLowestRankUser();
		// highestRankPlayer.DiscardWeaponFunction();

		foreach (GameObject i in lowestRankPlayers) {
			// Call Game Manager to Draw 2 Adventure Cards.
//			Debug.Log("EventManager.cs :: Adding Adv. Cards to " + i.GetComponent<User>().getName());
		}

		return lowestRankPlayers;


			
	}

	// 3. Court Called to Camelot
	// - All Allies in play must be discarded.
	public void Court_Called_To_Camelot(Users players){
		// Call Hand Manager from each user to discard all cards.

		foreach (GameObject i in players.getUsers()) {
			string rank = i.GetComponent<User> ().getRank ();
			if (rank == "Squire") {
				Debug.Log("squireieiei");

				i.GetComponent<User> ().setBaseAttack (5);
			} else if (rank == "Knight") {
				Debug.Log("knighttt");

				i.GetComponent<User> ().setBaseAttack (10);
			} else if (rank == "Champion Knight") {
				Debug.Log("fdsfsdfsdf");

				i.GetComponent<User> ().setBaseAttack (20);
			}
		}	
	}

	// 4. Pox
	// - All players except the player drawing this card lose 1 shield.
	public void Pox(User player, Users players){
		foreach (GameObject i in players.getUsers()) {
			if(!player.Equals(i.GetComponent<User>())){
//				Debug.Log ("EventManager.cs :: Taking away from... " + i.GetComponent<User>().getName());
				int shields = i.GetComponent<User> ().getShields ();
				if (shields != 0) {
					i.GetComponent<User> ().setShields (shields - 1);
				}
			}
		}
	}

	// 5. Plague
	// - Drawer loses 2 shields if possible.
	public void Plague(User player){
		int shields = player.getShields ();
		if (shields != 0) {
			player.setShields (shields - 2);
		}
	}

	// 6. Chivalrous Deed
	// - Player(s) with both lowest rank and least amount of shields, receives 3 shields.
	public void Chivalrous_Deed(User player, Users players){
		List<GameObject> lowestRankPlayer = players.getLowestRankUser();
		foreach (GameObject i in lowestRankPlayer) {
			int shields = i.GetComponent<User>().getShields () + 3;
			i.GetComponent<User>().setShields (shields);
		}
	}

	// 7. Prosperity Throughout the Realm
	// - All players may immediately draw 2 Adventure Cards.
	public List<GameObject> Prosperity_Throughout_The_Realm(Users players){
		List<GameObject> allPlayers = players.getUsers();
		return allPlayers ;
	}

	// 8. King's Call to Arms
	// - The Highest Ranked Player(s) must place 1 weapon in the discard pile. If unable to do so 2 Foe Cards must be discarded.
	public void Kings_Call_To_Arms(User player, Users players){
	// function for highest rank player.
		List<GameObject> highestRankPlayer = players.getHighestRankUser();
		// highestRankPlayer.DiscardWeaponFunction();

	}

}
