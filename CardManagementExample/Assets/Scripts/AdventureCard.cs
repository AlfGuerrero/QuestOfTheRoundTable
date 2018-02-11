using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class AdventureCard<T>{
	protected static readonly string[] ADVENTURE_TYPE = {"Foe", "Ally", "Weapon", "Test"};
	protected string name;
	protected string type;
	protected T childObject;
	public AdventureCard(){
		this.childObject = default(T);
		this.name = "";
		this.type = "";
	}
	public AdventureCard(string type, string name){
		this.type = type;
		this.name = name;

		if (type.Equals ("Ally")) {
			//Ally ally = new Ally(name);
			//Debug.Log(childObject.GetType());

		} else if (type.Equals ("Foe")) {
			//Foe foe = new Foe (name);
			//this.childObject = foe;
		} else if (type.Equals ("Weapon")) {
			//Weapon weapon = new Weapon(name);
			//this.childObject = weapon;
		}else if (type.Equals ("Test")) {
			//Test test = new Test(name);
			//this.childObject = test;
		}

	}
		
	public string getName(){
		return name;
	}
	public string getType(){
		return type;
	}
	public T getchildObject(){
		return childObject;
	}
		
}

