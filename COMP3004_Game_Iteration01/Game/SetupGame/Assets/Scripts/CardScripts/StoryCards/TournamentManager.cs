using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using QuestGame;

public class TournamentManager: MonoBehaviour {

	// Use this for initialization
	//Users ht;
	//Users the = gameUsers.getUsers();
	bool pressed;
	int ai;
	List<Users> Kards;
	string winner;
	bool CardsSubmitted;
	GameObject SubmissionZone;
	GameObject SubmitButton;
	bool tieBreaker;
	Dictionary<string, List<AdventureCard>> u_cards = new Dictionary<string, List<AdventureCard>>(){};
	SortedDictionary<string, int> u_battlePoints = new SortedDictionary<string, int>(){};
	protected QuestGame.Logger	logger = new QuestGame.Logger ();


	int participants;
	void Start(){
//		SubmissionZone = Resources.Load ("PreFabs/aStage") as GameObject;
//		SubmitButton = Resources.Load ("Prefabs/TournamentSubmit") as GameObject;
		pressed = false;
		ai = 0;
		CardsSubmitted = false;
		tieBreaker = false;
	}
	public void beginTournament(User currentUser, Users Players){
		participants = Players.getNumberOfUsers();
		logger.info ("TournamentManager.cs :: Beginning Tournament.");
		foreach (GameObject currentPlayer in Players.getUsers()) {
			logger.test ("TournamentManager.cs :: Executing Tournament with players " + currentPlayer.GetComponent<User>().getName());
			SubmissionZone = Resources.Load ("PreFabs/aStage") as GameObject;
			SubmitButton = Resources.Load ("Prefabs/TournamentSubmit") as GameObject;
			SubmissionZone = Instantiate (SubmissionZone, currentPlayer.transform);
			SubmitButton = Instantiate (SubmitButton, currentPlayer.transform);

			if (currentPlayer != currentUser.gameObject) {
				SubmissionZone.gameObject.SetActive (false);
				SubmitButton.gameObject.SetActive (false);
			}
		}
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

	public void Tournament(Users Players, Tournament card){
		foreach (KeyValuePair<string, List<AdventureCard>> i in u_cards) {
			//adding total battle points in dictionary<username, totalbattlepoints>
			int totalBattlePoints = 0;
			totalBattlePoints = getTotalBattlePoints (i.Value);
			if(u_battlePoints.ContainsKey(i.Key)){
				logger.warn ("TournamentManager.cs :: Cards are already added in.");
				//Debug.Log ("already added in");
			}else{u_battlePoints.Add(i.Key,totalBattlePoints);
				logger.warn ("TournamentManager.cs :: adding cards to Player" + i.Key + " with Total Battle Points: " + totalBattlePoints);

			}
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
			//Users tieBreaker = new Users (2, 0);
			logger.info ("TournamentManagr.cs :: Tie between two players. No Winner. ");
		}
		winner = highestUser;

	}

	public void addDictionary(List<AdventureCard> cards, string user){
//		u_cards.Add (user, cards);
		if(u_cards.ContainsKey(user)){
			logger.info ("TournamentManagr.cs :: A card is already inside the hand, cannot add submission.");
		}else{
			logger.info ("TournamentManagr.cs :: Adding cards to tournament submission.");
			u_cards.Add(user,cards);
		}
	}

	public int getTotalBattlePoints(List<AdventureCard> cards){
		int total = 0;
		foreach (AdventureCard i in cards) {
			total += i.getBattlePoints ();
		}
		return total;
	}

	public string endTournament(){
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager>().Tournaments.setCardsSubmitted (false);
		u_cards.Clear ();
		u_battlePoints.Clear ();
		logger.info ("TournamentManagr.cs :: A Winner has been made.");
		logger.info ("TournamentManagr.cs :: " + winner + " has just won the tournament.");
		logger.info ("TournamentManagr.cs :: Ending Tournament...");
		return winner;
	}
}
