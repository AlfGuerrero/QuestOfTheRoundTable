using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic : MonoBehaviour {

	// Use this for initialization
	//void Start () {
		
//	}
	
	// Update is called once per frame
//	void Update () {
		
//	}



	//deciding on participating in tourni
		//I announce i play
		//Play as few cards to get 50 or my best pssible battle points

	//ssponor a quest
		//If someone else could win/evolve by winning this quest
		//Then I do not sponsor
		//else if 
		//I have the correct # of cards to sponsor, i do
	//Then sponsor; setup 2
		//if i cant sponor dont

	//setup 2
		//Setup the last stage to be at least 40
		//set up the second stage to be a test if possible
		//Set up previous stages from first to second last non-test stage, in increasting order, without using weapons

	//Do i partake in a quest
	/*Strategy(2:!!!
	IF!
	!!!C1!I!can!increment!by!10!at!each!stage!!!!AND
	!!!C2:!I!have!at!least!2!foes!of!less!than!25!points!(to!discard!for!a!test)
	THEN!participate!!and!play2
	ELSE!I!do!not!participate
		Play2:!
		R!if!a!test,!see4)!and!5)
		R!else!if!last!stage
			!!!!!!!!!!!!!then!play!strongest!valid!combination
		!!!!!!!!!!! else!play!an!increment!of!+10!using!amour!first,!then!ally,!then!weapon(s)
*/

	public void doIParticipateInTournament (){
		//play as few cards as possible to get to 50
		ArrayList cardsplayed;
		int currentpoints=0;
		//respond to the game manager that i partake
		while (currentpoints <= 50) {
		//search the hand or the highest value card
		//then add that card to the array
			//add the BP to the currentpoints value

		}
		//after while look, send the arraylist of cards over to game manager.

	}

	public void discardAfterWinningTest(){
	//round 1: search hand for all foes less than 25
	//round 2: search hand for all foes and duplicates
	}


	public void nextBid(){
	//round one, count the number of foes less than 25, bid that number
	//round 2 count the number of foes+ duplicates and bid that number.
	
	
	}
	public void DoISponsorAQuest(){
	//	if(Quest stages+user)
	}

	public void DoIParticiapteInQuest(){
		//If the User is able to increase by 10 bp every stage.
		//and
		//I have at least 2 foes of less than 25 to discard
		//then play2
		//if not dont.
		//call function play2
	}

	public void play2(){
		//if stage level is a quest call bid system 4/5
		//else if last stage, then play strongest valid combo.
		//else play an increment of 10 using armour first then ally then weapons.

	}
	public void TooManyCards(){
	
	//if the ai has too many cards discard the foes first and go from there.
	}



}
