using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour {

	GameObject[] theParticipants;
	GameObject QuestStage;
	GameObject SubmitButton;
	GameObject stageDisplay;
	int cardsPlayed = 0;
	bool questOver = false;
	int numStages;

	int currentBid;
	int playerBid;
	GameObject[] stages;
	public List<List<AdventureCard>> currentQuest;
	List<AdventureCard> weaponsSubmit;
	bool buttonToggle;


	void Start(){
		QuestStage = Resources.Load("PreFabs/QuestStage") as GameObject;
		SubmitButton = Resources.Load("PreFabs/SubmitButton") as GameObject;
		stageDisplay = Resources.Load ("PreFabs/StageDisplay") as GameObject;
		//bool banana = true;
		//Instantiate (QuestStage);
		//spawnStages (3, GameObject.Find ("Player").gameObject);
	}



	/***** There Are 3 Phases For A Quest *****/
	//Sponsor Set Up
	//Player Play Through
	//Final Results

	//Needs to take in the sponsor and the Quest in play
	//Send that player to a setup screen

	public void Setup(GameObject sponsor){
		//string currentCard = GameObject.Find ("CurrentStoryCard").GetComponent<StoryDeckManager> ().getCurrentCard ();
		numStages = GameObject.FindGameObjectWithTag("StoryCard").GetComponent<Quest>().getStages();
		cardsPlayed = 0;
		spawnStages (numStages, sponsor);
		//while stages are not elligible for submission wait here
		//hide stages to players
		//let the players know how many cards are there, and if it is a test or not

	}



	public void Playthrough(GameObject participant, int stage){
		bool foeStage = false;
		bool testStage = false;
		AdventureCard testCard = null;

			Debug.Log("Starting PLAYTHROUGH");
		Debug.Log ("The stage beginning is: "+stage);
			//GameObject tempDisplay = null;
				//change between participants, knock them out, continue through stages
		for(int x = 0; x < numStages; x++){
			Debug.Log ("Stage: "+x);
			foreach(AdventureCard c in currentQuest[x]){
				Debug.Log (c.getName());
			}
		}

		List<AdventureCard> tempList = currentQuest[stage];
			foreach(AdventureCard c in tempList){
					if (c.getType() == "Foe") {
						foeStage = true;
						Debug.Log("foeStage is true");
					} else if(c.getType() == "Test"){
						testStage = true;
						testCard = c;
						Debug.Log("testStage is true");
					} 
				}
			if(foeStage){
					//display a foe background image
				Debug.Log("starting the foe stage");
				//tempDisplay = DisplayStage(testCard);
				runThroughFoeStage (participant, currentQuest[stage]);
					//StartCoroutine (runThroughFoeStage (stage));
					//participants = runThroughFoeStage (participants, stage);

			}else if(testStage){
					//display the test image and the current bid score
				Debug.Log("starting the test stage");
				//tempDisplay = DisplayStage(testCard);

					//participants = biddingWar(participants, testCard);
			}
				//destroy stages and displayedCard
			//Destroy(tempDisplay);
				//draw card for each participant
				//drawCards(participants);

	}

	GameObject[] biddingWar(GameObject[] participants, AdventureCard test){
		
		bool biddingOver = false;
		bool playerSubmitSomething = false;
		int playerBidding = 0;

		currentBid = test.getBidPoints ();

		//Bid to remove cards
		//knock out other contestants
		//take into account free bids
		//winner discards # of cards = bids - freeBids

		while (!biddingOver) {
			playerSubmitSomething = false;
			// spawn input field for the current player
			Instantiate(Resources.Load("PreFabs/inputfield") as GameObject, participants[playerBidding].transform);

			while(!playerSubmitSomething){
				if (playerBid <= currentBid) {
					participants [playerBidding] = null;
					GameObject[] temp = new GameObject[participants.Length - 1];
					for(int j = 0; j < participants.Length; j++){
						if(participants[j] != null){
							temp [j] = participants [j];
						}
					}
					participants = temp;
				} else {
					playerSubmitSomething = true;
				}
			}
			if (participants.Length < 1) {
//***************** PARTICIPANT NEEDS TO DISCARD CARDS - FREE BIDS FROM ALLIES *****************
				return participants;
			} else {
				if(playerBidding > participants.Length){
					playerBidding = 0;
				}else{
					playerBidding++;
				}
			}
		}
		return participants;
		//continue play with the last contestant in quest
	}

	void runThroughFoeStage(GameObject participant, List<AdventureCard> stage){
		//while(true){
		GameObject weaponZone = Resources.Load ("PreFabs/aStage") as GameObject;
		GameObject button = Resources.Load ("PreFabs/SubmitButton2") as GameObject;
		//int playerPlaying = 0;
			
		Debug.Log (participant.GetComponent<User> ().getName () + "is participating and sending weapons");
		//buttonToggle = false;
		GameObject wepZone = Instantiate (weaponZone, participant.transform);
		GameObject butZone = Instantiate (button, participant.transform);
		Debug.Log ("Zones created");
	    butZone.GetComponent<SubmitCards>().setStage (stage);
		return;
	}

		
			//return theParticipants;
		//}


	public void EndResults(){
		
		//sponsor draws cardsPlayed + stages;
		//winner(s) gain shields equal to numStages (maybe also watch out for that one event card for 2 more shields upon completeion)
		//return to Game Master
	}

	void spawnStages(int numStages, GameObject sponsor){
		//int counter = 1;
		stages = new GameObject[numStages];
		for(int i = 0; i < numStages; i++){
			stages[i] = Instantiate (QuestStage, sponsor.transform);
			stages[i].transform.position = new Vector2(stages [i].transform.position.x + 140*i, stages[i].transform.position.y);

		}
		Instantiate (SubmitButton, sponsor.transform);
	}

	public void increaseCardsPlayed(){
		cardsPlayed++;
	}



	public void setBids(int bids){
		currentBid = bids;
	}

	public void setStages(List<List<AdventureCard>> cardsForStage){
		this.currentQuest = cardsForStage;
	}

	public void setWeaponsSubmit(List<AdventureCard> weapons){
		weaponsSubmit = weapons;
	}

	public bool getToggle(){
		return buttonToggle;
	}

	public void setToggle(bool newToggle){
		buttonToggle = newToggle;
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

	void drawCards(GameObject[] participants){
		AdventureDeck advDeck = GameObject.Find ("advdeck").GetComponent<AdventureDeck> ();
		foreach(GameObject i in participants){
			advDeck.Draw ().transform.SetParent (i.transform.GetChild (0));
		}
	}

	GameObject DisplayStage(AdventureCard test){
		GameObject displaying = Instantiate (stageDisplay, GameObject.Find("MainUI").transform);
		if (test == null) {
			displaying.GetComponent<Image> ().sprite = Resources.Load ("foeCard") as Sprite;
		} else {
			displaying.GetComponent<Image> ().sprite = test.gameObject.GetComponent<Image> ().sprite;
		}
		return displaying;
	}

	IEnumerator CustomWait(){
		//while(buttonToggle == false){
		Debug.Log("Waiting...");
		while(buttonToggle == false){
			yield return null;
		}

		Debug.Log("Done Waiting!");
		//}
	}
}
