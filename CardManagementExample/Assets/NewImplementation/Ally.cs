using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour {
	//protected static readonly string[] ALLY_NAME = {"Sir Gawain", "King Pellinore", "Sir Percival", "Sir Tristan", "King Arthur", "Queen Guinevere", "Merlin", "Queen Iseult", "Sir Lancelot", "Sir Galahad", "Armour"};
	protected new string name;
	protected string type;
	protected int battlePoints;
	protected int bonusBattlePoints;
	protected int bidPoints;
	protected int bonusBidPoints;
	protected bool merlin = false;

	public AllyScriptObj ally;

	void Start(){
		name = ally.name;
		battlePoints = ally.battlePoints;
		bonusBattlePoints = ally.bonusBattlePoints;
		bidPoints = ally.bidPoints;
		bonusBidPoints = ally.bonusBidPoints;
		merlin = ally.merlin;
		type = "ally";
		ally = Resources.Load<AllyScriptObj> ("Cards/Sir Gawain");
		GetComponent<SpriteRenderer> ().sprite = ally.image;
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
	public int getBidPoints(){
		return this.bidPoints;
	}
	public int getBonusBattlePoints(){
		return this.bonusBattlePoints;
	}
	public int getBonusBidPoints(){
		return this.bonusBidPoints;
	}
}
