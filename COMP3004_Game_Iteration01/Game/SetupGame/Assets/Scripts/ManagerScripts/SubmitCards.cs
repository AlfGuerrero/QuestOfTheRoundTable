using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestGame;
public class SubmitCards : MonoBehaviour {
	protected bool test;
	protected bool submittable;
	public bool stage2 = false;
	protected List<List<AdventureCard>> listOfStages;
	List<AdventureCard> Stage = new List<AdventureCard>();
	public bool submitHasBeenPressed;
	QuestGame.Logger logger = new QuestGame.Logger();

	void Start(){
		submitHasBeenPressed = false;
		GameObject.Find ("GameManager").GetComponent<GameManager> ().keepPlaying = false;
	}

	//check for allies, tests, weapons, foes etc.......
	public void submitCardsQuest(){
		logger.info ("SubmitCards.cs :: Checking the current submission of cards for a quest");
		listOfStages = new List<List<AdventureCard>> ();
		//get num stages and stage objects
		test = false;
		Quest storycard = GameObject.FindGameObjectWithTag("StoryCard").GetComponent<Quest>();
		int numStages = storycard.getStages();
		GameObject[] stages = GameObject.FindGameObjectsWithTag ("Stage");

		//check each stage submit is correct
		for (int i = 0; i < numStages; i++) {
			logger.info ("SubmitCards.cs :: Checking if stage "+ i + " is eligible for submission");
			//Debug.Log(stages[i].GetComponent<RectTransform>().position.x);  <-----------Goes negative to positive
			bool foe = false;
			bool testCurrentStage = false;
			bool weapons = false;

			//make a list of children (cards)
			List<AdventureCard> cards = new List<AdventureCard>();
			foreach (Transform j in stages[i].transform) {
				//if contains a weapon
				Debug.Log(j.gameObject.GetComponent<AdventureCard> ().getType ());
				if (j.gameObject.GetComponent<AdventureCard> ().getType () == "Weapon") {
					//check if duplicates of weapons
					logger.info ("SubmitCards.cs :: There is a "+ j.gameObject.GetComponent<AdventureCard> ().getName() +" card");
					weapons = true;
					if (sameName (j.gameObject.GetComponent<AdventureCard> ().getName (), cards)) {
						logger.warn ("SubmitCards.cs :: There are weapons of the same name. This submission is not eligible");
						return;
					}
				}
				//check if multiple tests in one stage and across all stages
				if (j.gameObject.GetComponent<AdventureCard> ().getType () == "Test" && testCurrentStage == true) {
					logger.warn ("SubmitCards.cs :: There are multiple 'Test' cards in this stage. This submission is not eligible");
					return;
				} else if(j.gameObject.GetComponent<AdventureCard> ().getType () == "Test" && test == true){
					logger.warn ("SubmitCards.cs :: There are multiple 'Test' cards among all stages. This submission is not eligible");
					return;
				} else if (j.gameObject.GetComponent<AdventureCard> ().getType () == "Test" && test == false) {
					test = true;
					testCurrentStage = true;
					logger.info ("SubmitCards.cs :: There is a "+ j.gameObject.GetComponent<AdventureCard> ().getName() +" card");
				}

				//check if multiple foes are in single stage
				if(j.gameObject.GetComponent<AdventureCard> ().getType () == "Foe" && foe == true){
					logger.warn ("SubmitCards.cs :: There are multiple 'Foe' cards in this stage. This submission is not eligible");
					return;
				}else if(j.gameObject.GetComponent<AdventureCard> ().getType () == "Foe" && foe == false){
					logger.info ("SubmitCards.cs :: There is a "+ j.gameObject.GetComponent<AdventureCard> ().getName() +" card");
					foe = true;
				}

				//if contains an ally then return
				if(j.gameObject.GetComponent<AdventureCard> ().getType () == "Ally"){
					logger.info ("SubmitCards.cs :: This stage contains an 'Ally'. This submission is not eligible");
					return;
				}

				cards.Add (j.gameObject.GetComponent<AdventureCard>());
				logger.info ("SubmitCards.cs :: Adding the card "+ j.gameObject.GetComponent<AdventureCard> ().getName() +" to the current stage");
				//Debug.Log (j.gameObject.GetComponent<AdventureCard>().getName());
			}
			//return if both a foe and test are present or neither are present
			if (testCurrentStage && foe) {
				logger.warn ("SubmitCards.cs :: This stage contains a 'Foe' and a 'Test' card. This submission is not elligible");
				return;
			} else if (!testCurrentStage && !foe) {
				logger.warn ("SubmitCards.cs :: This stage does not contain a 'Foe' or 'Test' card. This submission is not elligible");
				return;
			}

			if(testCurrentStage && weapons){
				logger.warn ("SubmitCards.cs :: This stage contains a 'Test' and a 'Weapon' card. This submission is not eligible");
				return;
			}

			logger.info ("SubmitCards.cs :: Adding the current stage to the quest");
			listOfStages.Insert (i,cards);


		}
		int[] bpps = new int[numStages];

		for(int y = 0; y < numStages; y++){
			bpps[y] = 0;
		}

		foreach(List<AdventureCard> k in listOfStages){
			foreach (AdventureCard h in k) {
				logger.info ("SubmitCards.cs :: Calculating battle points for the current stage");
				if (h.getType () == "Test") {
					bpps [listOfStages.IndexOf (k)] = 0;
					logger.info ("SubmitCards.cs :: This stage has a 'Test' and requires no battle points");
				} else {
					if(h.getType () == "Weapon"){
						bpps [listOfStages.IndexOf (k)] += h.getBattlePoints ();

					}else if(h.getType () == "Foe"){
						if(storycard.getBonusFoe() == h.getName() || storycard.getBonusFoe() == "All"){
							logger.info ("SubmitCards.cs :: the 'Foe' name and bonus foe of the 'Quest' match. Using the higher of the two battle points");
							bpps [listOfStages.IndexOf (k)] += h.getBonusBattlePoints ();
						}else{
							bpps [listOfStages.IndexOf (k)] += h.getBattlePoints ();
							logger.info ("SubmitCards.cs :: the 'Foe' '"+ h.getName() +"' does not match the bonus foe of the 'Quest'. Using the lower of the two battle points");
						}
					}
				}
			}
			Debug.Log ("bpps = " + bpps[listOfStages.IndexOf(k)]);
		}

		for (int t = 1; t < numStages+1; t++) {
			
			if(bpps[t-1] != 0){
				if(t < bpps.Length){
					if(bpps[t-1] > bpps[t]){
						return;
					}
				}
			}
		}

		Debug.Log ("adding stages");
		foreach(List<AdventureCard> s in listOfStages){
			foreach(AdventureCard a in s){
				GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ().advDeck.GetComponent<AdventureDeck> ().adventureDeck.Add (a.getName ());
			}
		}
		GameObject.Find ("QuestManager").GetComponent<QuestManager> ().setStages (listOfStages);
		foreach(GameObject k in stages){
			Destroy (k);
		}
		GameObject.Find ("QuestManager").GetComponent<QuestManager> ().setToggle (true);
		GameManager gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		gm.playerTurn++;
		if(gm.playerTurn>3){
			gm.playerTurn = 0;
		}
		gm.togglePlayerCanvas (gm.playerTurn);
		gm.questInProgress = true;
		Destroy (this.gameObject);
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


	public void submitWeapons(){

		GameObject submissionZone = GameObject.FindGameObjectWithTag ("Stage");
		//make a list of children (cards)
		List<AdventureCard> weaponsToSubmit = new List<AdventureCard>();
		foreach (Transform j in submissionZone.transform) {
			//if contains a weapon
			Debug.Log(j.gameObject.GetComponent<AdventureCard> ().getType ());
			if (j.gameObject.GetComponent<AdventureCard> ().getType () == "Weapon") {

				//check if duplicates of weapons
				if (sameName (j.gameObject.GetComponent<AdventureCard> ().getName (), weaponsToSubmit)) {
					Debug.Log ("Weapons of same name");
					return;
				}

			}

			//if contains an ally then return
			if(j.gameObject.GetComponent<AdventureCard> ().getType () == "Ally"){
				Debug.Log ("Theres an ally");
				return;
			}
			//if contains a foe then return
			else if(j.gameObject.GetComponent<AdventureCard> ().getType () == "Foe"){
					Debug.Log ("Theres a Foe");
					return;
			}
			//if contains a test then return
			else if(j.gameObject.GetComponent<AdventureCard> ().getType () == "Test"){
				Debug.Log ("Theres a Test");
				return;
			}

			weaponsToSubmit.Add (j.gameObject.GetComponent<AdventureCard>());
			//Debug.Log (j.gameObject.GetComponent<AdventureCard>().getName());
		}

//		GameObject.Find ("QuestManager").GetComponent<QuestManager> ().setToggle (true);
		submitHasBeenPressed = true;
//		GameObject.Find ("QuestManager").GetComponent<QuestManager> ().setWeaponsSubmit (weaponsToSubmit);
		GameObject participant = GameObject.Find("GameManager").GetComponent<GameManager>().currentUser.gameObject;
		int userBP = participant.GetComponent<User>().getbaseAttack ();

		foreach (AdventureCard bp in weaponsToSubmit) {
			userBP += bp.getBattlePoints ();
		}
		Debug.Log(participant.GetComponent<User>().getName() + "BP: " + userBP);
		List<List<AdventureCard>> currentQuest = GameObject.Find ("GameManager").GetComponent<GameManager> ().Quests.currentQuest;
		GameManager gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		Debug.Log ("Foe BP: " + foeBattlePoints (Stage));
		int temp = gm.playerTurn-1;
		if (foeBattlePoints (Stage) > userBP) {
			Debug.Log("Player has too little BP to pass");
			Debug.Log ("bool index "+gm.playerTurn);
			if(temp < 0){
				temp = 3;
			}
			gm.passed[temp] = false;

		}else{
			Debug.Log("Player passed the stage");
			Debug.Log ("bool index "+gm.playerTurn);
			Debug.Log ("Length of bool[] is: "+ gm.passed.Length);
			if(temp < 0){
				temp = 3;
			}
			gm.passed[temp] = true;
		}
		Debug.Log ("Passed: " + gm.passed[gm.playerTurn]);

		//NEED TO DESTROY SUB ZONE AND BUTTON
		Debug.Log("Destroying zones");
		gm.keepPlaying = true;
//		gm.playerTurn++;
//		if(gm.playerTurn>4){
//			gm.playerTurn = 0;
//		}
		//gm.togglePlayerCanvas (gm.playerTurn);
		//gm.Quests.Playthrough (gm.currentUser.gameObject, gm.stageInt);
		Destroy (GameObject.FindGameObjectWithTag ("Stage"));
		Destroy (GameObject.FindGameObjectWithTag ("Submit"));


		//GameObject.Find ("GameManager").GetComponent<GameManager> ().keepPlaying = true;
	}

	int foeBattlePoints(List<AdventureCard> stage){
		int bp = 0;
		Quest currentQuest = GameObject.FindGameObjectWithTag ("StoryCard").GetComponent<Quest> ();
		foreach(AdventureCard c in stage){
			if (c.getType () == "Foe" && c.getName () == currentQuest.getBonusFoe ()) {
				bp += c.getBonusBattlePoints ();
			} else {
				bp += c.getBattlePoints ();
			}
		}
		return bp;
	}

	public void setStage(List<AdventureCard> stage){
		this.Stage = stage;
	}
}


