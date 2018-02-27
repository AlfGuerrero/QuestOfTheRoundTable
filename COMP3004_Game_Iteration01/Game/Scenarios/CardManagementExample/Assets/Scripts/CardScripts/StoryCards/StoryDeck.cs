using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryDeck : MonoBehaviour {

	Dictionary<string, int> storyDeck = new Dictionary<string, int>(){};
	List<string> storyDeck2 = new List<string>();

	//public string TempCard = "";
	public string tempKey = "";
	public int deckSize;
	public int index;
	public int randInt;
	GameObject newCard;
	//public GameObject storyCardPrefab;
	List<string> events = new List<string>(){"King's Recognition","Queen's Favor","Court Called to Camelot","Pox","Plague","Chivalrous Deed",
												"Prosperity Throughout the Realm","King's Call to Arms"};

	List<string> quests = new List<string>(){"Boar Hunt", "Search for the Holy Grail", "Test of the Green Knight", 
												"Search for the Questing Beast", "Defend the Queen's Honor", "Rescue the Fair Maiden",
												"Journey Through the Enchanted Forest", "Vanquish King Arthur's Enemies", "Slay The Dragon", 
												"Repel the Saxon Raiders"};
	
	List<string> tournaments = new List<string>(){"Tournament at Camelot","Tournament at Orkney","Tournament at Tintagel","Tournament at York",};

	void Start () {

//		populateDeck (storyDeck);
//		deckSize = getSizeOfDeck ();

	}

	void Update(){
//		if (Input.GetKeyDown (KeyCode.Space)) {
//			if(newCard != null){
//				Destroy (newCard);
//			}
//			newCard = Draw ();
//			//newCard.transform.SetParent (GameObject.Find ("Hand").transform);
//
//		}

	}

	public void populateDeck(){
		/* QUESTS */
		storyDeck.Add("Search for the Holy Grail", 			1);
		storyDeck.Add("Test of the Green Knight"	, 			1);
		storyDeck.Add("Search for the Questing Beast",		1);
		storyDeck.Add("Defend the Queen's Honor",			1);
		storyDeck.Add("Rescue the Fair Maiden",				1);
		storyDeck.Add("Journey Through the Enchanted Forest",1);
		storyDeck.Add("Vanquish King Arthur's Enemies",		2);
		storyDeck.Add("Slay The Dragon",						1);
		storyDeck.Add("Boar Hunt",							2);
		storyDeck.Add("Repel the Saxon Raiders",				1);
		/* EVENTS */
		storyDeck.Add("King's Recognition",					2);
		storyDeck.Add("Queen's Favor",						2);
		storyDeck.Add("Court Called to Camelot",				2);
		storyDeck.Add("Pox",									1);
		storyDeck.Add("Plague",								1);
		storyDeck.Add("Chivalrous Deed",						1);
		storyDeck.Add("Prosperity Throughout the Realm",		1);
		storyDeck.Add("King's Call to Arms",					1);
		/* TOURNAMENTS */
		storyDeck.Add("Tournament at Camelot", 				1);
		storyDeck.Add("Tournament at Orkney",				1);
		storyDeck.Add("Tournament at Tintagel",				1);
		storyDeck.Add("Tournament at York",					1);	
	}

	public GameObject Draw(){
		int index = 0;
		int randInt = 0;

		string tempKey = "";
		foreach(KeyValuePair<string, int> item in storyDeck){
			randInt = Random.Range (0, getSizeOfDeck ());
			if(index == randInt){
				tempKey = item.Key;
				GameObject tempCard = Instantiate (Resources.Load("PreFabs/CurrentStoryCard") as GameObject);/**DO NOT FORGET TO PARENT TO COORECT HAND, MIGHT NEED TO TAKE IN HAND OBJECTS**/
//					Debug.Log (tempKey);
				if (quests.Contains (tempKey)) {
					tempCard.AddComponent<Quest> ();
					tempCard.GetComponent<Quest> ().setCard (tempKey);
//					Debug.Log (	"StoryDeck.cs Quest name :: " + tempCard.GetComponent<Quest> ().getName());
				} else if (events.Contains (tempKey)) {
					tempCard.AddComponent<Event> ();
					tempCard.GetComponent<Event> ().setCard (tempKey);
				} else if (tournaments.Contains (tempKey)) {
					tempCard.AddComponent<Tournament> ();
					tempCard.GetComponent<Tournament> ().setCard (tempKey);
				}
				//tempCard.AddComponent<Ally> ();
				//tempCard.GetComponent<Ally> ().setCard (tempKey);
				RemoveCard (tempKey);
				return tempCard;
			}
			index += 1;
		}

		return Draw ();
	}

	public void RemoveCard(string tempKey){
		if (storyDeck.ContainsKey (tempKey) == true) {
			storyDeck [tempKey] -= 1;
			if(storyDeck [tempKey] == 0){
				storyDeck.Remove (tempKey);
			}
		}
		deckSize = getSizeOfDeck ();
		if(deckSize == 0){
			Debug.Log ("Reshuffling");
			populateDeck ();
		}
	}

	public int getSizeOfDeck(){
		return storyDeck.Keys.Count;
	}

	public void populateDeck(List<string> thingsToAdd){
		storyDeck2 = thingsToAdd;
	}

	public GameObject Draw2(string card){

		GameObject tempCard = Instantiate (Resources.Load("PreFabs/CurrentStoryCard") as GameObject);   /**DO NOT FORGET TO PARENT TO COORECT HAND, MIGHT NEED TO TAKE IN HAND OBJECTS**/
		if (quests.Contains (card)) {
			tempCard.AddComponent<Quest> ();
			tempCard.GetComponent<Quest> ().setCard (card);
		} else if (events.Contains (card)) {
			tempCard.AddComponent<Event> ();
			tempCard.GetComponent<Event> ().setCard (card);
		} else if (tournaments.Contains (card)) {
			tempCard.AddComponent<Tournament> ();
			tempCard.GetComponent<Tournament> ().setCard (card);
		}

		return tempCard;
	}
}
