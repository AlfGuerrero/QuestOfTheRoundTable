using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	GameObject QuestStage;
	GameObject SubmitButton;
	int cardsPlayed = 0;
	bool questOver = false;
	int numStages;
	GameObject[] stages;
	List<List<AdventureCard>> currentQuest;

	void Start(){
		QuestStage = Resources.Load("PreFabs/QuestStage") as GameObject;
		SubmitButton = Resources.Load("PreFabs/SubmitButton") as GameObject;

		spawnStages (3, GameObject.Find ("Player").GetComponent<User> ());
	}

	/***** There Are 3 Phases For A Quest *****/
	//Sponsor Set Up
	//Player Play Through
	//Final Results

	//Needs to take in the sponsor and the Quest in play
	//Send that player to a setup screen

	public void Setup(User sponsor){
		//string currentCard = GameObject.Find ("CurrentStoryCard").GetComponent<StoryDeckManager> ().getCurrentCard ();
		numStages = GameObject.FindGameObjectWithTag("StoryCard").GetComponent<Quest>().getStages();

		spawnStages (numStages, sponsor);
		//while stages are not elligible for submission wait here
		//hide stages to players
		//let the players know how many cards are there, and if it is a test or not

	}

	public void addStage(List<AdventureCard> cardsForStage){

	}

	public void Playthrough(User[] participants){

		while (!questOver) {
			//change between participants, knock them out, continue through stages
			//if test, go through a bidding system between players
			//keep track of which stage currently on, destroy stages as needed
			//make sure all stages are destroyed near end
		}

	}

	User biddingWar(User[] participants){
		User winner = null;

		//Bid to remove cards
		//knock out other contestants
		//take into account free bids
		//winner discards # of cards = bids - freeBids

		return winner;
		//continue play with the last contestant in quest
	}

	public void EndResults(){
		//sponsor draws cardsPlayed + stages;
		//winner(s) gain shields equal to numStages (maybe also watch out for that one event card for 2 more shields upon completeion)
		//return to Game Master
	}

	void spawnStages(int numStages, User sponsor){
		for(int i = 0; i < numStages; i++){
			stages[i] = Instantiate (QuestStage, sponsor.GetComponent<Transform>());//need to parent to sponsor
		}
		Instantiate (SubmitButton, sponsor.GetComponent<Transform>());
	}

	public void increaseCardsPlayed(){
		cardsPlayed++;
	}


}
