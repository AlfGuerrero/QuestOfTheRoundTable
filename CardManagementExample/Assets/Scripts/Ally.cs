/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour {
	protected static readonly string[] ALLY_NAME = {"Sir Gawain", "King Pellinore", "Sir Percival", "Sir Tristan", "King Arthur", "Queen Guinevere", "Merlin", "Queen Iseult", "Sir Lancelot", "Sir Galahad", "Armour"};
	protected string name;
	protected int battlePoints;
	protected int bonusBattlePoints;
	protected int bidPoints;
	protected int bonusBidPoints;
	protected bool merlin = false;
	public Ally(string name){
		this.name = name;
		if (name.Equals (ALLY_NAME [0])) {
			this.battlePoints = 10;
			this.bonusBattlePoints = 20;
		} else if (name.Equals (ALLY_NAME [1])) {
			this.battlePoints = 10;
			this.bonusBidPoints = 4;
		} else if (name.Equals (ALLY_NAME [2])) {
			this.battlePoints = 5;
			this.bonusBattlePoints = 20;
		} else if (name.Equals (ALLY_NAME [3])) {
			this.battlePoints = 10;
			this.bonusBattlePoints = 20;
		} else if (name.Equals (ALLY_NAME [4])) {
			this.battlePoints = 10;
			this.bidPoints = 2;
		}else if (name.Equals (ALLY_NAME [5])) {
			this.bidPoints = 3;
		}else if (name.Equals (ALLY_NAME [6])) {
			this.merlin = true;
		}else if (name.Equals (ALLY_NAME [7])) {
			this.bidPoints = 2;
			this.bonusBidPoints = 4;
		}else if (name.Equals (ALLY_NAME [8])) {
			this.bidPoints = 15;
			this.bonusBattlePoints = 25;
		}else if (name.Equals (ALLY_NAME [9])) {
			this.bidPoints = 15;
		}else if (name.Equals (ALLY_NAME [10])) {
			this.bidPoints = 1;
			this.battlePoints = 10;
		}
	}
	public string getName(){
		return this.name;
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
*/