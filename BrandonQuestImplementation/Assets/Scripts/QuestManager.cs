using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public GameObject aStage;
	int cardsPlayed = 0;
	/***** There Are 3 Phases For A Quest *****/
	//Sponsor Set Up
	//Player Play Through
	//Final Results

	//Needs to take in the sponsor and the Quest in play
	//Send that player to a setup screen

	public void Setup(User sponsor){
		string currentCard = GameObject.Find ("CurrentStoryCard").GetComponent<StoryDeckManager> ().getCurrentCard ();
		int stages = GameObject.Find ("CurrentStoryCard").GetComponent<StoryDeckManager> ().getStages ();

		spawnStages (stages, sponsor);


	}

	public void Playthrough(){

	}

	public void EndResults(){
		//draw cardsPLayed + stages;
	}

	void spawnStages(int numStages, User sponsor){
		for(int i = 0; i < numStages; i++){
			Instantiate (aStage);//need to parent to sponsor
		}
	}

	public void increaseCardsPlayed(){
		cardsPlayed++;
	}
}
