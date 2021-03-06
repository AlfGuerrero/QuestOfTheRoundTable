﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class User : MonoBehaviour {
	protected static readonly string[] RANK_NAME = {"Squire", "Knight", "Champion Knight"};
	protected string user_name;
	protected int shields;
	protected int baseAttack;
	protected string rank;
	protected bool ai;
	protected Text playerName;
	protected List<AdventureCard> hand_ally;

	//public GameObject user_rank_ui;
	//public GameObject hand; //canvas for their hand
	/*public User(string user_name){
		this.user_name = user_name;
		this.shields = 0;
		this.baseAttack = 5;
		this.rank = RANK_NAME [0];
	}*/

	public void Initialize(string user_name,bool ai){
		this.user_name = user_name;
		this.shields = 0;
		this.baseAttack = 5;
		this.rank = RANK_NAME [0];
		this.ai = ai;
		this.hand_ally = new List<AdventureCard> ();
	}
	void update(){
//		GameObject.Find ("PlayerText");
		if (this.shields == 5) {
			this.rank = RANK_NAME [0];
		}
		if (this.shields == 12) {
			this.rank = RANK_NAME [1];
		}
		if (this.shields == 22) {
			this.rank = RANK_NAME [2];
		}

	}

	public string getName(){
		return this.user_name;
	}
	public string getRank(){
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
		this.shields = shields;
	}
	public void setBaseAttack(int baseAttack){
		this.baseAttack = baseAttack;
	}
	public bool getAI(){
		return this.ai;
	}
	public void addAlly(AdventureCard Ally){
		hand_ally.Add (Ally);
	}
	public int getAllyBattlePoints(int bonus){
		int totalBattlePoints = 0;
		foreach (AdventureCard i in this.hand_ally) {
			totalBattlePoints += i.getBattlePoints ();
		}
		totalBattlePoints += bonus;
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
