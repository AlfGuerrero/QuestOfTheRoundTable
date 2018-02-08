using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.TestTools;
//using NUnit.Framework;

public class DeckManager : MonoBehaviour {

	public string TempCard = "";
	public string tempKey = "";
	public int deckSize;
	public int index;
	public int randInt;

	public int getSizeOfDeck(Dictionary <string, int> Deck){
		return Deck.Keys.Count;
	}
		

	public string RandomCardPicker(Dictionary <string, int> Deck){
		tempKey = "";
		index = 0;
		randInt = 0;
		foreach (KeyValuePair<string, int> item in Deck) {
			randInt =  Random.Range (0, getSizeOfDeck(Deck)); 
			if (index == randInt) {
				tempKey = item.Key;
				return tempKey;
			}
			index += 1;
		}

		return  RandomCardPicker(Deck);	// If no card has been found: RECURSIFY
	}

	void RemoveCard(Dictionary <string, int> Deck, string tempKey){
		if (Deck.ContainsKey(tempKey) == true) {
			Deck [tempKey] -= 1;
			if (Deck [tempKey] == 0) {
				Deck.Remove (tempKey);
			}
		} 
	}

	void populateDeck(Dictionary<string, int> Deck){
		Deck.Add ("", 0);
	}
	/*
	[Test]
	public void populateDeckTest(){
		Dictionary<string, int> testDeck = new Dictionary<string, int>(){};
		populateDeck (testDeck);
		foreach (KeyValuePair<string, int> item in testDeck) {
			Debug.Log ("STORY: " + item.Key + " : " + item.Value );
		}
	}

	[Test]
	public void RemoveCardTest(){
		string testKey = "Search for the Holy Grail";							// Make sure Card only has of 1 value. 
		Dictionary<string, int> testDeck = new Dictionary<string, int>(){};
		populateDeck (testDeck);
		RemoveCard (testDeck, testKey);
		if (testDeck.ContainsKey (testKey) == true) {
			Assert.Fail ();
			Debug.LogError ("An Invalid Card has been randomly picked." + testKey + " Error...");
		} else {
			Assert.Pass ();
			Debug.Log ("Card successfully removed.");
		}
	}*/
}
