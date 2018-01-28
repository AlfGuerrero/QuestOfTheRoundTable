using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

	Dictionary<string, int> storyDeck = new Dictionary<string, int>()
	{
		/* QUESTS */
		{"Search for the Holy Grail", 		1},
		{"Test of the Green Knight"	, 		1},
		{"Search for the Questing Beast",	1},
		{"Defend the Queen's Honor",		1},
		{"Rescue the Fair Maiden",			1},
		{"Journey Through the Enchanted Forest",1},
		{"Vanquish King Arthur's Enemies",	2},
		{"Slay the Dragon",					1},
		{"Boar Hunt",						2},
		{"Repel the Saxor Raiders",			1},
		/* EVENTS */
		{"Kings Recognition",				2},
		{"Queen's Favor",					2},
		{"Court Called to Camelot",			2},
		{"Pox",								1},
		{"Plague",							1},
		{"Chivalous Deed",					1},
		{"Prosperity Throughout the Realm", 1},
		{"King's Call to Arms",				1},
		/* TOURNAMENTS */
		{"Tournament at Camelot ", 			1},
		{"Tournament at Orkney",			1},
		{"Tournament at Tintagel",			1},
		{"Tournament at York",				1}
	};
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			
			RandomCardPicker ();
		}

		// RANDOm search than decrement the card that has been found...
	}

	void RandomCardPicker(){

		int index = 0;
		string tempKey = "";
		foreach (KeyValuePair<string, int> item in storyDeck) {
			int randInt =  Random.Range (0, storyDeck.Keys.Count);
			if (index == randInt) {
				tempKey = item.Key;
				break;
			}
			index += 1;
		}			
		if (tempKey != "") {
			print ("Removing Card " + tempKey + " Size of Deck: " + storyDeck.Keys.Count);

			storyDeck.Remove (tempKey);
		}
	}
}
	