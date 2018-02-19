using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController{
public class GameManager : MonoBehaviour {

	// Use this for initialization
	// Order of Gameplay...
	/* 
	 * Ask for # of users from UI Textbox. - waits to be pressed enter. 
	 * 
	 * */
	public static Users gameUsers;
	int totalUsers; 
	int textBoxInput = 3;						// Will be changed to rom Textbox input UI.
	int playerTurn = 0;
	bool isWinner = false;
	public AdventureDeck adventureDeck = new AdventureDeck();
	public StoryDeck storyDeck = new StoryDeck();

	void Start () {
	}

	void Awake(){
		gameUsers = new Users(textBoxInput);
		totalUsers = gameUsers.getNumberOfUsers ();	// Verify. 
		Debug.Log ("GameManager.cs :: Game has been created with " + totalUsers + " players." );

	}

	// Update is called once per frame
	void Update () {
		/* 
		 * 			
		 * If Button Been Pressed. Increase Module . 
		 * Draw Adventure Card for Player 1 Turn...
		 * If Adventure Card is 
		 * 	- Event = CALL EVENT FUNCTIONS
		 * 	- Quest = CALL QUEST HAS HAPPENED
		 *  - Tourney = CALL TOURNEY HAS HAPPENED
		 * 	

		*/
		while(isWinner == false){

			if (Input.GetKeyDown ("space")){				// CHANGE TO GET UI BUTTON PRESSED EVENT....

				//storyDeck. ();


				Debug.Log ("GameManager.cs :: Player: " + playerTurn + "'s turn." );
				if (playerTurn == totalUsers) {
					playerTurn = 0;
				}
				playerTurn += 1;

			}
		
		}
	}


	public void PickUpAdventureCards(string handName, int amount){
		for (int i = 0; i < amount; i++) {
		    AdventureDeck adventureDeck = new AdventureDeck(); 
			adventureDeck.Draw ();
			adventureDeck.transform.SetParent (GameObject.Find (handName).transform);
		}
	}

		static public List<GameObject> getplayers(){
			return gameUsers.getUsers();
		}
	}
}