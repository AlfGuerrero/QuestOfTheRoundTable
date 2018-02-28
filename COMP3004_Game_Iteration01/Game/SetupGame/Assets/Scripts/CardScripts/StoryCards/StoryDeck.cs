﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestGame;

public class StoryDeck : MonoBehaviour {

	//Dictionary<string, int> storyDeck = new Dictionary<string, int>(){};
	List<string> storyDeck= new List<string>();
	QuestGame.Logger logger = new QuestGame.Logger ();
	//public string TempCard = "";
	public string temp = "";
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
	public void populateEventsDeck(){
		logger.info ("StoryDeck.cs :: Populating Deck with Event Cards.");

		List<string> RList1 = new List<string> {
			"King's Recognition", "Queen's Favor"
		};
		List<string> RList4 = new List<string> {
			"Prosperity Throughout the Realm", "King's Call to Arms"
		};
		List<string> RList3 = new List<string> {
			"Court Called to Camelot", "Pox"
		};
		List<string> RList5 = new List<string> {
			"Plague", "Chivalrous Deed"
		};
			
	}

	public void populateDeck(){
		logger.info ("StoryDeck.cs :: Populating Deck with cards.");

		List<string> RList1 = new List<string> {
//			"Search for the Holy Grail",
//			"Rescue the Fair Maiden",
//			"Slay The Dragon",
			"King's Recognition",
			"King's Call to Arms",
//			"Tournament at Camelot"
		};
		List<string> RList2 = new List<string> {
//			"Test of the Green Knight",
			"Queen's Favor",
//			"Journey Through the Enchanted Forest",
//			"Boar Hunt",
			"Queen's Favor",
			"Court Called to Camelot",
//			"Tournament at Tintagel"
		};

		List<string> RList3 = new List<string> {
//			"Defend the Queen's Honor",
//			"Tournament at York",
//			"Vanquish King Arthur's Enemies",
//			"Boar Hunt",
//			"King's Recognition",
			"Pox",
			"Plague",
			"Chivalrous Deed",
//			"Tournament at Orkney"
		};
		List<string> RList4 = new List<string> {
//			"Search for the Questing Beast",
//			"Vanquish King Arthur's Enemies",
//			"Repel the Saxon Raiders",
			"Court Called to Camelot",
//			"Prosperity Throughout the Realm"
		};

		int ranStart = 0;
		while (RList1.Count != 0 && RList2.Count != 0 && RList3.Count != 0 && RList4.Count != 0) {

			ranStart = Random.Range (1, 4);

			if (ranStart == 1) {
				if (RList1.Count >= 1) {
					int Ran = Random.Range (0, RList1.Count);
//					Debug.Log (RList1 [Ran]);
					storyDeck.Add (RList1 [Ran]);
					RList1.RemoveAt (Ran);
				} else {
					ranStart = 2;
				}	
			}
			if (ranStart == 2) {
				if (RList2.Count >= 1) {
					int Ran = Random.Range (0, RList2.Count);
//					Debug.Log (RList2 [Ran]);
					storyDeck.Add (RList2 [Ran]);
					RList2.RemoveAt (Ran);
				} else {
					ranStart = 3;
				}
			}
			if (ranStart == 3) {
				if (RList3.Count >= 1) {
					int Ran = Random.Range (0, RList3.Count);
//					Debug.Log (RList3 [Ran]);
					storyDeck.Add (RList3 [Ran]);
					RList3.RemoveAt (Ran);
				} else {
					ranStart = 4;
				}
			}
			if (ranStart == 4) {
				if (RList4.Count >= 1) {
					int Ran = Random.Range (0, RList4.Count);
//					Debug.Log (RList4 [Ran]);
					storyDeck.Add (RList4 [Ran]);
					RList4.RemoveAt (Ran);
				} else {
					break;
				}
			}
		}
		logger.info ("StoryDeck.cs :: StoryDeck storyDeck has been created. with sizes of " + getSizeOfDeck());

	}






		/*
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
		storyDeck.Add("King's Recognition",					2);
		storyDeck.Add("Queen's Favor",						2);
		storyDeck.Add("Court Called to Camelot",				2);
		storyDeck.Add("Pox",									1);
		storyDeck.Add("Plague",								1);
		storyDeck.Add("Chivalrous Deed",						1);
		storyDeck.Add("Prosperity Throughout the Realm",		1);
		storyDeck.Add("King's Call to Arms",					1);
		
		storyDeck.Add("Tournament at Camelot", 				1);
		storyDeck.Add("Tournament at Orkney",				1);
		storyDeck.Add("Tournament at Tintagel",				1);
		storyDeck.Add("Tournament at York",					1);	
		*/
	

	public GameObject Draw(){
		logger.info ("StoryDeck.cs :: Story Deck is drawing..." );
		if (storyDeck.Count == 0) {
			logger.info ("StoryDeck.cs :: ." + storyDeck.Count + "Is empty.");
			populateDeck ();
		}
		temp = storyDeck [0];
		storyDeck.RemoveAt (0);
		GameObject tempCard = Instantiate ((Resources.Load ("PreFabs/CurrentStoryCard") as GameObject));   //DO NOT FORGET TO PARENT TO COORECT HAND, MIGHT NEED TO TAKE IN HAND OBJECTS
	
		if (quests.Contains (temp)) {
			tempCard.AddComponent<Quest> ();
			tempCard.GetComponent<Quest> ().setCard (temp);
			//					Debug.Log (	"StoryDeck.cs Quest name :: " + tempCard.GetComponent<Quest> ().getName());
		} else if (events.Contains (temp)) {
			tempCard.AddComponent<Event> ();
			tempCard.GetComponent<Event> ().setCard (temp);
		} else if (tournaments.Contains (temp)) {
			tempCard.AddComponent<Tournament> ();
			tempCard.GetComponent<Tournament> ().setCard (temp);
		}
		logger.info ("StoryDeck.cs :: Story Deck has drawn Card: " + temp);

		return tempCard;

	}
		
	/*
	public void RemoveCard(string tempKey){
		if (storyDeck.Contains (tempKey) == true) {
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
*/
	public int getSizeOfDeck(){
		return storyDeck.Count;
	}



}
