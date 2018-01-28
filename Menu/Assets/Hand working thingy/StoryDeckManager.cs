using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * RANDOM SEARCH.... 
 * =======  Cards  ======
 * STORY DECK 						= 28 TOTAL
 * QUESTS							= 13 Total
 * Search for the Holy Grail		= 1
 * Test of the Green Knight			= 1
 * Search for the Questing Beast    = 1
 * Defend the Queen's Honor			= 1
 * Rescue the Fair Maiden			= 1
 * Journey Through the Enchanted F. = 1
 * Vanquish King Arthur's Enemies	= 2
 * Slay the Dragon					= 1
 * Boar Hunt						= 2
 * Repel the Saxor Raiders			= 2 
 * 
 * TOURNAMENTS						= 4 Total
 * Tournament at Camelot 			= 1
 * Tournament at Orkney				= 1
 * Tournament at Tintagel			= 1
 * Tournament at York				= 1
 * 
 * EVENTS 							= 11 Total
 * Kings Recognition 				= 2
 * Queen's Favor 					= 2
 * Court Called to Camelot			= 2
 * Pox								= 1
 * Plague							= 1
 * Chivalous Deed					= 1
 * Prosperity Throughout the Realm 	= 1
 * King's Call to Arms				= 1
 * ==========================================
 */
/* ADVENTURE DECK 					
* Weapons 							= 49 Total
	* Excalibur						= 2
	* Lance							= 6
	* Battle-ax						= 8
	* Sword							= 16
	* Horse							= 11
	* Dagger							= 6
	* 
	* FOES 							= 50 Total
	* Dragon							= 1
	* Giant							= 2
	* Mordred							= 4
	* Green Knight						= 2
	* Black Knight						= 3
	* Evil Knight						= 6
	* Saxon Knight						= 8
	* Robber Knight					= 7 
	* Saxons							= 5
	* Boar								= 4
	* Thieves							= 8
	* 
	* TESTS 							= 8 Total
	* Test of Valor					= 2
	* Test of Temptation				= 2
	* Test of Morgan Le Fey			= 2
	* Test of the Questing Beast		= 2
	* 
	* ALLIES							= 10 Total
	* Sir Galahad						= 1
	* Sir Lancelot						= 1
	* King Arthur 						= 1
	* Sir Tristan						= 1
	* Sir Pellinore					= 1
	* Sir Gawain 						= 1
	* Sir Percival						= 1
	* Queen Quinevere					= 1
	* Queen Iseult						= 1
	* Merlin							= 1
	* 
	* AMOURS 							= 8 Total
	*/
	public class StoryDeckManager : MonoBehaviour {
	Dictionary<string, int> storyDeck = new Dictionary<string, int>(){};
	string TempCard = "";
	int deckSize;
	public Text storyCardText;
	// Use this for initialization
	void Start () {
		storyCardText.text = "Story Deck.";
		populateDeck ();
	}

	// Update is called once per frame
	void Update () {
		deckSize = getSizeOfDeck ();

		if (Input.GetKeyDown ("space")) {
			if (deckSize != 0) {
				
				TempCard = RandomCardPicker ();
				RemoveCard (TempCard);
			}

			if (deckSize == 0){
				Debug.Log ("Reshuffling Deck.");
				populateDeck ();
			} 
		}

	}

	string RandomCardPicker(){
		int index = 0;
		int randInt = 0;

		string tempKey = "";
		foreach (KeyValuePair<string, int> item in storyDeck) {
			randInt =  Random.Range (0, getSizeOfDeck()); 
			if (index == randInt) {
				tempKey = item.Key;
				return tempKey;
			}
			index += 1;
		}

		return  RandomCardPicker();	// If no card has been found: RECURSIFY

	}

	void RemoveCard(string tempKey){
		if (storyDeck.ContainsKey(tempKey) == true) {
			Debug.Log ("KEY: [" + tempKey + "] VALUE: [" + storyDeck [tempKey] + "] SIZE : [" + getSizeOfDeck() + "]");
			storyCardText.text = "Story Deck: " + tempKey;
			storyDeck [tempKey] -= 1;
			if (storyDeck [tempKey] == 0) {
				storyDeck.Remove (tempKey);
			}
		} else {
			Debug.Log ("An Invalid Card has been randomly picked." + tempKey + " Error...");
		}
	}
		
	void populateDeck(){
		/* QUESTS */
		storyDeck.Add("Search for the Holy Grail", 		1);
		storyDeck.Add("Test of the Green Knight"	, 	1);
		storyDeck.Add("Search for the Questing Beast",	1);
		storyDeck.Add("Defend the Queen's Honor",		1);
		storyDeck.Add("Rescue the Fair Maiden",			1);
		storyDeck.Add("Journey Through the Enchanted Forest",1);
		storyDeck.Add("Vanquish King Arthur's Enemies",	2);
		storyDeck.Add("Slay the Dragon",				1);
		storyDeck.Add("Boar Hunt",						2);
		storyDeck.Add("Repel the Saxor Raiders",		1);
		/* EVENTS */
		storyDeck.Add("Kings Recognition",				2);
		storyDeck.Add("Queen's Favor",					2);
		storyDeck.Add("Court Called to Camelot",		2);
		storyDeck.Add("Pox",							1);
		storyDeck.Add("Plague",							1);
		storyDeck.Add("Chivalous Deed",					1);
		storyDeck.Add("Prosperity Throughout the Realm",1);
		storyDeck.Add("King's Call to Arms",			1);
		/* TOURNAMENTS */
		storyDeck.Add("Tournament at Camelot ", 		1);
		storyDeck.Add("Tournament at Orkney",			1);
		storyDeck.Add("Tournament at Tintagel",			1);
		storyDeck.Add("Tournament at York",				1);	
	}		


	int getSizeOfDeck(){
		return storyDeck.Keys.Count;
	}

}
	