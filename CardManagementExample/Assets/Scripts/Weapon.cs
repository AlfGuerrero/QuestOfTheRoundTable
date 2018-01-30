using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	protected static readonly string[] WEAPON_NAME = {"Horse", "Sword", "Dagger", "Excalibur", "Lance", "Battle-ax"};
	protected string name;
	protected int battlePoints;

	public Weapon(string name){
		this.name = name;
		if (name.Equals (WEAPON_NAME [0])) {
			this.battlePoints = 10;
		} else if (name.Equals (WEAPON_NAME [1])) {
			this.battlePoints = 10;
		} else if (name.Equals (WEAPON_NAME [2])) {
			this.battlePoints = 5;
		} else if (name.Equals (WEAPON_NAME [3])) {
			this.battlePoints = 30;
		} else if (name.Equals (WEAPON_NAME [4])) {
			this.battlePoints = 20;
		}else if (name.Equals (WEAPON_NAME [5])) {
			this.battlePoints = 15;
		}
	}

	public string getName(){
		return this.name;
	}
	public int getBattlePoints(){
		return this.battlePoints;
	}
}
