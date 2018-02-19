using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

	protected string currentRank;			//either 1, 2, or 3.
	protected string 	playerID;

	protected int 	numberOfCards;
	protected int 	numberOfShields;

	protected int 	totalBattlePoints;
	protected int 	totalBiddingPoints;

	public Text playerName;	
	public Text playerRank;
	public Text playerShields;
	public Text playerBattlePoints;
	public Text playerBiddingPoints;

	// Use this for initialization
	public PlayerManager(){

	}
	void Start () {
		playerID 		= this.gameObject.name;
		currentRank 	= this.transform.Find ("Rank").tag;

		numberOfCards		= 0;
		numberOfShields		= 0;
		totalBattlePoints 	= 0;
		totalBiddingPoints 	= 0;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
//			print ("Player: " + getPlayerID() + " Of Rank: " + getRank());
//			print ("Number Of Cards:" + getCardAmount());
//			print ("Number Of Shields:" + getShieldAmount());
//			print ("Total Battle Points:" + getBattlePoints());
//			print ("Total Bidding Points:" + getBiddingPoints());

			playerName.text 			= "Player: " 		+ getPlayerID ();
			playerRank.text 			= "Rank: " 			+ getRank ();
			playerShields.text			= "Shields: " 		+ getShieldAmount ();
			playerBattlePoints.text 	= "Battle Points: "	+ getBattlePoints ();
			playerBiddingPoints.text 	= "Bidding Points: "+ getBiddingPoints ();


		}
	}

	// Rank Functions.
	void setRank(string Rank){ currentRank = Rank; }
	string getRank(){ return currentRank; }

	// playerID Functions.
	void setPlayerID(string ID){ playerID = ID; }
	string getPlayerID(){ return playerID; }

	// Amount of Cards Functions. 
	void setCardAmount(int CardAmount){numberOfCards = CardAmount; }
	int getCardAmount(){return numberOfCards; }

	// Amount of Shields Functions. 
	void setShieldAmount(int ShieldAmount){numberOfShields = numberOfShields + ShieldAmount; }
	int getShieldAmount(){return numberOfShields; }

	// Battle Points Functions.
	public void setBattlePoints(int BattlePoints){totalBattlePoints = totalBattlePoints + BattlePoints; }
	public int getBattlePoints(){return totalBattlePoints;}

	// Bidding Points Functions. 
	void setBiddingPoints(int BiddingPoints){totalBiddingPoints = totalBiddingPoints + BiddingPoints; }
	int getBiddingPoints(){return totalBiddingPoints; }

}
