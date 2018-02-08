using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
	/* 
	 * Name BP numerical value for stat calculation
	 * Dagger: +5, 1 
	 * Sword +10,3
	 * horse +10,4
	 * battle-axe +15,5
	 * Lance +20,6
	 * Excalibur +30, 7
	 * 
	 * 
	 * General hand ratio kept if possible:
	 * 4foes, 6-7 weps, If 1-2 ally
	 * else at least 4 foes and at least 6 weapons
	 * 
	 * 
	 * 
	 * 
	 */

	// Use this for initialization
	void Start () {
		//Set the starting hand amount (12) 
		//Fill hand with cards
		//set starting rank
	}
	
	// Update is called once per frame
	void Update () {
		//Find out what type of event is 'active'(quest,event,tourni)
		//if 'eventname'==quest{ 
		//if quest is not sponsord try to sponsor it, call function EventQuestSponsor
		//if quest is sponsord call the EventQuestparticipate function

		//if 'eventname'==event{ call to function event}
			//Do nothing because event isn't for specific player based.
		//if 'eventname'==tourni{ call to function tourni}
	}
	//Functions	
	//Functions that per-tain to events
	//Functions that per-tain to tourni

	void EventQuestSponsor(){
		//Check to see if able to sponsor the quest, based off the amount of foes and test cards
		//Decided if its going to be a hard or easy quest, bsassed off specific card values
		//choose the cards accordingly
	
	}
	void EventQuestParticipate(){
	//Check to see how many stages there are, along with how many more shields are needed to rank up/win
		//if #shields are within the number of quest shield rewards, go all out on the quest.
			// If foes=/= all, use a +5 or +10 for stage 1, stage2: +10, and dagger if have, stage3: +10-+20, stage4: +10-+20
		//else just play some +5,+10's if have them
		//if foes==all dont play any cards but join.

	}
	void Tourni(){
	//Check the Bonous shields and then the number of players already in the tournament or total, and see if you can win, 
		//if so go all out use all the weapons and allies.
		//If no other player can win based off the tournment join and play +10's or +5's

	}

	void discard(){
	}
	//If too many cards are in hand, discard the worse based on the numerical values displayed above
	//Trying to keep a stable ratio of certain card types if possible.
	/*
	 *Thieves		+5				1
	 *Boar			+5/15			1
	 *RobberKnight 	+15				2
	 *Saxons      	+10/20			3
	 *Saxon Knight  +15/25			3
	 *Evil Knight   +20/30			4
	 *Black Knight  +25/35			4
	 *Green Knight  +25/40			5
	 *Giant			+40				6
	 *Dragon 		+50/70			7
	 *Mordred 		+30				10
	 * 
	 * Keep the highest/ best possible cards
	 */ 

}
