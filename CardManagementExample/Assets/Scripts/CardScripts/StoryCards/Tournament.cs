using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tournament : MonoBehaviour {

	protected new string name;
	protected int bonusShields;

	protected string type;

	protected TournamentScriptObj tournament;
	protected string card;
	// Use this for initialization
	void Start () {
		tournament = Resources.Load<TournamentScriptObj> ("Tournament/"+card);
		name = tournament.name;
		type = "tournament";
		GetComponent<SpriteRenderer> ().sprite = tournament.image;
		bonusShields = tournament.bonusShields;
	}
	public string getName(){
		return this.name;
	}
	public string getType(){
		return this.type;
	}
	public int getBonusShields(){
		return this.bonusShields;
	}
	public void setCard (string cardName){
		card = cardName;
	}
}
