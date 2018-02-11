using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureDeck<T> : MonoBehaviour {
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
	Dictionary<AdventureCard<T>, int> adventureDeck = new Dictionary<AdventureCard<T>, int>(){};

	public string TempCard = "";
	public string tempKey = "";
	public int deckSize;
	public int index;
	public int randInt;

	//Weapons, Foes, Tests
	public Sprite[] cards;
	// Use this for initialization
	void Start () {
		GameObject temp = Instantiate(new GameObject());
		AdventureCard<Ally> borp = new AdventureCard<Ally>("Ally","Sir Galahad");

		//temp.


		populateDeck (adventureDeck);
		foreach (KeyValuePair<AdventureCard<T>, int> item in adventureDeck) {
			print ((item.Key).getchildObject());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void populateDeck(Dictionary<AdventureCard<T>, int> Deck){
		/* QUESTS */
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 1);
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 1);
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 1);
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 1);
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 1);
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 1);
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 2);
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 1);
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 2);
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 1);
		/* EVENTS */
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 2);
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 2);
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 2);
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 1);
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 1);
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 1);
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 1);
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 1);
		/* TOURNAMENTS */
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 1);
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 1);
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 1);
		Deck.Add(new AdventureCard<T>("Weapon","Dagger"), 1);	
	}
}
