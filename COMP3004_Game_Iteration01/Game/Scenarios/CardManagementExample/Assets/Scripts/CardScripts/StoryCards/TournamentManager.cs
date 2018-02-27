using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GameController;
using System.Linq;

public class TournamentManager: MonoBehaviour {
	
	// Use this for initialization
	//Users ht;
	//Users the = gameUsers.getUsers();
	bool pressed;
	int ai;
	List<Users> Kards;

	bool CardsSubmitted;
	GameObject SubmissionZone;
	GameObject SubmitButton;
	bool tieBreaker;
	Dictionary<string, List<AdventureCard>> u_cards = new Dictionary<string, List<AdventureCard>>(){};
	SortedDictionary<string, int> u_battlePoints = new SortedDictionary<string, int>(){};

	void Start(){
//		SubmissionZone = Resources.Load ("PreFabs/aStage") as GameObject;
//		SubmitButton = Resources.Load ("Prefabs/TournamentSubmit") as GameObject;
		pressed = false;
		ai = 0;
		CardsSubmitted = false;
		tieBreaker = false;
	}
//	public void beginTournament(Users Players){
//		//setting up tournament
//		foreach (GameObject currentPlayer in Players.getUsers()) {
//			SubmissionZone = Instantiate (SubmissionZone, currentPlayer.transform);
//			SubmitButton = Instantiate (SubmitButton, currentPlayer.transform);
//		}
//	}

	public void beginTournament(GameObject Player){
//		if (SubmissionZone != null && SubmitButton != null) {
		SubmissionZone = Resources.Load ("PreFabs/aStage") as GameObject;
		SubmitButton = Resources.Load ("Prefabs/TournamentSubmit") as GameObject;
			SubmissionZone = Instantiate (SubmissionZone, Player.transform);
			SubmitButton = Instantiate (SubmitButton, Player.transform);
//		}

	}

	public bool getCardsSubmitted(){
		return this.CardsSubmitted;
	}
	public void setCardsSubmitted(bool submit){
		this.CardsSubmitted = submit;
	}
	public bool getTieBreaker(){
		return this.tieBreaker;
	}

	public void Tournament(GameObject Players, Tournament card){
		Debug.Log ("Tournament Function run ");
		foreach (KeyValuePair<string, List<AdventureCard>> i in u_cards) {
			//adding total battle points in dictionary<username, totalbattlepoints>
			int totalBattlePoints = 0;
			totalBattlePoints = getTotalBattlePoints (i.Value);
			if(u_battlePoints.ContainsKey(i.Key)){
				//Debug.Log ("already added in");
			}else{u_battlePoints.Add(i.Key,totalBattlePoints);}
			//Debug.Log ("already added in");

		}
		int maxValue = 0;
		string highestUser = "";
		string tieUser = "";
		//changing dictionary to list and sorting them from largest to smallest
		foreach (KeyValuePair<string, int> i in u_battlePoints) {
			Debug.Log ("user name: " + i.Key + "and total value point: " + i.Value);
			if (i.Value > maxValue) {
				maxValue = i.Value;
				highestUser = i.Key;
				continue;
			}
			if (i.Value == maxValue) {
				tieBreaker = true;
				tieUser = i.Key;
			}
		}
		if (tieBreaker) {
			Debug.Log ("TIME FOR A TIE BREAKER GAME!!");
			//Users tieBreaker = new Users (2, 0);
		}
		//Destroy (SubmissionZone);
		//Destroy (SubmitButton);
		Debug.Log ("Highest user: " + highestUser);
		int Shields = Players.GetComponent<User> ().getShields ();
		Players.GetComponent<User> ().setShields (Shields + card.getBonusShields ());

		endTournament ();
	}
		
	public void addDictionary(List<AdventureCard> cards, string user){
//		u_cards.Add (user, cards);
		if(u_cards.ContainsKey(user)){
			Debug.Log ("already added in");
		}else{
			u_cards.Add(user,cards);
			Debug.Log ("adding in");
			Debug.Log ("Should be trueTrue: " + this.CardsSubmitted);
		}
	}
		
	public int getTotalBattlePoints(List<AdventureCard> cards){
		int total = 0;
		foreach (AdventureCard i in cards) {
			//Debug.Log ("card value = " + i.getBattlePoints ());
			total += i.getBattlePoints ();
		}
		return total;
	}

	public void endTournament(){
		Destroy (SubmitButton.gameObject);
		Destroy (SubmissionZone.gameObject);
//		SubmitButton.SetActive(false);
//		SubmissionZone.SetActive(false);
//		foreach (GameObject i in SubmissionZone.transform) {
//			Destroy (i);
//		}
			//		foreach (GameObject currentPlayer in Players.getUsers()) {

//		gameUsers.findByUserName ("Player" + turn).transform.GetChild (i).gameObject.false (true);


		GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager>().Tournaments.setCardsSubmitted (false);

	}

}