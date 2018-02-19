using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryDeck : MonoBehaviour {

	Dictionary<string, int> storyDeck = new Dictionary<string, int>(){};

	//public string TempCard = "";
	public string tempKey = "";
	public int deckSize;
	public int index;
	public int randInt;
	//public GameObject storyCardPrefab;
	List<string> events = new List<string>(){"Kings Recoginition","Queens","Saxons","Robber Knight","Saxon Knight","Evil Knight","Black Knight","Green Knight","Giant","Dragon","Mordred"};
	List<string> quests = new List<string>(){"Dagger","Sword","Horse","Battle-ax","Lance","Excalibur"};
	List<string> tournaments = new List<string>(){"Queen Iseult","Sir Galahad","King Arthur","Sir Lancelot","Sir Tristan","King Pellinore","Sir Percival","Sir Gawain","Queen Guinevere","Merlin","Armour"};

	void Start () {

		populateDeck (storyDeck);
		deckSize = getSizeOfDeck ();

	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject newCard = Draw ();
			//newCard.transform.SetParent (GameObject.Find ("Hand").transform);
		}
	}

	void populateDeck(Dictionary<string, int> Deck){
		/* QUESTS */
		Deck.Add("Search for the Holy Grail", 			1);
		Deck.Add("Test of the Green Knight"	, 			1);
		Deck.Add("Search for the Questing Beast",		1);
		Deck.Add("Defend the Queen's Honor",			1);
		Deck.Add("Rescue the Fair Maiden",				1);
		Deck.Add("Journey Through the Enchanted Forest",1);
		Deck.Add("Vanquish King Arthur's Enemies",		2);
		Deck.Add("Slay the Dragon",						1);
		Deck.Add("Boar Hunt",							2);
		Deck.Add("Repel the Saxon Raiders",				1);
		/* EVENTS */
		Deck.Add("Kings Recognition",					2);
		Deck.Add("Queen's Favor",						2);
		Deck.Add("Court Called to Camelot",				2);
		Deck.Add("Pox",									1);
		Deck.Add("Plague",								1);
		Deck.Add("Chivalrous Deed",						1);
		Deck.Add("Prosperity Throughout the Realm",		1);
		Deck.Add("King's Call to Arms",					1);
		/* TOURNAMENTS */
		Deck.Add("Tournament at Camelot", 				1);
		Deck.Add("Tournament at Orkney",				1);
		Deck.Add("Tournament at Tintagel",				1);
		Deck.Add("Tournament at York",					1);	
	}

	public GameObject Draw(){
		int index = 0;
		int randInt = 0;

		string tempKey = "";
		foreach(KeyValuePair<string, int> item in storyDeck){
			randInt = Random.Range (0, getSizeOfDeck ());
			if(index == randInt){
				tempKey = item.Key;
				GameObject tempCard = Instantiate (new GameObject("currentStoryCard"));/**DO NOT FORGET TO PARENT TO COORECT HAND, MIGHT NEED TO TAKE IN HAND OBJECTS**/
				//tempCard.AddComponent<SpriteRenderer>().sprite = Resources.Load("StoryCards/"+)
				/*if (foes.Contains (tempKey)) {
					tempCard.AddComponent<Foe> ();
					tempCard.GetComponent<Foe> ().setCard (tempKey);
				} else if (weapons.Contains (tempKey)) {
					tempCard.AddComponent<Weapon> ();
					tempCard.GetComponent<Weapon> ().setCard (tempKey);
				} else if (events.Contains (tempKey)) {
					tempCard.AddComponent<Ally> ();
					tempCard.GetComponent<Ally> ().setCard (tempKey);
				}*/
				//tempCard.AddComponent<Ally> ();
				//tempCard.GetComponent<Ally> ().setCard (tempKey);
				RemoveCard (tempKey);
				return tempCard;
			}
			index += 1;
		}

		return Draw ();
	}

	void RemoveCard(string tempKey){
		if (storyDeck.ContainsKey (tempKey) == true) {
			storyDeck [tempKey] -= 1;
			if(storyDeck [tempKey] == 0){
				storyDeck.Remove (tempKey);
			}
		}
		deckSize = getSizeOfDeck ();
		if(deckSize == 0){
			Debug.Log ("Reshuffling");
			populateDeck (storyDeck);
		}
	}

	int getSizeOfDeck(){
		return storyDeck.Keys.Count;
	}


}
