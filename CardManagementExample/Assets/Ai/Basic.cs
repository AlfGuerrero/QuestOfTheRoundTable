using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic :MonoBehaviour {

//---------------------------------------------------------DOIPARTICIPATEINTOURNAMENT----------------------------------------------------------------------------------
	//Takes in a list of no duplicates of weapons,ally, 
	public Dictionary<bool,GameObject> DoIParticipateInTournament(List<GameObject> Cards){
		//Making new variables.
		List<GameObject> ObjetValues= new List<GameObject>();
		bool DoI = true;
		int TotalBattlePoints = 0;
		int StartingListLength;
		Dictionary<bool, List<GameObject>> ReturnObjects = new Dictionary<bool, List<GameObject>>(){};
		//Checks to see if the value is greater than 50 or best possible.
		while (TotalBattlePoints < 50) {
			GameObject temp;
			temp = HighestCard (Cards);
			TotalBattlePoints += temp.GetComponent<AdventureCard> ().getBattlePoints ();
			ObjetValues.Add (temp);
			RemoveDups (temp, Cards);Cards.Remove (temp);
			//Make sure there are no duplicates.
			if(Cards.Count==0){
				//Reached the highest possible BP with current cards.
				break;
			}
		}//End of While-loop
		return (ReturnObjects.Add (DoI, ObjetValues));
	}//End of Tourni


	public GameObject HighestCard(List<GameObject> CurrentCards,Quest CQuest){
		GameObject highest;
		highest = CurrentCards[0];
		foreach (GameObject current in CurrentCards) {
			if (current.GetComponent<AdventureCard> ().getType == CQuest.getBonusFoe) {
				if(current.GetComponent<AdventureCard>().getBonusBattlePoints()<=highest.GetComponent<AdventureCard>().getBattlePoints()){
					highest = current;
			}
			else if(current.GetComponent<AdventureCard>().getBattlePoints()<=highest.GetComponent<AdventureCard>().getBattlePoints()){
			highest = current;
			}
		}
		
		}return highest;
	}
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------






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
//------------------------------------------DISCARDAFTERWINNINGTEST---------------------------------------------------------------------------------------------------------

	public List<GameObject> discardAfterWinningTest(int roundWon,List<GameObject> Foes,List<GameObject> weapons){
	//round 1: search hand for all foes less than 25
		if(roundWon==1){
			return nextBid (0,1,Foes,weapons);
		}if (roundWon == 2) {
			return nextBid (0, 2, Foes, weapons);
		}
	//round 2: search hand for all foes and duplicates
	}

//----------------------------------------------------------------------------------------------------------------------------------------------------------

	//Passed A round number, Passed a list of foes, passed a list of weapons.
	public int nextBid(int currentbid,int RoundNumber,List<GameObject> Foes, List<GameObject> weapons){
	//round one, count the number of foes less than 25, bid that number
		List<GameObject> Bids;
		if (RoundNumber == 1) {
			Bids = FirstBid (Foes);
			if (currentbid < Bids.Count) {
				return Bids.Count;
			} else {
				return 0;
			}
		}
		if (RoundNumber == 2) {
			Bids = FirstBid;
			Bids.Add (SecondBid (weapons));
			if (currentbid < Bids.Count)
				return (Bids.Count);
		} else {return 0;}
	}
	//NextBid Ends Here




	public List<GameObject> FirstBid(List<GameObject>Foes){//foes under 25 BP
		List<GameObject> length;
		foreach (GameObject CurrentCard in Foes){
			if ((CurrentCard.GetComponent<AdventureCard> ().getType()== "Foe") && (CurrentCard.GetComponent<AdventureCard> ().getBattlePoints <= 25)) {
				if (!(length.Contains(CurrentCard))) {
					length.Add (CurrentCard);
				}
			}//end of first if					
		}
		return length;
	}
	public List<GameObject> SecondBid(List<GameObject>weapons){	//duplicates of weapons
		List<GameObject> length=null;
		GameObject Temp;
		foreach (GameObject CurrentCard in weapons) {
			Temp=CurrentCard;
			weapons.Remove (Temp);
			if (weapons.Contains (Temp)) {
				length.Add (Temp);
				RemoveDups (Temp, weapons); weapons.Remove (Temp);
			}
			//can't think right now
		}return length;
	}

	//----------------------------------------------------------------------------------------------------------------------------------------------------------
	//-----------------------------------------------------DOISPONSOR A QUEST-------------------------------------------------------------------------------------------
	public List<List<GameObject>> DoISponsorAQuest (Quest CurrentQuest, List<User> Players, List<GameObject>AIHand)
	{
		bool DoISponsor = true, Test = false;
		GameObject TestCard;
		List<GameObject> CheckAmount;
		int neededFoes = CurrentQuest.stages;
		List<GameObject> Foes = ListOfFoes (AIHand);
		List<GameObject> Weapons = ListOfWeapons (AIHand);
		List<GameObject> Stages;
	

		foreach (User Player in Players) {
			if (Player.getShields () + CurrentQuest.stages >= 10 && Player.getRank == "Champion Knight") {
				DoISponsor = false;
				break;
			}
		}
		if (DoISponsor == true) {
			foreach (GameObject IsTest in AIHand) {
				if (IsTest.GetComponent<AdventureCard> ().getType () == "Test") {
					Test = true;
					TestCard = IsTest;
					neededFoes -= 1;
					break;
				}
			}//end of foreach
			foreach (GameObject i in Foes) {
				if (!CheckAmount.Contains (i)) {
					CheckAmount.Add (i);
					RemoveDups (i, Foes);
					Foes.Remove (i);
				}
			}
			foreach (GameObject i in CheckAmount) {
				int counter = 0;
				foreach (GameObject m in Stages) {//Stages may have to be CurrentQuest.stages
					if (m == null) {
						break;
					}
					if (m.GetComponent<AdventureCard> ().getBattlePoints () != i.GetComponent<AdventureCard> ().getBattlePoints ()) {
						counter++;
					}
				}
				if (counter == Stages.Count) {
					Stages.Add (i);
				}
			}
		}

		if (neededFoes > Stages.Count) {
			DoISponsor = false;
		}if (DoISponsor == true) {
			SETUP2 (CurrentQuest,Stages,Weapons,TestCard);
		}
	}

	public List<List<GameObject>> SETUP2 (QuestScriptObj CurrentQuest,List<GameObject> Stages,List<GameObject> Weapons,GameObject TestCard){
		List<GameObject> stage1, stage2, stage3, stage4, stage5;
		List<List <GameObject>> Finalorder = { stage1, stage2, stage3, stage4, stage5 };
		int LastStage = HighestCard (Stages).GetComponent<AdventureCard> ().getBattlePoints ();

			for (int counter = CurrentQuest.stages; counter <= 0; counter--) {
				if (counter == CurrentQuest.stages) {
				//	int LastStage = HighestCard (Stages).GetComponent<AdventureCard> ().getBattlePoints ();
					Finalorder [0] [0] = HighestCard (Stages);
					int cardcount = 0;
					while (LastStage <= 40) {
						GameObject temp = HighestCard (Weapons);
						cardcount++;
						Finalorder [0] [cardcount] = temp;
						LastStage += temp.GetComponent<AdventureCard> ().getBattlePoints ();
						RemoveDups (temp, Weapons);
						Weapons.Remove (temp);
					}
				} else if (Test == true && counter == (CurrentQuest.stages) - 2) {
					Finalorder [counter - 2] = TestCard;
				} else {
					GameObject temp2 = HighestCard (Stages);
					Finalorder [counter] [0] = temp2;
					RemoveDups (temp2, Stages);
					Stages.Remove (temp2);
				}
			
			//start the ordering of the setup.
			return Finalorder;
		}
	}
		//SEtting the order of the carfs as well as setting up the final stage to 40

		

	//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
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
	//----------------------------------DISCARD--------------------------------------------------------------------------------------------------------------------------
	public void TooManyCards(int DiscardAmmount,List<GameObject> CardsInHand){
		foreach (GameObject CurrentCard in CardsInHand) {
		//calls to the test discard stuff.
		}
	//if the ai has too many cards discard the foes first and go from there.
	}
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
//---------------------------------------------------------ListOfFoes---------------------------------------------------------------------------------------------------
	public List<GameObject> ListOfFoes(List<GameObject> AIHand){
		List<GameObject> LFoes=null;
		foreach(GameObject Card in AIHand){
			if(Card.GetComponent<AdventureCard>().getType()=="Foe"){
				LFoes.Add (Card);
			}
		}return LFoes;
	}
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//----------------------------------------------------------ListOfWeapons-------------------------------------------------------------------------------------------------
	public List<GameObject> ListOfWeapons(List<GameObject>AIHand){
		List<GameObject> LWeapon=null;
		foreach(GameObject Card in AIHand){
			if(Card.GetComponent<AdventureCard>().getType()=="Weapon"){
				LWeapon.Add (Card);
			}
		}return LWeapon;
	}
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//--------------------------------------------------Remove-Duplicates-----------------------------------------------------------------------------------------------------
	public List<GameObject> RemoveDups(GameObject Value,List<GameObject> Hand){
		foreach (GameObject k in Hand) {
			if (Value == k) {
				Hand.Remove (Value);
			}
		}
		return Hand;
	}



}
