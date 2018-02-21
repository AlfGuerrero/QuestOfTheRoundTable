using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitCards : MonoBehaviour {
	protected bool test = false;
	protected bool submittable = false;


	public void submitCardsQuest(){
		//get num stages and stage objects
		Quest storycard = GameObject.FindGameObjectWithTag("StoryCard").GetComponent<Quest>();
		int numStages = storycard.getStages();
		GameObject[] stages = GameObject.FindGameObjectsWithTag ("Stage");

		//check each stage submit is correct
		for (int i = 0; i < numStages; i++) {
			//Debug.Log(stages[i].GetComponent<RectTransform>().position.x);  <-----------Goes negative to positive
			bool foe = false;
			int scoreToBeat = 0;
			//make a list of children (cards)
			List<AdventureCard> cards = new List<AdventureCard>();
			foreach (Transform j in stages[i].transform) {
				//if contains a weapon
				if (j.gameObject.GetComponent<AdventureCard> ().getType () == "Weapon") {
					//check if duplicates of weapons
					if(sameName(j.gameObject.GetComponent<AdventureCard> ().getName(),cards)){
						return;
					}
				}

				//if contains an ally then return
				if(j.gameObject.GetComponent<AdventureCard> ().getType () == "Ally"){
					return;
				}

				cards.Add (j.gameObject.GetComponent<AdventureCard>());
				//Debug.Log (j.gameObject.GetComponent<AdventureCard>().getName());
			}

			//check if multiple tests in one stage and across all stages
			if (countOfType ("Test", cards) == 1 && cards.Count == 1 && !test) {
				test = true;
			} else {
				return;
			}

			//check if multiple foes are in single stage
			if (countOfType ("Foe", cards) == 1) {
				foe = true;
			} else {
				return;
			}

			//return if both a foe and test are present or neither are present
			if ((test && foe) || (!test && !foe)) {
				return;
			}


		}

		//get cards attatched to each stage
		//create each respective stage (number to beat , or test)

	}

	public void submitCardsTournament(){

	}

	int countOfType(string type, List<AdventureCard> cards){
		int quantity = 0;
		for(int i = 0; i < cards.Count; i++){
			if(cards[i].getType() == type){
				quantity++;
			}
		}
		return quantity;
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
