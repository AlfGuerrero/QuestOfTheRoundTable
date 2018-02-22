using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GameManager : EventsManager {

	// Use this for initialization
	// Order of Gameplay...
	/* 
	 * Ask for # of users from UI Textbox. - waits to be pressed enter. 
	 * 
	 * */
	static Users gameUsers;
	int totalUsers; 
	int textBoxInput = 3;						// Will be changed to rom Textbox input UI.
	int playerTurn = 0;
//	bool isWinner = false;
	public AdventureDeck 	advDeck;
	public StoryDeck 		storyDeck;
	public EventsManager 	Events; 
	public QuestManager 	Quests;
	bool buttonPushed = false; 

	void Start () {
		gameUsers =  new Users(textBoxInput, 0);
		totalUsers = gameUsers.getNumberOfUsers ();	
		advDeck.populateDeck();
		storyDeck.populateDeck ();
		Debug.Log ("GameManager.cs :: Game has been created with " + totalUsers + " players." );
		Debug.Log ("GameManager.cs :: Adventure advDeck has been created. with sizes of " + advDeck.getSizeOfDeck());
		Debug.Log ("GameManager.cs :: Story storyDeck has been created. with sizes of " + storyDeck.getSizeOfDeck());

//		PickUpAdventureCards (0, 1);
//		PickUpAdventureCards (1, 3);
//		PickUpAdventureCards (2, 5);
		togglePlayerCanvas (playerTurn);	

	}
		
	void Update () {
		GameObject.Find ("Button (1)").GetComponent<Button>().onClick.AddListener(delegate {buttonToggle();});

		if (buttonPushed == true) {				
			togglePlayerCanvas (playerTurn);
//			PickUpAdventureCards (playerTurn, 1);
			PickUpAdventureCards(playerTurn, 1);
			PickupStoryCards(playerTurn);
//			Quests.Setup(GameObject(gameUsers.findByUserName ("Player" + playerTurn)));
			playerTurn += 1;
			if (playerTurn == totalUsers)
				playerTurn = 0;
		}
		buttonPushed = false;
	}
	 
	public void buttonToggle(){
		buttonPushed = true;
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


//	public User getCurrentUser(){
//		GameObject player = gameUsers.findByUserName ("Player" + playerTurn);
//		return player.GetComponent<User>(); 
//	}


	public List<GameObject> getAllUsers(){
		return gameUsers.getUsers();
	}

	public void PickupStoryCards(int player){
		Debug.Log ("GameManager.cs :: Adding card to " +  gameUsers.findByUserName ("Player" + player));
		GameObject storyCard = storyDeck.Draw ();
		storyCard.transform.SetParent (gameUsers.findByUserName ("Player" + player).GetComponent<User> ().transform);
	}

	public void PickUpAdventureCards(int player, int amount){
		for (int i = 0; i < amount; i++) {
			Debug.Log ("GameManager.cs :: Adding card to " +  gameUsers.findByUserName ("Player" + player));
			GameObject adventureCard = advDeck.Draw ();
			adventureCard.transform.SetParent (gameUsers.findByUserName ("Player" + player).GetComponent<User> ().getHand ().transform);
		}
	}
//	public void SwitchPlayers(){
//		for (int i = 0; i < Players [playerPlaying-1].transform.childCount; i++) {
//			Players [playerPlaying-1].transform.GetChild (i).gameObject.SetActive (false);
//		}
//			
//
//		//Debug.Log (playerPlaying-1);
//
//		for (int i = 0; i < Players [playerPlaying-1].transform.childCount; i++) {
//			Debug.Log (Players [playerPlaying-1].transform.childCount);
//			Players [playerPlaying-1].transform.GetChild (i).gameObject.SetActive (true);
//		}
//	}
	/* AI Functions (Nico)
		1. AI Tournament Passed(CurrentAIPlayer, List of Users, Shields in Tourny)
		2. Sponsor Quest (AIPlayer, List of Users, Quest Card)\
		3. NextBid (AIPlayer, Bid Amount, Big Round)
		4. Discard (AIPlayer, Amount to Discard) 
	*/

	/*
		Dont forget logging.
	*/
}
