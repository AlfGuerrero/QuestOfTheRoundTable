using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

public class Card : MonoBehaviour {
	public static readonly string[] DECKS = {"Adventure", "Story"};
	public static readonly string[] TYPES = {"Events", "Tournaments", "Quests", "Allies", "Foes", "Tests", "Weapons"};
	protected string deck;
	protected string type;
	protected Dictionary<string, string> card;
	protected Dictionary<int, Card> countDeck;
	protected static int counter = 0;
	public Card(string deck, string type){
		this.deck = deck;
		this.type = type;
		this.countDeck.Add (counter, new Card (deck, type));
		counter++;
	}
	public string getDeck(){
		return this.deck;
	}
}
