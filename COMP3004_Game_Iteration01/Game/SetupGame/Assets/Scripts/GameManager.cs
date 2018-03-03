using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using QuestGame;

public class GameManager : EventsManager {

	// Use this for initialization
	// Order of Gameplay...
	/*
	 * Ask for # of users from UI Textbox. - waits to be pressed enter.
	 *
	 * */
	static Users gameUsers;
	int totalUsers;
	int textBoxInput = 4;						// Will be changed to rom Textbox input UI.
	public int playerTurn = 0;
	int userInfoTurn = 0;
//	bool isWinner = false;
	int startTournament = 0;
	int endTournament = 3;
	int starts;
	public AdventureDeck 		advDeck;
	public StoryDeck 			storyDeck;
	public TournamentManager 	Tournaments;
	public EventsManager 		Events;
	public QuestManager 		Quests;
	public GameObject			StoryCard;
	public User 				currentUser;
	public QuestGame.Logger	logger;
	public bool statsToggle = false;
	public bool startEvents = false;
	public bool KingsCalltoArms = false;

	public bool questInProgress = false;
	public bool questInPlay = false;
	public bool questPlaying = false;
	public bool allDead = false;
	public int playersPlaying = 0;
	string storyCardToDraw = "Boar Hunt";
	public int stageInt = 0;
	int counter = 0;
	//	GameObject SubmissionZone;
	//	GameObject SubmitButton;
	public bool keepPlaying = true;
	public bool temp2 = false;
	bool temp = true;
	int sponsorturn;
	public bool[] passed;
	public bool KingsRecognition = false;
//	GameObject SubmissionZone;
//	GameObject SubmitButton;

	GameObject PlayerStats;
//	public Text playerName;
//	public Text playerRank;
//	public Text playerShields;
//	public Text playerBattlePoints;
//	public Text playerCardsInHand;

	bool buttonPushed = false;
	bool doThisOnce = true;
	bool doThisOnceMore = true;

	void Start () {
		logger = new QuestGame.Logger ();
		logger.info ("GameManager.cs :: Initializing Game...");

		gameUsers =  new Users(textBoxInput, 0);
		totalUsers = gameUsers.getNumberOfUsers ();
		logger.info ("GameManager.cs :: Calling AdventureDeck...");
		advDeck.populateDeck();
		logger.info ("GameManager.cs :: Calling StoryDeck...");
		storyDeck.populateDeck ();
		passed = new bool[4] {false,false,false,false};

////		storyDeck.populateEventsDeck ();
//		PickUpAdventureCards (0, 12);
//		PickUpAdventureCards (1, 15);
//		PickUpAdventureCards (2, 12);
//		PickUpAdventureCards (3, 12);

		for (int i = 0; i < textBoxInput; i++) {
			PickUpAdventureCards (i, 12);
		}

		logger.info ("GameManager.cs :: Game has been created with " + totalUsers + " players.");
		togglePlayerCanvas (playerTurn);

	}

	void displayUsersInfo(){

		string names = "";
		string ranks = "";
		string shields = "";
		string battlePoint = "";
		string cardsinHand = "";


//		User cc = gameUsers.findByUserName ("Player" + userInfoTurn).GetComponent<User> ();		// Get User.
		int numUsers = gameUsers.getUsers().Count;
		foreach (GameObject i in gameUsers.getUsers()){


			names += (i.GetComponent<User>().getName ());
			names += "\n";
			ranks += (i.GetComponent<User>().getRank ());
			ranks += "\n";
			shields += (i.GetComponent<User>().getShields ());
			shields += "\n";
			battlePoint += (i.GetComponent<User>().getbaseAttack ());
			battlePoint += "\n";
			cardsinHand += (i.GetComponent<User>().getHand().transform.childCount);
			cardsinHand += "\n";

//			for(int k = 0; k < numUsers; k++){
//				for(int j = 0; j < i.GetComponent<User>().getHand().transform.childCount; j++){
//					GameObject temp = Instantiate (Resources.Load ("PreFabs/SmallCard") as GameObject, new Vector2 (k, j), Quaternion.identity);
//					temp.transform.SetParent (GameObject.Find("MainUI").transform);
//				}
//			}

//			shields.Add (i.GetComponent<User>().getShields ());
//			battlePoints.Add (i.GetComponent<User>().getbaseAttack ());
//			cardsinHand.Add (i.GetComponent<User>().getHand().transform.childCount);
		}

		PlayerStats.transform.GetChild(0).GetComponent<Text>().text =  "Player: " + names;
		PlayerStats.transform.GetChild(1).GetComponent<Text>().text =  "Rank: " + ranks;
		PlayerStats.transform.GetChild(2).GetComponent<Text>().text =  "Shields: " + shields;
		PlayerStats.transform.GetChild(3).GetComponent<Text>().text =  "Base Points: " 	+ battlePoint;
		PlayerStats.transform.GetChild(4).GetComponent<Text>().text =  "Cards In Hand: "	+ cardsinHand;
		logger.info ("GameManager.cs ::" + "Players: "+ names);
		logger.info ("GameManager.cs ::" + "Rank: "+ ranks);
		logger.info ("GameManager.cs ::" + "Shields: " + shields);
		logger.info ("GameManager.cs ::" + "Base Points: "	+ battlePoint);
		logger.info ("GameManager.cs ::" + "Cards In Hand: "+ cardsinHand);

	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.M)){
			Mordred ();
		}


		if (Input.GetKeyDown("tab")){
			statsToggle = true;
			PlayerStats = Resources.Load ("PreFabs/Stats") as GameObject;
			PlayerStats = Instantiate (PlayerStats, GameObject.Find("MainUI").transform);
			displayUsersInfo ();
		}
		if (statsToggle == true && Input.GetKeyUp("tab")){
			logger.info ("GameManager.cs :: 'tab' key has been pressed toggling Player Statistics.");
			Destroy (PlayerStats.gameObject);
			foreach (GameObject g in GameObject.FindGameObjectsWithTag ("SmallCard")) {
				Destroy (g);
			}
			statsToggle = false;
		}
		if(GameObject.Find ("Button (1)") != null){

		GameObject.Find ("Button (1)").GetComponent<Button>().onClick.AddListener(delegate {buttonToggle();});

	}

	/* BRANDONS QUEST STUFF START */
	if(questInPlay){
		if (counter < 4) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				logger.info ("GameManager.cs :: Up Arrow Key has been pressed..." );
				logger.info ("GameManager.cs :: Quest :: Player Sponsoring Quest: player" + playerTurn);
				Debug.Log (playerTurn + "Sponsoring");
				Quests.Setup (gameUsers.findByUserName ("Player" + playerTurn).gameObject);
				passed [playerTurn] = false;
				sponsorturn = playerTurn;
				//questInProgress = true;
				questInPlay = false;
				counter = 0;
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				logger.info ("GameManager.cs :: Down Arrow Key has been pressed..." );
				logger.info ("GameManager.cs :: Quest :: Player NOT Sponsoring Quest: player" + playerTurn);

				Debug.Log (playerTurn + "Not Sponsoring");
				playerTurn++;
				if(playerTurn > 3){
					playerTurn = 0;
				}
				togglePlayerCanvas (playerTurn);
				counter++;
			}
		} else {
			logger.info ("GameManager.cs :: Quest :: No one has sponsored." );
			Debug.Log("no one sponsored so continue to next story card");
			questInProgress = false;
			questInPlay = false;
			questPlaying = false;
			playerTurn++;
			counter = 0;
			if(playerTurn > 3){
				playerTurn = 0;
			}
		}

	}
	if(questInProgress){
		//Debug.Log (counter);
		if (counter < 3) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				logger.info ("GameManager.cs :: Up Arrow Key has been pressed..." );
				logger.info ("GameManager.cs :: Quest :: Player Joining Quest: player" + playerTurn);
				Debug.Log (playerTurn + "Joining");
				passed [playerTurn] = true;
				PickUpAdventureCards (playerTurn,1);
				playerTurn++;
				if(playerTurn > 3){
					playerTurn = 0;
				}
				togglePlayerCanvas (playerTurn);
				counter++;
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				logger.info ("GameManager.cs :: Down Arrow Key has been pressed..." );
				logger.info ("GameManager.cs :: Quest :: Player NOT Joining Quest: player" + playerTurn);
				Debug.Log (playerTurn + "Not Joining");
				passed [playerTurn] = false;
				playerTurn++;
				if(playerTurn > 3){
					playerTurn = 0;
				}
				togglePlayerCanvas (playerTurn);
				counter++;
			}
		} else {
			logger.info ("GameManager.cs :: Quest :: Starting runthrough of stages..." );

			Debug.Log ("Starting runthrouhg of stages");
			questInProgress = false;
			questPlaying = true;
			keepPlaying = true;
			counter = 0;
			for(int j = 0; j < passed.Length; j++){
				//Debug.Log ("PT: " + j + " bool: " + passed[j]);
				if(passed[j] == true){
					playersPlaying++;
				}
			}
			//start at first player to join, add necessary subzone and subbutton for stage
		}
	}

	if (questPlaying) {

		if(keepPlaying){

			if (counter < 4) {
				Debug.Log ("Counter = "+counter);
				Debug.Log ("Player turn passed: " + playerTurn+ " passed = " + passed [playerTurn]);
				logger.test ("GameManager.cs :: Quest :: player" + playerTurn + " has passed to the next stage.");

				if (passed [playerTurn] == true) {//then playthrough with that player
					if (stageInt != 6) {//then quest not over yet
						togglePlayerCanvas (playerTurn);
						currentUser = gameUsers.findByUserName ("Player" + playerTurn).GetComponent<User> ();
						Quests.Playthrough (currentUser.gameObject, stageInt);
						counter++;

					} else {//the quest is done
						logger.info ("GameManager.cs :: Quest :: The Quest has finished.");

						logger.info ("GameManager.cs :: Quest :: The sponsor: player" + sponsorturn + " Picks up cards");

						Debug.Log ("THE QUEST IS DONE NINJA!!");
						Debug.Log ("Sponsor is drawing cards");
						PickUpAdventureCards (sponsorturn,6);
						for(int j = 0; j < passed.Length; j++){
							if (passed [j] == true) {
								Debug.Log ("Player: " + j + " is a winner");
								User temp = gameUsers.findByUserName ("Player" + j).GetComponent<User> ();
									if(KingsRecognition){
										logger.info ("GameManager.cs :: Quest :: Kings Recognition is active.");
										temp.setShields (temp.getShields () + StoryCard.GetComponent<Quest> ().getStages () +2);

										KingsRecognition = false;
									}else{
										
										temp.setShields (temp.getShields () + StoryCard.GetComponent<Quest> ().getStages ());
									}
								
								passed [j] = false;
							}
						}
						playerTurn = sponsorturn+1;
						if (playerTurn > 3) {
							playerTurn = 0;
						}
						questPlaying = false;


					}
					if(questPlaying){
						playerTurn++;
						if (playerTurn > 3) {
							playerTurn = 0;
						}
					}
				} else if (!allDead) {//they didnt pass and need to be incremented;
					playerTurn++;
					if (playerTurn > 3) {
						playerTurn = 0;
					}
					counter++;
				} else {
					logger.info ("GameManager.cs :: Quest :: Everyone died before the end of the quest.");
					questPlaying = false;
					Debug.Log ("Sponsor is drawing cards");
						logger.info ("GameManager.cs :: Quest :: The sponsor: player" + sponsorturn + " Picks up cards");

					PickUpAdventureCards (sponsorturn, 6);
					playerTurn = sponsorturn+1;
					if (playerTurn > 3) {
						playerTurn = 0;
					}
					//give sponsor cards;
				}
				playersPlaying = 0;
				for(int j = 0; j < passed.Length; j++){
					if(passed[j] == true){
						playersPlaying++;
						logger.info ("GameManager.cs :: Quest :: There is " + playersPlaying +" in quest.");

					}
				}
				if(playersPlaying < 1){
					logger.info ("GameManager.cs :: Quest :: All Players did not pass.");
					allDead = true;
				}
			} else {
				if(playersPlaying > 0){

					counter = 0;
					stageInt++;
					Debug.Log ("Increasing the stage to: "+stageInt);
					logger.info ("GameManager.cs :: Quest :: Moving on to next stage: " + stageInt);
					for(int m = 0; m < passed.Length; m++) {
						if(passed[m] == true){
							logger.info ("GameManager.cs :: Quest :: player" + m + " has passed. Drawing one card.");
							Debug.Log ("Player: " + m + " is drawing a card");
							PickUpAdventureCards (m,1);
						}
					}
					if(stageInt > StoryCard.GetComponent<Quest>().getStages()-1){
						stageInt = 6;
						Debug.Log ("dont do this");
					}
				}
			}
		}

	}
	/* BRANDONS QUEST STUFF END */
		if (buttonPushed == true) {
			Instantiate (Resources.Load ("PreFabs/MiddleScreen") as GameObject);
			logger.info ("Toggling Middle Screen. Please click before moving on");


			togglePlayerCanvas (playerTurn);
			PickupStoryCards(playerTurn);
//			PickUpAdventureCards(playerTurn, 1);
		    currentUser = gameUsers.findByUserName ("Player" + playerTurn).GetComponent<User> ();
			logger.info ("GameManager.cs :: Next turn: " + currentUser.getName());
			if (currentUser.getCards ().Count > 12) {
				logger.info ("GameManager.cs :: " + currentUser.getName() + "Hand Count is: " + currentUser.getCards ().Count +" cards: Please Discard Cards. ");
			}
			handleStoryCards (currentUser);
			playerTurn ++;
			if (playerTurn > 3 ) { playerTurn = 0; }
			buttonPushed = false;

			/*QUEST START */
			if (doThisOnce) {
				playerTurn--;
				doThisOnce = false;
			}
			/*QUEST END */


		}

		if (Tournaments.getCardsSubmitted () == true) {
			Tournaments.Tournament (gameUsers, StoryCard.GetComponent<Tournament>());
			Destroy (GameObject.FindGameObjectWithTag("TournamentSubmit").gameObject);
			Destroy (GameObject.FindGameObjectWithTag("Stage").gameObject);
			starts += 1;
			startTournament += 1;
			logger.info ("GameManager.cs :: Player" + startTournament + " has submitted their Cards.");
			if (startTournament == totalUsers) { startTournament = 0; }
			togglePlayerCanvas (startTournament);
			if (starts == endTournament) {
				string winner = Tournaments.endTournament ();
				if (winner != "") {
					logger.info ("GameManager.cs :: " + winner + " has won the Tournament..");
					int shields = gameUsers.findByUserName (winner).GetComponent<User> ().getShields ();
					int bonus = StoryCard.GetComponent<Tournament> ().getBonusShields ();
					gameUsers.findByUserName (winner).GetComponent<User> ().setShields (shields + bonus + totalUsers);
					starts = 0;
				}
			}
			Tournaments.setCardsSubmitted (false);
		}
	}

	public void handleStoryCards(User currentUser){
		if (StoryCard.GetComponent<Event> () != null ){
			logger.trace ("GameManager.cs :: Calling EventManager...");
			Event evnt = StoryCard.GetComponent<Event> ();
			if (evnt.getName() == "King's Recognition") {
				Events.Kings_Recoginition (currentUser, gameUsers);
			}
			else if (evnt.getName() == "Queen's Favor") {
				PickUpAdventureCardsTest(Events.Queens_Favor (gameUsers), 2);
			}
			else if (evnt.getName() == "Court Called to Camelot"){
				Events.Court_Called_To_Camelot (gameUsers);
			}
			else if (evnt.getName() == "Pox"){
				Events.Pox (currentUser, gameUsers);
			}
			else if (evnt.getName() == "Plague"){
				Events.Plague (currentUser);
			}
			else if (evnt.getName() == "Chivalrous Deed"){
				Events.Chivalrous_Deed (currentUser, gameUsers);
			}
			else if (evnt.getName() == "Prosperity Throughout the Realm"){
				PickUpAdventureCardsTest (Events.Prosperity_Throughout_The_Realm(gameUsers), 2);
			}
			else if (evnt.getName() == "King's Call to Arms"){
				List<GameObject> HighestRank = Events.Kings_Call_To_Arms (currentUser, gameUsers);
			}
		}

		else if (StoryCard.GetComponent<Quest> () != null ){
			Quest quest = StoryCard.GetComponent<Quest> ();
			questInPlay = true;
			stageInt = 0;
			logger.test ("GameManager.cs :: Quest Name: " + quest.getName());
			logger.test ("GameManager.cs :: Calling QuestManager... ");


		}

		else if (StoryCard.GetComponent<Tournament> () != null) {
			Tournament tournament = StoryCard.GetComponent<Tournament> ();
			logger.test ("GameManager.cs :: Tournament Name: " + tournament.getName());
			logger.test ("GameManager.cs :: Calling Tournament Manager...");

//			Tournaments.gameObject.GetComponent<TournamentManager> ().beginTournament (currentUser.gameObject);
			startTournament = playerTurn;
			Tournaments.gameObject.GetComponent<TournamentManager> ().beginTournament (currentUser, gameUsers);

		}
	}

	public void togglePlayerCanvas(int playerTurn){
		for (int turn = 0; turn < totalUsers; turn++){
			if (turn == playerTurn) {
				for (int i = 0; i < gameUsers.findByUserName ("Player" + turn).transform.childCount; i++) {
					gameUsers.findByUserName ("Player" + turn).transform.GetChild (i).gameObject.SetActive (true);
				}
			} else if (turn != playerTurn) {
				for (int i = 0; i < gameUsers.findByUserName ("Player" + turn).transform.childCount; i++) {
					gameUsers.findByUserName ("Player" + turn).transform.GetChild (i).gameObject.SetActive (false);
				}
			}
		}
	}

	public List<GameObject> getAllUsers(){
		return gameUsers.getUsers();
	}

	public void PickupStoryCards(int player){
		if (StoryCard != null){Destroy(StoryCard);}
		StoryCard = storyDeck.Draw ();
		StoryCard.transform.SetParent (GameObject.Find("MainUI").transform);
		StoryCard.transform.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0.0f, 0.0f);
//     	logger.info ("GameManager.cs :: StoryCards :: Player " + player + " Picks up: " + StoryCard);
	}

	public void PickUpAdventureCards(int player, int amount){
		for (int i = 0; i < amount; i++) {
			GameObject adventureCard = advDeck.Draw ();
			adventureCard.transform.SetParent (gameUsers.findByUserName ("Player" + player).GetComponent<User> ().getHand ().transform);
		}
		logger.info ("GameManager.cs :: AdventureCards :: Player " + player + " Picked up: " + amount + " adventure cards.");
	}

	public void PickUpAdventureCardsTest(List<GameObject> users, int cards){
		foreach (GameObject i in users) {
			for (int k = 0; k < cards; k++) {
				GameObject adventureCard = advDeck.Draw ();
				logger.info ("GameManager.cs :: AdventureCards :: Player " + i.GetComponent<User> ().getName () + " Picked up adventure card.");
				adventureCard.transform.SetParent (i.GetComponent<User> ().getHand ().transform);

			}
		}
	}

	public void AllPlayersPickUpAdventureCards( int amount){
		for (int p = 0; p < totalUsers; p++) {
			logger.info ("GameManager.cs :: AdventureCards :: Player " + gameUsers.findByUserName ("Player" + p).GetComponent<User> ().getName () + " Picked up adventure card.");
			for (int i = 0; i < amount; i++) {
				GameObject adventureCard = advDeck.Draw ();
				adventureCard.transform.SetParent (gameUsers.findByUserName ("Player" + p).GetComponent<User> ().getHand ().transform);
			}
		}
	}

	public void buttonToggle(){
		buttonPushed = true;
	}

	void Mordred(){
		Instantiate (Resources.Load ("PreFabs/playerScreen") as GameObject);
	}

	/* AI Functions (Nico)
		1. AI Tournament Passed(CurrentAIPlayer, List of Users, Shields in Tourny)
		2. Sponsor Quest (AIPlayer, List of Users, Quest Card)\
		3. NextBid (AIPlayer, Bid Amount, Big Round)
		4. Discard (AIPlayer, Amount to Discard)
	*/

}
