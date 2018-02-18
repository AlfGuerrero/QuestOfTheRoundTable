using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour {
	protected static readonly string[] RANK_NAME = {"Squire", "Knight", "Champion Knight"};
	protected string user_name;
	protected int shields;
	protected int baseAttack;
	protected string rank;
	//public GameObject user_rank_ui;
	//public GameObject hand; //canvas for their hand
	/*public User(string user_name){
		this.user_name = user_name;
		this.shields = 0;
		this.baseAttack = 5;
		this.rank = RANK_NAME [0];
	}*/
	public void Initialize(string user_name){
		this.user_name = user_name;
		this.shields = 0;
		this.baseAttack = 5;
		this.rank = RANK_NAME [0];
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
}
