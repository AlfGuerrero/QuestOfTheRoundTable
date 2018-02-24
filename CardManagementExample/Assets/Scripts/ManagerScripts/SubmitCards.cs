using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitCards : MonoBehaviour {
	protected bool test;
	protected bool submittable = false;


	public void submitCardsQuest(){
		Debug.Log ("Starting submission");
		//get num stages and stage objects
		test = false;
		Quest storycard = GameObject.FindGameObjectWithTag("StoryCard").GetComponent<Quest>();
		int numStages = storycard.getStages();
		GameObject[] stages = GameObject.FindGameObjectsWithTag ("Stage");

		//check each stage submit is correct
		for (int i = 0; i < numStages; i++) {
			Debug.Log ("Stage: " + i);
			//Debug.Log(stages[i].GetComponent<RectTransform>().position.x);  <-----------Goes negative to positive
			bool foe = false;
			bool testCurrentStage = false;
			bool weapons = false;
			int scoreToBeat = 0;
			//make a list of children (cards)
			List<AdventureCard> cards = new List<AdventureCard>();
			foreach (Transform j in stages[i].transform) {
				//if contains a weapon
				Debug.Log(j.gameObject.GetComponent<AdventureCard> ().getType ());
				if (j.gameObject.GetComponent<AdventureCard> ().getType () == "Weapon") {
					//check if duplicates of weapons
					weapons = true;
					if (sameName (j.gameObject.GetComponent<AdventureCard> ().getName (), cards)) {
						Debug.Log ("Weapons of same name");
						return;
					}
				}
				//check if multiple tests in one stage and across all stages
				if (j.gameObject.GetComponent<AdventureCard> ().getType () == "Test" && testCurrentStage == true) {
					Debug.Log ("Multiple tests in this stage");
					return;
				} else if(j.gameObject.GetComponent<AdventureCard> ().getType () == "Test" && test == true){
					Debug.Log ("Multiple tests among all stages");
					return;
				} else if (j.gameObject.GetComponent<AdventureCard> ().getType () == "Test" && test == false) {
					test = true;
					testCurrentStage = true;
				}

				//check if multiple foes are in single stage
				if(j.gameObject.GetComponent<AdventureCard> ().getType () == "Foe" && foe == true){
					Debug.Log ("Many foes in one stage");
					return;
				}else if(j.gameObject.GetComponent<AdventureCard> ().getType () == "Foe" && foe == false){
					foe = true;
				}

				//if contains an ally then return
				if(j.gameObject.GetComponent<AdventureCard> ().getType () == "Ally"){
					Debug.Log ("Theres an ally");
					return;
				}

				cards.Add (j.gameObject.GetComponent<AdventureCard>());
				//Debug.Log (j.gameObject.GetComponent<AdventureCard>().getName());
			}


			//return if both a foe and test are present or neither are present
			if (testCurrentStage && foe) {
				Debug.Log ("foe and test");
				return;
			} else if (!testCurrentStage && !foe) {
				Debug.Log ("no foe and no test");
				return;
			}

			if(testCurrentStage && weapons){
				Debug.Log ("weapons and test");
				return;
			}

			GameObject.Find ("QuestManager").GetComponent<QuestManager> ().addStage (cards);
		}

		//get cards attatched to each stage
		//create each respective stage (number to beat , or test)

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
