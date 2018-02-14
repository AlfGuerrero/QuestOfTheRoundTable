using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	//protected static readonly string[] WEAPON_NAME = {"Horse", "Sword", "Dagger", "Excalibur", "Lance", "Battle-ax"};
	protected new string name;
	protected int battlePoints;
	protected string type;
	protected WeaponScriptObj weapon;
	protected string card;
	protected int value;
	void Start(){
		weapon = Resources.Load<WeaponScriptObj> ("Weapon/"+card);
		name = weapon.name;
		type = "weapon";
		value = weapon.value;
		battlePoints = weapon.battlePoints;

		GetComponent<SpriteRenderer> ().sprite = weapon.image;
	}

	public string getName(){
		return this.name;
	}
	public int getValue(){
		return this.value;
	} 
	public int getBattlePoints(){
		return this.battlePoints;
	}
	public void setCard (string cardName){
		card = cardName;
	}
}
