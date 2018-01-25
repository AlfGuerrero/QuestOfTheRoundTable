using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	protected string currentRank;			//either 1, 2, or 3.
	protected string 	playerID;

	protected int 	numberOfCards;
	protected int 	numberOfShields;

	protected int 	totalBattlePoints;
	protected int 	totalBiddingPoints;

	// Use this for initialization
	public PlayerManager(){

	}
	void Start () {
		playerID 		= this.gameObject.name;
		currentRank 	= this.transform.Find ("Rank").tag;

		numberOfCards		= 0;
		numberOfShields		= 0;
		totalBattlePoints 	= 0;
		totalBiddingPoints 	= 5;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			print ("Player: " + getPlayerID() + " Of Rank: " + getRank());
//			print ("Number Of Cards:" + getCardAmount());
//			print ("Number Of Shields:" + getShieldAmount());
//			print ("Total Battle Points:" + getBattlePoints());
//			print ("Total Bidding Points:" + getBiddingPoints());
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
	void setShieldAmount(int ShieldAmount){numberOfShields = ShieldAmount; }
	int getShieldAmount(){return numberOfShields; }

	// Battle Points Functions.
	void setBattlePoints(int BattlePoints){totalBattlePoints = BattlePoints; }
	int getBattlePoints(){return totalBattlePoints;}

	// Bidding Points Functions. 
	void setBiddingPoints(int BiddingPoints){totalBiddingPoints = BiddingPoints; }
	int getBiddingPoints(){return totalBiddingPoints; }

}
