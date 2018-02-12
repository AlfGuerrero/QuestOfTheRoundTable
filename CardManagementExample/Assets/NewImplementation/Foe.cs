using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foe : MonoBehaviour {
	protected new string name;
	protected int battlePoints;
	protected int bonusBattlePoints;
	protected bool mordred;
	protected string type;
	protected FoeScriptObj foe;
	protected string card;
	// Use this for initialization
	void Start(){
		foe = Resources.Load<FoeScriptObj> ("Foe/"+card);
		name = foe.name;
		type = "foe";
		GetComponent<SpriteRenderer> ().sprite = foe.image;
		battlePoints = foe.battlePoints;
		bonusBattlePoints = foe.bonusBattlePoints;
		mordred = foe.mordred;

		Debug.Log (name + " " + type + " " + battlePoints);
	}
	public string getName(){
		return this.name;
	}
	public string getType(){
		return this.type;
	}
	public int getBattlePoints(){
		return this.battlePoints;
	}
	public int getBonusBattlePoints(){
		return this.bonusBattlePoints;
	}
	public void setCard (string cardName){
		card = cardName;
	}
}
