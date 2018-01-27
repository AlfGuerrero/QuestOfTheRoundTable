using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using m_ally = Ally;
public class AdventureCard {
	protected static readonly string[] ADVENTURE_TYPE = {"Foe", "Ally", "Weapon", "Armour", "Test"};
	protected string name;
	protected string type;
	//protected int battlePoints;
	//protected int bidPoints;
	//protected int bonusBattlePoints;
	//protected int bonusBidPoints;
	public AdventureCard(){
		this.type = "";
		this.name = "";
	}
	public AdventureCard(string type, string name){
		this.type = type;
		this.name = name;
			if (type.Equals ("Ally")) {
				Ally ally = new Ally(name);
			} else if (type.Equals ("Foe")) {
			} else if (type.Equals ("Weapon")) {
			} else if (type.Equals ("Armour")) {
			}else if (type.Equals ("Test")) {
			}

	}

	public string getName(){
		return name;
	}
	public string getType(){
		return type;
	}
		
}

