using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AImanager : MonoBehaviour {
	//MAKE SPECIFIC FUNCTIONS FOR EACH FUNCTION IN THE OTHER CLASS.




	//Breakdown functions
	public List<GameObject> getHand(User currentAi){
		List<GameObject> cardsInHand = currentAi.getHand ();
		return cardsInHand;
		//cardsInHand [1].GetComponent<AdventureCard> ().getType ();
	}


}
