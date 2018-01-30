using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureCard {
	protected static readonly string[] ADVENTURE_TYPE = {"Foe", "Ally", "Weapon", "Test"};
	protected string name;
	protected string type;

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
				Weapon weapon = new Weapon(name);
			}else if (type.Equals ("Test")) {
				Test test = new Test(name);
			}

	}

	public string getName(){
		return name;
	}
	public string getType(){
		return type;
	}
		
}

