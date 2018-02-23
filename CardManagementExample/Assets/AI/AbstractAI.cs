using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
abstract public class AbstractAI :MonoBehaviour {


	public abstract Dictionary<bool,GameObject> DoIParticipateInTournament (List<GameObject> Cards);
	public abstract void DoIParticipateInTournament (List<GameObject> Cards,List<User> players, TournamentScriptObj TourniInfo);
	public abstract List<GameObject> discardAfterWinningTest (int roundWon, List<GameObject> Foes, List<GameObject> weapons);
	public abstract int nextBid (int currentbid, int RoundNumber, List<GameObject> Foes, List<GameObject> weapons);
	public abstract List<GameObject> FirstBid (List<GameObject>Foes);
	public abstract List<GameObject> SecondBid (List<GameObject>weapons);
	public abstract List<List<GameObject>> DoISponsorAQuest (QuestScriptObj CurrentQuest, List<User> Players, List<GameObject>AIHand);
	public abstract void DoIParticiapteInQuest ();
	public abstract void TooManyCards (int DiscardAmmount, List<GameObject> CardsInHand);
	//------------NON---ABSTRACT---- BELOW----------------------------------------------------------------------------------------------------------------------------------------

	//---------------------------------------------SETUP2--------------------------------------------------------------------------------------------------------------------------------

	public List<List<GameObject>> SETUP2 (QuestScriptObj CurrentQuest,List<GameObject> Stages,List<GameObject> Weapons,GameObject TestCard){
		List<GameObject> stage1, stage2, stage3, stage4, stage5;
		List<List <GameObject>> Finalorder = { stage1, stage2, stage3, stage4, stage5 };

		for (int counter = CurrentQuest.stages; counter <= 0; counter--) {
			if (counter == CurrentQuest.stages) {
				int LastStage = HighestCard (Stages).GetComponent<AdventureCard> ().getBattlePoints ();
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
	//---------------------------------------------SETUP2 END-------------------------------------------------------------------------------------------------------------------------------
	//---------------------------------------------SETUP1-------------------------------------------------------------------------------------------------------------------------------
	public  void play2 ();
	public  void Play1 ();
	public void SETUP1();
	public void discard ();
	//---------------------------------------------SETUP1 END---------------------------------------------------------------------------------------------------------------------------


//------------------------------------------------------------------------------------HIGHEST CARD----------------------------------------------------------------------------------------
	public GameObject HighestCard (List<GameObject> CurrentCards){
		GameObject highest;
		foreach (GameObject current in CurrentCards) {
			highest = current[0];
			if(current.GetComponent<AdventureCard>().getBattlePoints()<=highest.GetComponent<AdventureCard>().getBattlePoints()){
				highest = current;
			}
		}
		return highest;
	}

	//------------------------------------------------------------------------------------HIGHEST CARD END-----------------------------------------------------------------------------------
	//------------------------------------------------------------------------------------LIST OF FOES-----------------------------------------------------------------------------------

	public  List<GameObject> ListOfFoes (List<GameObject> AIHand){
		List<GameObject> LFoes=null;
		foreach(GameObject Card in AIHand){
			if(Card.GetComponent<AdventureCard>().getType()=="Foe"){
				LFoes.Add (Card);
			}
		}return LFoes;
	}
	//------------------------------------------------------------------------------------LIST OF FOES 	END-----------------------------------------------------------------------------------
	//------------------------------------------------------------------------------------LIST OF WEAPONS-----------------------------------------------------------------------------------

	public  List<GameObject> ListOfWeapons (List<GameObject>AIHand){
		List<GameObject> LWeapon=null;
		foreach(GameObject Card in AIHand){
			if(Card.GetComponent<AdventureCard>().getType()=="Weapon"){
				LWeapon.Add (Card);
			}
		}return LWeapon;
	}
	//------------------------------------------------------------------------------------LIST OF WAPONS	END-----------------------------------------------------------------------------------
	//------------------------------------------------------------------------------------REMOVE DUPLICATES-----------------------------------------------------------------------------------

	public List<GameObject> RemoveDups (GameObject Value, List<GameObject> Hand){
		foreach (GameObject k in Hand) {
			if (Value == k) {
				Hand.Remove (Value);
			}
		}
		return Hand;
	}
	//------------------------------------------------------------------------------------REMOVE DUPLICATES	END-----------------------------------------------------------------------------------


}//End of CLASS
/*
 *\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
 * \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
 * \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
 * 
*/





public class Strat2:AbstractAI{
//----------------------------------------------------DO-I-SPONSOR-A-QUEST-------------------------------------------------------------------------------------------------------------
	public override List<List<GameObject>> DoISponsorAQuest (QuestScriptObj CurrentQuest, List<User> Players, List<GameObject>AIHand)
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
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//---------------------------------------------------------DOIPARTICIPATEINTOURNAMENT----------------------------------------------------------------------------------
	//Takes in a list of no duplicates of weapons,ally, 
	public override Dictionary<bool,GameObject> DoIParticipateInTournament(List<GameObject> Cards,List<User> PeopleInTourni){
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
	//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	//------------------------------------------DISCARDAFTERWINNINGTEST---------------------------------------------------------------------------------------------------------

	public override List<GameObject> discardAfterWinningTest(int roundWon,List<GameObject> Foes,List<GameObject> weapons){
		//round 1: search hand for all foes less than 25
		if(roundWon==1){
			return nextBid (0,1,Foes,weapons);
		}if (roundWon == 2) {
			return nextBid (0, 2, Foes, weapons);
		}
		//round 2: search hand for all foes and duplicates
	}

	//--------------------------------------------------------------------------NEXT BID----------------------------------------------------------------------------------------------------------
	public override int nextBid (int currentbid, int RoundNumber, List<GameObject> Foes, List<GameObject> weapons){
		
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
		} else {return 0;
		}
	}
	//---------------------------------------------------------------------------NEXT BID END--------------------------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------FIRST BID--------------------------------------------------------------------------------------------------------------------
	public override List<GameObject> FirstBid(List<GameObject>Foes){
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
	//---------------------------------------------------------------------------FIRST BID END--------------------------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------SECOND BID--------------------------------------------------------------------------------------------------------------------
	public override List<GameObject> SecondBid (List<GameObject>weapons){

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

	//---------------------------------------------------------------------------SECOND BID END--------------------------------------------------------------------------------------------------------------------


	//NOT CODED YET
	public override void DoIParticiapteInQuest ();



















}
	
public class strats1:AbstractAI{
//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//------------------------------------------------------------DISCARD AFTER WINNING TEST--------------------------------------------------------------------------------------------------------------------------------------------------------------------

	public override List<GameObject> discardAfterWinningTest (List<GameObject> Hand){
		List<GameObject> CardsForBid=null;
		foreach (GameObject i in Hand) {
			if (i.GetComponent<AdventureCard> ().getBattlePoints > 20 && i.GetComponent<AdventureCard> ().getType () == "Foe") {
				CardsForBid.Add (i);
			}
		}
		return CardsForBid;
	}
	//------------------------------------------------------------DISCARD AFTER WINNNING TEST END------------------------------------------------------------------------------------------------------------------------------------------------
	//------------------------------------------------------------NEXTBID--------------------------------------------------------------------------------------------------------------------------------------------------------------------

	public override int nextBid(List<GameObject> Hand,int currentbid){
		List<GameObject> temp = discardAfterWinningTest (Hand);
		if(currentbid<temp.Count){
			return temp.Count;
		}
	}

	//-------------------------------------------------------------NEXT BID END-------------------------------------------------------------------------------------------------------------------------------------------------------------------
	//------------------------------------------------------------  			-------------------------------------------------------------------------------------------------------------------------------------------------------------------

	//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	//------------------------------------------------------------				--------------------------------------------------------------------------------------------------------------------------------------------------------------------

	//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	//------------------------------------------------------------						--------------------------------------------------------------------------------------------------------------------------------------------------------------------

	//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	//------------------------------------------------------------						--------------------------------------------------------------------------------------------------------------------------------------------------------------------

	//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	//------------------------------------------------------------						-------------------------------------------------------------------------------------------------------------------------------------------------------------------

	//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	//------------------------------------------------------------						--------------------------------------------------------------------------------------------------------------------------------------------------------------------






}