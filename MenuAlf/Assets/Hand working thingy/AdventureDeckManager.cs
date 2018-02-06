using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using NUnit.Framework;

/*
 * RANDOM SEARCH....
 * =======  Cards  ======
 * adventure DECK 						= 28 TOTAL
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
	public class AdventureDeckManager : MonoBehaviour {
	Dictionary<string, int> adventureDeck = new Dictionary<string, int>(){};
	public string TempCard = "";
	public Image image;
	int deckSize;
	public Text adventureCardText;
	List<GameObject> cardObjects = new List<GameObject>();

	 
	// Use this for initialization
	void Start () {
		adventureCardText.text = "Adventure Deck.";
		populateDeck ();
	}

	// Update is called once per frame
	void Update () {
		deckSize = getSizeOfDeck ();

		if (Input.GetKeyDown ("space")) {
			if (deckSize != 0) {
				TempCard = RandomCardPicker ();
				RemoveCard (TempCard);
				createCardObject (TempCard);
			}

			if (deckSize == 0){
				//Debug.Log ("Reshuffling Deck.");
				populateDeck ();
			}
		}

	}

	public int whichPlayer(){
		GameObject whichPlayer = GameObject.FindGameObjectWithTag("GameController");
		GameMasterScript playerScript = whichPlayer.GetComponent<GameMasterScript>();
		return playerScript.playerPlaying;
	}

	void createCardObject(string name){
		GameObject hand1 = GameObject.FindGameObjectWithTag ("HandOne");
		GameObject hand2 = GameObject.FindGameObjectWithTag ("HandTwo");

		int playersHand = whichPlayer ();
		GameObject instance = Instantiate(Resources.Load(name, typeof(GameObject))) as GameObject;

		if (playersHand == 1){
			giveCardtoHand (hand1, instance);
		}
		if (playersHand == 2) {
			giveCardtoHand (hand2, instance);
		} 
		else {
			return;
		}
		//(Instantiate (m_Prefab, position, rotation) as GameObject).transform.parent = parentGameObject.transform;
		// GameObject instance = Instantiate(Resources.Load("TestPrefab")) as GameObject;
	}

	[Test]
	void testHandObjects(string name){
	
		GameObject hand1 = GameObject.FindGameObjectWithTag ("HandOne");
		GameObject hand2 = GameObject.FindGameObjectWithTag ("HandTwo");

		int playersHand = whichPlayer ();
		GameObject instance = Instantiate(Resources.Load(name, typeof(GameObject))) as GameObject;

		if (playersHand == 1){
			giveCardtoHand (hand1, instance);
			Assert.AreEqual (1, playersHand);

		}
		if (playersHand == 2) {
			giveCardtoHand (hand2, instance);
			Assert.AreEqual (2, playersHand);
		} 
		else {
			Assert.Fail ();
			return;
		}
	}
	void giveCardtoHand(GameObject hand, GameObject card){
		card.transform.SetParent (hand.transform, false);
	}

	string RandomCardPicker(){
		int index = 0;
		int randInt = 0;

		string tempKey = "";
		foreach (KeyValuePair<string, int> item in adventureDeck) {
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
		if (adventureDeck.ContainsKey(tempKey) == true) {
			//Debug.Log ("ADVENTURE KEY: [" + tempKey + "] VALUE: [" + adventureDeck [tempKey] + "] SIZE : [" + getSizeOfDeck() + "]");
			adventureCardText.text = "Adventure Deck: " + tempKey;
			adventureDeck [tempKey] -= 1;
			if (adventureDeck [tempKey] == 0) {
				adventureDeck.Remove (tempKey);
			}
		} else {
			Debug.Log ("An Invalid Card has been randomly picked." + tempKey + " Error...");
		}
	}


	void populateDeck(){
		/* QUESTS */
		  adventureDeck.Add("Excalibur", 		2);
		  adventureDeck.Add("Lance"	, 		6);
		  adventureDeck.Add("Battle-ax",	8);
		  adventureDeck.Add("Sword",		16);
		  adventureDeck.Add("Horse",			11);
		  adventureDeck.Add("Dagger", 6);
		  /* FOES */
		  adventureDeck.Add("Dragon",	1);
		  adventureDeck.Add("Giant",					2);
		  adventureDeck.Add("Mordred",						4);
		  adventureDeck.Add("Green Knight",			2);
		  adventureDeck.Add("Black Knight",			3);
		  adventureDeck.Add("Evil Knight",			6);
		  adventureDeck.Add("Saxon Knight",			8);
		  adventureDeck.Add("Robber Knight",			7);
		  adventureDeck.Add("Saxons",			5);
		  adventureDeck.Add("Boar",			4);
		  adventureDeck.Add("Thieves",			8);

		  /* Tests */
		  adventureDeck.Add("Test of Valor",				2);
		  adventureDeck.Add("Test of Temptation",					2);
		  adventureDeck.Add("Test of Morgan Le Fey",						2);
		  adventureDeck.Add("Test of the Questing Beast",					2);
		  /* ALLIES */
		  adventureDeck.Add("Sir Galahad",							1);
		  adventureDeck.Add("Sir Lancelot",					1);
		  adventureDeck.Add("King Arthur", 1);
		  adventureDeck.Add("Sir Tristan",				1);
		  adventureDeck.Add("Sir Pellinore", 			1);
		  adventureDeck.Add("Sir Gawain",			1);
		  adventureDeck.Add("Sir Percival",			1);
		  adventureDeck.Add("Queen Quinevere",				1);
		  adventureDeck.Add("Queen Iseult",				1);
		  adventureDeck.Add("Merlin",				1);
	}


	int getSizeOfDeck(){
		return adventureDeck.Keys.Count;
	}

	public void DrawACard(Canvas playerDrawing, string cardName){
		//Debug.Log ("Drawing A Card");
		//GameObject cardThing = Instantiate (cardObjects.Find(cardName), playerDrawing.transform.GetChild(0).transform);
	}

}
