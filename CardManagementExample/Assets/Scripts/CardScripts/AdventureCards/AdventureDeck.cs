using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureDeck : MonoBehaviour {
	/* ADVENTURE DECK 					
	* Weapons 						= 49 Total
	* Excalibur						= 2
	* Lance							= 6
	* Battle-ax						= 8
	* Sword							= 16
	* Horse							= 11
	* Dagger						= 6
	* 
	* FOES 							= 50 Total
	* Dragon						= 1
	* Giant							= 2
	* Mordred						= 4
	* Green Knight					= 2
	* Black Knight					= 3
	* Evil Knight					= 6
	* Saxon Knight					= 8
	* Robber Knight					= 7 
	* Saxons						= 5
	* Boar							= 4
	* Thieves						= 8
	* 
	* TESTS 							= 8 Total
	* Test of Valor						= 2
	* Test of Temptation				= 2
	* Test of Morgan Le Fey				= 2
	* Test of the Questing Beast		= 2
	* 
	* ALLIES							= 10 Total
	* Sir Galahad						= 1
	* Sir Lancelot						= 1
	* King Arthur 						= 1
	* Sir Tristan						= 1
	* Sir Pellinore						= 1
	* Sir Gawain 						= 1
	* Sir Percival						= 1
	* Queen Quinevere					= 1
	* Queen Iseult						= 1
	* Merlin							= 1
	* 
	* AMOURS 							= 8 Total
	*/

	//public Text AdventureDCardText;
	Dictionary<string, int> adventureDeck = new Dictionary<string, int>(){};

	//public string TempCard = "";
	public string tempKey = "";
	public int deckSize;
	public int index;
	public int randInt;
	public GameObject adventureCardPrefab;
	List<string> foes = new List<string>(){"Thieves","Boar","Saxons","Robber Knight","Saxon Knight","Evil Knight","Black Knight","Green Knight","Giant","Dragon","Mordred"};
	List<string> weapons = new List<string>(){"Dagger","Sword","Horse","Battle-ax","Lance","Excalibur"};
	List<string> allies = new List<string>(){"Queen Iseult","Sir Galahad","King Arthur","Sir Lancelot","Sir Tristan","King Pellinore","Sir Percival","Sir Gawain","Queen Guinevere","Merlin","Armour"};
	List<string> tests = new List<string>(){"Test of Valor","Test of the Questing Beast","Test of Morgan Le Fey","Test of Temptation"};
	//Weapons, Foes, Tests
	//public Sprite[] cards;
	// Use this for initialization
	void Start () {

		populateDeck (adventureDeck);
		deckSize = getSizeOfDeck ();

	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject newCard = Draw ();
			newCard.transform.SetParent (GameObject.Find ("Hand").transform);
		}
	}

	void populateDeck(Dictionary<string, int> Deck){
		Deck.Add("Dagger", 6);
		Deck.Add("Sword", 16);
		Deck.Add("Battle-ax", 8);
		Deck.Add("Excalibur", 2);
		Deck.Add("Horse", 11);
		Deck.Add("Lance", 6);

		Deck.Add("Thieves", 8);
		Deck.Add("Boar", 4);
		Deck.Add("Saxons", 5);
		Deck.Add("Robber Knight", 7);
		Deck.Add("Saxon Knight", 8);
		Deck.Add("Evil Knight", 6);
		Deck.Add("Black Knight", 3);
		Deck.Add("Green Knight", 2);
		Deck.Add("Giant", 2);
		Deck.Add("Dragon", 1);
		Deck.Add("Mordred", 4);

		Deck.Add("Test of Valor", 2);
		Deck.Add("Test of the Questing Beast", 2);
		Deck.Add("Test of Morgan Le Fey", 2);
		Deck.Add("Test of Temptation", 2);

		Deck.Add("Queen Iseult", 1);
		Deck.Add("Sir Galahad", 1);
		Deck.Add("King Arthur", 1);
		Deck.Add("Sir Lancelot", 1);
		Deck.Add("Sir Tristan", 1);
		Deck.Add("King Pellinore", 1);
		Deck.Add("Sir Percival", 1);
		Deck.Add("Sir Gawain", 1);
		Deck.Add("Queen Guinevere", 1);
		Deck.Add("Merlin", 1);

		Deck.Add ("Amour", 8);
	}

	public GameObject Draw(){
		int index = 0;
		int randInt = 0;

		string tempKey = "";
		foreach(KeyValuePair<string, int> item in adventureDeck){
			randInt = Random.Range (0, getSizeOfDeck ());
			if(index == randInt){
				tempKey = item.Key;
				GameObject tempCard = Instantiate (adventureCardPrefab);/**DO NOT FORGET TO PARENT TO COORECT HAND, MIGHT NEED TO TAKE IN HAND OBJECTS**/

				tempCard.AddComponent<AdventureCard> ();
				tempCard.GetComponent<AdventureCard> ().setCard (tempKey);
				

				RemoveCard (tempKey);
				return tempCard;
			}
			index += 1;
		}

		return Draw ();
	}

	void RemoveCard(string tempKey){
		if (adventureDeck.ContainsKey (tempKey) == true) {
			adventureDeck [tempKey] -= 1;
			if(adventureDeck [tempKey] == 0){
				adventureDeck.Remove (tempKey);
			}
		}
		deckSize = getSizeOfDeck ();
		if(deckSize == 0){
			Debug.Log ("Reshuffling");
			populateDeck (adventureDeck);
		}
	}

	int getSizeOfDeck(){
		return adventureDeck.Keys.Count;
	}


}
