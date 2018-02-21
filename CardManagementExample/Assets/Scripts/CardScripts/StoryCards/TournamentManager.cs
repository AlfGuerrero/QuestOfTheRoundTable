using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameController;

public class TournamentManager: MonoBehaviour {
	
	// Use this for initialization
	//Users ht;
	//Users the = gameUsers.getUsers();
	bool pressed=false;
	int ai=0;
	List<Users> Kards;
	bool CardsSubmitted = false;
	//List<GameObject> Players= getplayers();
	GameObject SubmissionZone;

	void Start(){
		SubmissionZone = Resources.Load ("PreFabs/aStage") as GameObject;
	}
	public void beginTournament(Users Players){
		foreach (GameObject currentPlayer in Players.getUsers()) {
			//while (CardsSubmitted == false) {

			Instantiate(SubmissionZone, currentPlayer.GetComponent<Transform>());
				//SubmissionZone.transform.SetParent (currentPlayer.transform);
				Debug.Log ("PLEASE LET THIS WORK");
			//}
		}

	}
		
	}