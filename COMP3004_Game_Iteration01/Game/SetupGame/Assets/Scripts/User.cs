using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QuestGame;

public class User : MonoBehaviour {
	protected static readonly string[] RANK_NAME = {"Squire", "Knight", "Champion Knight"};
	protected string user_name;
	protected int shields;
	protected int baseAttack;
	protected string rank;
	protected bool ai;
	protected Text playerName;
	protected List<AdventureCard> hand_ally;
	protected QuestGame.Logger	logger;
	protected Sprite Squire;
	protected Sprite Knight;
	protected Sprite ChampionKnight;
//	protected Sprite KnightOfTheRoundTable = (Resources.Load("sprites/") as Sprite);


	//public GameObject user_rank_ui;
	//public GameObject hand; //canvas for their hand
	/*public User(string user_name){
		this.user_name = user_name;
		this.shields = 0;
		this.baseAttack = 5;
		this.rank = RANK_NAME [0];
	}*/

	public void Initialize(string user_name,bool ai){
		logger = new QuestGame.Logger ();
		this.user_name = user_name;
		this.shields = 0;
		this.baseAttack = 5;
		this.rank = RANK_NAME [0];
		this.ai = ai;
		this.hand_ally = new List<AdventureCard> ();
		Squire = (Resources.Load<Sprite>("sprites/Squire") as Sprite);
		Knight = (Resources.Load<Sprite>("sprites/Knight") as Sprite);
		ChampionKnight =(Resources.Load<Sprite>("sprites/Champion Knight") as Sprite);
		this.gameObject.transform.GetChild(3).GetComponent<Text>().text =  ("Player: " + this.user_name);
		this.gameObject.transform.GetChild(4).GetComponent<Text>().text =  ("Rank: " + this.rank);
		this.gameObject.transform.GetChild(5).GetComponent<Text>().text =  ("Shields: " + this.shields);
		this.gameObject.transform.GetChild(6).GetComponent<Text>().text =  ("BattlePoints: " + this.baseAttack);
		this.gameObject.transform.GetChild (1).GetComponent<Image> ().sprite = Squire;
		logger.info ("User.cs :: Initializing Player... " + this.user_name);


	}
	void Update(){
		this.gameObject.transform.GetChild(3).GetComponent<Text>().text =  ("Player: " + this.user_name);
		this.gameObject.transform.GetChild(4).GetComponent<Text>().text =  ("Rank: " + this.rank);
		this.gameObject.transform.GetChild(5).GetComponent<Text>().text =  ("Shields: " + this.shields);
		this.gameObject.transform.GetChild(6).GetComponent<Text>().text =  ("BattlePoints: " + this.baseAttack);

		if (getCards ().Count > 12) {
			GameObject.FindGameObjectWithTag ("Hold").transform.GetChild (0).gameObject.SetActive (true);
		} else {
			GameObject.FindGameObjectWithTag ("Hold").transform.GetChild (0).gameObject.SetActive (false);
		}
	}

	public string getName(){
		return this.user_name;
	}

	public string getRank(){
		if (12 > this.shields && this.shields >= 5) {
			logger.info ("User.cs :: Ranking Up: " + this.user_name);
			this.rank ="Knight";
			this.gameObject.transform.GetChild (1).GetComponent<Image> ().sprite = Knight;
		}
		else if ( 22 > this.shields && this.shields >= 12) {
			logger.info ("User.cs :: Ranking Up: " + this.user_name);
			this.gameObject.transform.GetChild (1).GetComponent<Image> ().sprite = ChampionKnight;
			this.rank = "Champion Knight";
		}
		else if (this.shields >= 22) {
			logger.info ("User.cs :: Ranking Up: " + this.user_name);
			this.rank = "Knight Of the Round Table";
		}
		this.gameObject.transform.GetChild(4).GetComponent<Text>().text =  ("Rank: " + this.rank);
		return this.rank;
	}
	public int getShields(){
		return this.shields;
	}
	public int getbaseAttack(){
		return this.baseAttack;
	}
	public void setName(string user_name){
		this.user_name = user_name;
	}

	public void setShields(int shields){
		this.gameObject.transform.GetChild(5).GetComponent<Text>().text =  ("Shields: " + this.shields);
		this.shields = shields;
	}
	public void setBaseAttack(int baseAttack){
		logger.info ("User.cs :: setBaseAttack function has been called for Player:  " + this.user_name + " Base Attack: " + this.baseAttack);
		this.gameObject.transform.GetChild(6).GetComponent<Text>().text =  ("BattlePoints: " + this.baseAttack);
		this.baseAttack = baseAttack;
		logger.info ("User.cs :: setBaseAttack function has been called for Player:  " + this.user_name + " New Base Attack: " + this.baseAttack);
	}
	public bool getAI(){
		return this.ai;
	}
	public void addAlly(AdventureCard Ally){
		hand_ally.Add (Ally);
		logger.info ("User.cs :: addAlly function has been called for Player:  " + this.user_name + " Adding Ally: " + Ally.getName());
		logger.info ("User.cs :: addAlly function has been called for Player:  " + this.user_name + " Ally Battle Points: " + Ally.getBonusBattlePoints());

	}

	public void removeAlly(string ally){
		foreach(AdventureCard a in hand_ally){
			if (a.getName() == ally) {
				hand_ally.Remove (a);
				this.setBaseAttack (this.getbaseAttack () - a.getBattlePoints ());
			}
		}

	}

	public List<AdventureCard> getAllies(){
		return hand_ally;
	}


	public int getAllyBattlePoints(int bonus){
		int totalBattlePoints = 0;
		foreach (AdventureCard i in this.hand_ally) {
			totalBattlePoints += i.getBattlePoints ();
		}
		logger.info ("User.cs :: getAllyBattlePoints function has been called for Player:  " + this.user_name + " BattlePoints: " + totalBattlePoints);
		totalBattlePoints += bonus;
		logger.info ("User.cs :: getAllyBattlePoints function has been called for Player:  " + this.user_name + " New BattlePoints: " + totalBattlePoints);
		return totalBattlePoints;
	}

	public bool isRankUpgrade(){
		if (this.rank == RANK_NAME [0]) {
			if (this.shields == 5)
				return true;
			else
				return false;
		} else if (this.rank == RANK_NAME [1]) {
			if (this.shields == 10)
				return true;
			else
				return false;
		} else if (this.rank == RANK_NAME [2]) {
			if (this.shields == 15)
				return true;
			else
				return false;
		} else {
			return false;
		}
	}

	public List<GameObject> getCards(){
		List<GameObject> result = new List<GameObject>();
		GameObject hand = GameObject.Find ("Hand");
		int handCount = hand.transform.childCount;
		for (int i = 0; i < handCount; i++) {
			result.Add(hand.transform.GetChild (i).gameObject);
		}
		return result;
	}

	public GameObject getHand(){
		foreach (Transform t in transform)
		{
			if (t.name == "Hand")
				return t.gameObject;

		}
			return null;
	}
}
