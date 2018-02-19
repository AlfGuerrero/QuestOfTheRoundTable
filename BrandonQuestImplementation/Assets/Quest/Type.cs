using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type : MonoBehaviour {

	public string getCardType(){
		string cardType = "";
		if(this.getComponent<Foe>() != null){
			cardType = "Foe";
		}else if(this.getComponent<Ally>() != null){
			cardType = "Ally";
		}else if(this.getComponent<Weapon>() != null){
			cardType = "Weapon";
		}else if(this.getComponent<Test>() != null){
			cardType = "Test";
		}
		return cardType;
	}
}
