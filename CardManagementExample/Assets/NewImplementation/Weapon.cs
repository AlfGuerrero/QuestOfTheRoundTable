using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	//protected static readonly string[] WEAPON_NAME = {"Horse", "Sword", "Dagger", "Excalibur", "Lance", "Battle-ax"};
	protected string name;
	protected int battlePoints;
	protected string type;
	protected WeaponScriptObj weapon;

	void Start(){
		weapon = Resources.Load<WeaponScriptObj> ("Cards/Test Of Valor");
		name = weapon.name;
		type = "weapon";
		battlePoints = weapon.battlePoints;

		GetComponent<SpriteRenderer> ().sprite = weapon.image;
	}

	public string getName(){
		return this.name;
	}
	public int getBattlePoints(){
		return this.battlePoints;
	}
}
