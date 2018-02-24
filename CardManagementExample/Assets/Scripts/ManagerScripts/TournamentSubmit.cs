using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournamentSubmit : MonoBehaviour {

	public void submitTournamentCard(){
		GameObject stage = GameObject.FindGameObjectWithTag ("Stage");
		List<AdventureCard> cards = new List<AdventureCard>();
		foreach (Transform j in stage.transform) {
			//if contains a weapon
			if (j.gameObject.GetComponent<AdventureCard> ().getType () == "Weapon") {
				//check if duplicates of weapons
				if (sameName (j.gameObject.GetComponent<AdventureCard> ().getName (), cards)) {
					Debug.Log ("uh oh!!");
					//return null;
				} else {
					Debug.Log ("Yay!");
					cards.Add (j.gameObject.GetComponent<AdventureCard>());
				}
			} else {
				Debug.Log ("uh oh2!!");
			}
		}
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<TournamentManager> ().setCardsSubmitted(true);
		//Debug.Log ("Setting to true");
		//Debug.Log ("Player Name: " + GameObject.FindGameObjectWithTag ("Stage").GetComponentInParent<User>().getName());
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<TournamentManager> ().addDictionary (cards, GameObject.FindGameObjectWithTag ("Stage").GetComponentInParent<User> ().getName ());
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
