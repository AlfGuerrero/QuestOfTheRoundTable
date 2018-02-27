using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournamentSubmit : MonoBehaviour {

	public void submitTournamentCard(){
		GameObject stage = GameObject.FindGameObjectWithTag ("Stage");	// HERE
		Debug.Log ("Tournament Submit: " + stage);
		List<AdventureCard> cards = new List<AdventureCard>();
		foreach (Transform j in stage.transform) {
			//if contains a weapon
			if (j.gameObject.GetComponent<AdventureCard> ().getType () == "Weapon") {
				//check if duplicates of weapons
				if (sameName (j.gameObject.GetComponent<AdventureCard> ().getName (), cards)) {
					Debug.Log ("uh oh!!");
					return;
				} else {
					Debug.Log ("Yay!");
					cards.Add (j.gameObject.GetComponent<AdventureCard>());
				}
			} else {
				Debug.Log ("uh oh2!!");
				return;
			}
		}
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager>().Tournaments.setCardsSubmitted (true);
//		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().
//		Debug.Log ("Setting to true");
//		Debug.Log ("Player Name: " + GameObject.FindGameObjectWithTag ("Stage").GetComponentInParent<User>().getName());
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ().Tournaments.addDictionary (cards, GameObject.FindGameObjectWithTag ("Stage").GetComponentInParent<User> ().getName ());
	}

	bool sameName(string name, List<AdventureCard> cards){
		for(int i = 0; i < cards.Count; i++){
			if(cards[i].getName() == name){
				return true;
			}
		}
		return false;
	}
}
