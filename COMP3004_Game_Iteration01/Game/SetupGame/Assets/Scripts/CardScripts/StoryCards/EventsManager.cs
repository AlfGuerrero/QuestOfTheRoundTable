using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestGame;

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
	protected QuestGame.Logger	logger;

	// Use this for initialization
	void Start () {
		logger = new QuestGame.Logger ();

	}

	// Update is called once per frame
	void Update () {

	}

	public void EventFunctions(Event card){

	}

	// 1. King's Recoginition
	// - This next player(s) to complete a Quest will receive 2 extra shields.
	public void Kings_Recoginition(User player, Users players){
		logger.test ("EventsManager.cs :: Event :: Running King's Recoginition.");
		GameObject.Find ("GameManager").GetComponent<GameManager> ().KingsRecognition = true;
//		int shields = player.getShields () + 2;
//		player.setShields (shields);
	}

	// 2. Queen's Favor
	// - The lowest rank player(s) immediately receives 2 Adventure Cards.
	public List<GameObject> Queens_Favor(Users players){
		logger.test ("EventsManager.cs :: Event :: Running Queen's Favor.");
		List<GameObject> lowestRankPlayers = players.getLowestRankUser();
		foreach (GameObject i in lowestRankPlayers) {
			logger.info ("EventsManager.cs :: " + i.GetComponent<User>().getName() + " Receives 2 Adventure Cards.");
		}
		return lowestRankPlayers;
	}

	// 3. Court Called to Camelot
	// - All Allies in play must be discarded.
	public void Court_Called_To_Camelot(Users players){
		logger.test ("EventsManager.cs :: Event :: Running Court Called To Camelot.");
		// Call Hand Manager from each user to discard all cards.
		foreach (GameObject i in players.getUsers()) {
			string rank = i.GetComponent<User> ().getRank ();
			int baseAttack = i.GetComponent<User> ().getbaseAttack ();
			logger.info ("EventsManager.cs :: " + i.GetComponent<User>().getName() + " Attack: " + baseAttack);
			if (rank == "Squire") {
				i.GetComponent<User> ().setBaseAttack (5);
			} else if (rank == "Knight") {
				i.GetComponent<User> ().setBaseAttack (10);
			} else if (rank == "Champion Knight") {
				i.GetComponent<User> ().setBaseAttack (20);
			}
			logger.info ("EventsManager.cs :: " + i.GetComponent<User>().getName() + " Attack: " + baseAttack);
		}	
	}

	// 4. Pox
	// - All players except the player drawing this card lose 1 shield.
	public void Pox(User player, Users players){
		logger.test ("EventsManager.cs :: Running Pox.");
		foreach (GameObject i in players.getUsers()) {
			int shields = i.GetComponent<User> ().getShields ();
			logger.info ("EventsManager.cs :: " + i.GetComponent<User>().getName() + " number of shields: " + shields);
			if(!player.Equals(i.GetComponent<User>())){
				if (shields != 0) {
					i.GetComponent<User> ().setShields (shields - 1);
				}
			}
			logger.info ("EventsManager.cs :: " + i.GetComponent<User>().getName() + " number of shields: " + shields);
		}
	}

	// 5. Plague
	// - Drawer loses 2 shields if possible.
	public void Plague(User player){
		logger.test ("EventsManager.cs :: Running Plague.");
		int shields = player.getShields ();
		logger.info ("EventsManager.cs :: "  + player.getName() + " number of shields: " + shields);
		if (shields != 0) {
			player.setShields (shields - 2);
		}
		logger.info ("EventsManager.cs :: "  + player.getName() + " number of shields: " + shields);
	}

	// 6. Chivalrous Deed
	// - Player(s) with both lowest rank and least amount of shields, receives 3 shields.
	public void Chivalrous_Deed(User player, Users players){
		logger.test ("EventsManager.cs :: Running Chivalrous Deed.");
		List<GameObject> lowestRankPlayer = players.getLowestRankUser();
		foreach (GameObject i in lowestRankPlayer) {
			logger.info ("EventsManager.cs ::  "+  i.GetComponent<User>().getName() + " number of shields: " + i.GetComponent<User>().getShields ());
			int shields = i.GetComponent<User>().getShields () ;
			i.GetComponent<User>().setShields (shields + 3);
			logger.info ("EventsManager.cs ::  "+  i.GetComponent<User>().getName() + " number of shields: " + i.GetComponent<User>().getShields ());
		}

	}

	// 7. Prosperity Throughout the Realm
	// - All players may immediately draw 2 Adventure Cards.
	public List<GameObject> Prosperity_Throughout_The_Realm(Users players){
		logger.test ("EventManager.cs :: Running Prosperity Throughout the Realm.");
		List<GameObject> allPlayers = players.getUsers();
		return allPlayers ;
	}

	// 8. King's Call to Arms
	// - The Highest Ranked Player(s) must place 1 weapon in the discard pile. If unable to do so 2 Foe Cards must be discarded.
	public List<GameObject> Kings_Call_To_Arms(User player, Users players){
		logger.test ("EventManager.cs :: Running King's Call to Arms.");

		List<GameObject> highestRankPlayer = players.getHighestRankUser();
		// highestRankPlayer.DiscardWeaponFunction();
		return highestRankPlayer;
	}

}
