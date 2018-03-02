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
	public AdventureDeck 		advDeck;
	public StoryDeck 			storyDeck;
	public TournamentManager 	Tournaments;
	public EventsManager 		Events;
	public QuestManager 		Quests;
	public GameObject			StoryCard;
	public User 				currentUser;
	public QuestGame.Logger	logger;
	public bool statsToggle = false;
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

	GameObject PlayerStats;
	public Text playerName;
	public Text playerRank;
	public Text playerShields;
	public Text playerBattlePoints;
	public Text playerCardsInHand;

	bool buttonPushed = false;
	bool doThisOnce = true;
	bool doThisOnceMore = true;
	void Start () {
		gameUsers =  new Users(textBoxInput, 0);
		totalUsers = gameUsers.getNumberOfUsers ();
		advDeck.populateDeck();

		//storyDeck.populateDeck ();
		passed = new bool[4] {false,false,false,false};

		logger = new QuestGame.Logger ();



		logger.info ("GameManager.cs :: Game has been created with " + totalUsers + " players." );
		logger.info ("GameManager.cs :: Adventure advDeck has been created. with sizes of " + advDeck.getSizeOfDeck());
		logger.info ("GameManager.cs :: Story storyDeck has been created. with sizes of " + storyDeck.getSizeOfDeck());

		logger.info ("GameManager.cs :: Game has been created with " + totalUsers + " players.");
		logger.info ("GameManager.cs :: Adventure advDeck has been created. with sizes of " + advDeck.getSizeOfDeck());
		logger.info ("GameManager.cs :: Story storyDeck has been created. with sizes of " + storyDeck.getSizeOfDeck());

		PickUpAdventureCard (0, "Saxons");
		PickUpAdventureCard (0, "Boar");
		PickUpAdventureCard (0, "Dagger");
		PickUpAdventureCard (0, "Sword");

		PickUpAdventureCard (1, "Sword");

		PickUpAdventureCard (2, "Horse");
		PickUpAdventureCard (2, "Excalibur");
		PickUpAdventureCard (2, "Amour");

		PickUpAdventureCard (3, "Battle-ax");
		PickUpAdventureCard (3, "Lance");
		PickUpAdventureCard (3, "Thieves");

		PickUpAdventureCards (0, 8);
		PickUpAdventureCards (1, 11);
		PickUpAdventureCards (2, 9);
		PickUpAdventureCards (3, 9);

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


//		playerName.text = "Player: " + names;
//		playerRank.text = "Rank: " + ranks;
//		playerShields.text = "Shields: " + shields;
//		playerBattlePoints.text = "Base Points: " + battlePoints;
//		playerCardsInHand.text = "Cards In Hand: "	+ cardsinHand;


	}

	void Update () {

		//Debug.Log ("PlayerTUrn: "+playerTurn);
		if (Input.GetKeyDown("tab")){
			statsToggle = true;
			PlayerStats = Resources.Load ("PreFabs/Stats") as GameObject;
			PlayerStats = Instantiate (PlayerStats, GameObject.Find("MainUI").transform);
			displayUsersInfo ();
		}
		if (statsToggle == true && Input.GetKeyUp("tab")){
			Destroy (PlayerStats.gameObject);
			foreach (GameObject g in GameObject.FindGameObjectsWithTag ("SmallCard")) {
				Destroy (g);
			}
			statsToggle = false;
		}
		if(GameObject.Find ("Button (1)") != null){
		GameObject.Find ("Button (1)").GetComponent<Button>().onClick.AddListener(delegate {buttonToggle();});
		}

		if(questInPlay){
			if (counter < 4) {
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					Debug.Log (playerTurn + "Sponsoring");
					Quests.Setup (gameUsers.findByUserName ("Player" + playerTurn).gameObject);
					passed [playerTurn] = false;
					sponsorturn = playerTurn;
					//questInProgress = true;
					questInPlay = false;
					counter = 0;
				} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
					Debug.Log (playerTurn + "Not Sponsoring");
					playerTurn++;
					if(playerTurn > 3){
						playerTurn = 0;
					}
					togglePlayerCanvas (playerTurn);
					counter++;
				}
			} else {
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

					if (passed [playerTurn] == true) {//then playthrough with that player
						if (stageInt != 6) {//then quest not over yet
							togglePlayerCanvas (playerTurn);
							currentUser = gameUsers.findByUserName ("Player" + playerTurn).GetComponent<User> ();
							Quests.Playthrough (currentUser.gameObject, stageInt);
							counter++;

						} else {//the quest is done
							Debug.Log ("THE QUEST IS DONE NINJA!!");
							Debug.Log ("Sponsor is drawing cards");
							PickUpAdventureCards (sponsorturn,6);
							for(int j = 0; j < passed.Length; j++){
								if (passed [j] == true) {
									Debug.Log ("Player: " + j + " is a winner");
									User temp = gameUsers.findByUserName ("Player" + j).GetComponent<User> ();
									temp.setShields (temp.getShields () + StoryCard.GetComponent<Quest> ().getStages ());
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
						Debug.Log ("Everyone died before the end of the quest");
						questPlaying = false;
						Debug.Log ("Sponsor is drawing cards");
						PickUpAdventureCards (sponsorturn,6);
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
						}
					}
					if(playersPlaying < 1){
						allDead = true;
					}
				} else {
					if(playersPlaying > 0){

						counter = 0;
						stageInt++;
						Debug.Log ("Increasing the stage to: "+stageInt);
						for(int m = 0; m < passed.Length; m++) {
							if(passed[m] == true){
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

		//here
		if (buttonPushed == true) {
			if(false){
//			if(questInProgress == true){
//
//				//Debug.Log ("Quest in progress");
//				if(keepPlaying == true){
//					//Debug.Log ("keep playing");
//
//					if(playerTurn != sponsorturn){
//						if(stageInt == 0){
//							togglePlayerCanvas (playerTurn);
//							Quests.Playthrough (currentUser.gameObject, stageInt);
//						}else if(stageInt == 1){
//							//runThrough with people who have passed previous stage
//						}
//						if (playerTurn == totalUsers+1) {
//							playerTurn = 0;
//							//togglePlayerCanvas (playerTurn);
//						}
//					}else{
//						playerTurn++;
//						togglePlayerCanvas (playerTurn);
//						Quests.Playthrough (currentUser.gameObject, stageInt);
//					}
//					keepPlaying = false;
//				}

			}else{

				togglePlayerCanvas (playerTurn);
				PickupStoryCards2(playerTurn, storyCardToDraw);

	//			PickUpAdventureCards(playerTurn, 1);
				currentUser = gameUsers.findByUserName ("Player" + playerTurn).GetComponent<User> ();
				handleStoryCards (currentUser);

				playerTurn++;
				if(playerTurn > 3){
					playerTurn = 0;
				}

				Debug.Log ("Players turn = " + playerTurn);
				if (playerTurn == totalUsers+1) { playerTurn = 0; }
				buttonPushed = false;
				//if(!doThisOnce){
				if (storyCardToDraw == "Boar Hunt") {
					storyCardToDraw = "Prosperity Throughout the Realm";
				} else if (storyCardToDraw == "Prosperity Throughout the Realm") {
					storyCardToDraw = "Chivalrous Deed";
				} else {
					storyCardToDraw = "Slay The Dragon";
				}
			//	}
			if(doThisOnce){
					playerTurn -= 1;
					doThisOnce = false;
				}
			}

		}

		if (Tournaments.getCardsSubmitted () == true) {
			Debug.Log ("GetCardsSubmitted = true");
			Tournaments.Tournament (currentUser.gameObject, StoryCard.GetComponent<Tournament>());
			Tournaments.setCardsSubmitted (false);
		}

	}

	public void handleStoryCards(User currentUser){

		if (StoryCard.GetComponent<Event> () != null ){
			Event evnt = StoryCard.GetComponent<Event> ();
			if (evnt.getName() == "King's Recognition") {
				logger.info ("GameManager.cs :: Player " + playerTurn + " number of shields. " + currentUser.getShields ());
				logger.test ("GameManager.cs :: Event :: Running King's Recognition...");
				Events.Kings_Recoginition (currentUser, gameUsers);
				logger.info ("GameManager.cs :: Player " + playerTurn + " number of shields. " + currentUser.getShields ());
			}
			else if (evnt.getName() == "Queen's Favor") {
				logger.test ("GameManager.cs :: Event :: Running Queen's Favor.");
				PickUpAdventureCardsTest(Events.Queens_Favor (gameUsers), 2);
			}
			else if (evnt.getName() == "Court Called to Camelot"){
				logger.info ("GameManager.cs :: Player " + playerTurn + " Base Attack. " + currentUser.getbaseAttack ());
				logger.info ("GameManager.cs :: Running Court Called to Camelot.");
				Events.Court_Called_To_Camelot (gameUsers);
				logger.info ("GameManager.cs :: Player " + playerTurn + " Base Attack. " + currentUser.getbaseAttack ());

			}
			else if (evnt.getName() == "Pox"){
				logger.info ("GameManager.cs :: Player " + playerTurn + " number of shields. " + currentUser.getShields ());
				logger.test ("GameManager.cs :: Running Pox.");
				Events.Pox (currentUser, gameUsers);
				logger.info ("GameManager.cs :: Player " + playerTurn + " number of shields. " + currentUser.getShields ());
			}
			else if (evnt.getName() == "Plague"){
				logger.info ("GameManager.cs :: Player " + playerTurn + " number of shields. " + currentUser.getShields ());
				logger.test ("GameManager.cs :: Running Plague.");
				Events.Plague (currentUser);
				logger.info ("GameManager.cs :: Player " + playerTurn + " number of shields. " + currentUser.getShields ());
			}
			else if (evnt.getName() == "Chivalrous Deed"){
				logger.info ("GameManager.cs :: Player " + playerTurn + " number of shields. " + currentUser.getShields ());
				logger.test ("GameManager.cs :: Running Chivalrous Deed.");
				Events.Chivalrous_Deed (currentUser, gameUsers);
				logger.info ("GameManager.cs :: Player " + playerTurn + " number of shields. " + currentUser.getShields ());
			}
			else if (evnt.getName() == "Prosperity Throughout the Realm"){
				logger.test ("GameManager.cs :: Running Prosperity Throughout the Realm.");
				PickUpAdventureCardsTest (Events.Prosperity_Throughout_The_Realm(gameUsers), 2);
			}
			else if (evnt.getName() == "King's Call to Arms"){
				logger.test ("GameManager.cs :: Running King's Call to Arms. (IN PROGRESS)");
			}
		}
		else if (StoryCard.GetComponent<Quest> () != null ){
			Quest quest = StoryCard.GetComponent<Quest> ();
			//Debug.Log ("Players turn = " + playerTurn);
			//Quests.Setup(gameUsers.findByUserName ("Player" + playerTurn).gameObject);
			questInPlay = true;
			//keepPlaying = true;
			stageInt = 0;


			logger.test ("GameManager.cs :: Quest Name: " + quest.getName());

		}
		else if (StoryCard.GetComponent<Tournament> () != null) {
			Tournament tournament = StoryCard.GetComponent<Tournament> ();
			logger.test ("GameManager.cs :: Tournament Name: " + tournament.getName());
			Debug.Log ("GameManager.cs :: Running Tournament : " + tournament.getName ());

//			for (int n = 0; n < totalUsers; n++) {
//				if (Input.GetKeyDown ("y")) {
//
//					n++;
//				} else if (Input.GetKeyDown ("n")) {
//					n++;
//				}
//			}
//
			Tournaments.gameObject.GetComponent<TournamentManager> ().beginTournament(currentUser.gameObject);
//			Tournaments.gameObject.GetComponent<TournamentManager> ().beginTournament(gameUsers);

//			if (TournamentManager.gameObject.GetComponent<TournamentManager> ().getTieBreaker () == true) {
//
//			}
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
		logger.info ("GameManager.cs :: StoryCards :: Player " + player + " Picks up: " + StoryCard);
	}

	public void PickupStoryCards2(int player, string card){
		if (StoryCard != null){Destroy(StoryCard);}
		StoryCard = storyDeck.Draw2 (card);
		StoryCard.transform.SetParent (GameObject.Find("MainUI").transform);
		StoryCard.transform.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0.0f, 0.0f);
		logger.info ("GameManager.cs :: StoryCards :: Player " + player + " Picks up: " + StoryCard);
	}

	public void PickUpAdventureCards(int player, int amount){
		for (int i = 0; i < amount; i++) {
			GameObject adventureCard = advDeck.Draw ();
			adventureCard.transform.SetParent (gameUsers.findByUserName ("Player" + player).GetComponent<User> ().getHand ().transform);
			logger.info ("GameManager.cs :: AdventureCards :: Player " + player + " Picked up: " + i+1 + " cards");
		}
	}

	public void PickUpAdventureCard(int player, string card){
			GameObject adventureCard = advDeck.Draw2 (card);
			adventureCard.transform.SetParent (gameUsers.findByUserName ("Player" + player).GetComponent<User> ().getHand ().transform);
			logger.info ("GameManager.cs :: AdventureCards :: Player " + player + " Picked up: " + card);
	}

	public void PickUpAdventureCardsTest(List<GameObject> users, int cards){
		foreach (GameObject i in users) {
			for (int k = 0; k < cards; k++) {
				GameObject adventureCard = advDeck.Draw ();
				adventureCard.transform.SetParent (i.GetComponent<User> ().getHand ().transform);
				logger.info ("GameManager.cs :: AdventureCards :: Player " + i + " Picked up: " + k+1 + " cards");

			}
		}
	}

	public void AllPlayersPickUpAdventureCards( int amount){
		for (int p = 0; p < totalUsers; p++) {
			for (int i = 0; i < amount; i++) {
				GameObject adventureCard = advDeck.Draw ();
				adventureCard.transform.SetParent (gameUsers.findByUserName ("Player" + p).GetComponent<User> ().getHand ().transform);
			}
		}
	}

	public void buttonToggle(){
		buttonPushed = true;
		keepPlaying = true;
		//playerTurn += 1;
	}



	/* AI Functions (Nico)
		1. AI Tournament Passed(CurrentAIPlayer, List of Users, Shields in Tourny)
		2. Sponsor Quest (AIPlayer, List of Users, Quest Card)\
		3. NextBid (AIPlayer, Bid Amount, Big Round)
		4. Discard (AIPlayer, Amount to Discard)
	*/

}
