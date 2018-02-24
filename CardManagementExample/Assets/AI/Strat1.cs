using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strat1 : MonoBehaviour {
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	//-----------------------------------NEXT BID ---------------------------------------------------------------------------------------------------------------------------------------

	public int nextBid(List<GameObject> Hand,int currentbid){
		List<GameObject> temp = discardAfterWinningTest (Hand);
		if(currentbid<temp.Count){
			return temp.Count;
		}
	}//End of the NEXTBId
	//--------------------------------NEXT BID END------------------------------------------------------------------------------------------------------------------------------------------
	//--------------------------------DISCARD AFTER WINNING TEST----------------------------------------------------------------------------------------------------------------------------------
	public List<GameObject> discardAfterWinningTest (List<GameObject> Hand){
		List<GameObject> CardsForBid=null;
		foreach (GameObject i in Hand) {
			if (i.GetComponent<AdventureCard> ().getBattlePoints > 20 && i.GetComponent<AdventureCard> ().getType () == "Foe") {
				CardsForBid.Add (i);
			}
		}
		return CardsForBid;
	}
	//-----------------------------------DISCARD AFTER WINNING TEST END---------------------------------------------------------------------------------------------------------------------------------------
	//------------------------------------DO I SPONSOR QUEST------------------------------------------------------------------------------------------------------------------------------------
	public List<List<GameObject>> DoISponsorAQuest (QuestScriptObj CurrentQuest, List<User> Players, List<GameObject>AIHand)
	{
		bool DoISponsor = true, Test = false;
		GameObject TestCard;
		List<GameObject> CheckAmount;
		int neededFoes = CurrentQuest.stages;
		List<GameObject> Foes = ListOfFoes (AIHand);
		List<GameObject> Weapons = ListOfWeapons (AIHand);
		List<GameObject> Stages;
	//Checking to see if any player can win
		foreach (User Player in Players) {
			if (Player.getShields () + CurrentQuest.stages >= 10 && Player.getRank == "Champion Knight") {
				DoISponsor = false;
				break;
			}
		}
	//Checking to see if to sponsor or not based on if another player can win or not
		if (DoISponsor == true) {
			foreach (GameObject IsTest in AIHand) {
				if (IsTest.GetComponent<AdventureCard> ().getType () == "Test") {
					Test = true;
					TestCard = IsTest;
					neededFoes -= 1;
					break;
				}
			}
			//removing duplicatae foes
			foreach (GameObject i in Foes) {
				if (!CheckAmount.Contains (i)) {
					CheckAmount.Add (i);
					RemoveDups (i, Foes);
					Foes.Remove (i);
				}
			}
				//Checking to see if there are enough different foes to use for the quest.
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
		return	SETUP1 (CurrentQuest,Stages,Weapons,TestCard);
		}
	}



	//------------------------------------DO I SPONSOR QUEST END-----------------------------------------------------------------------------------------------------------------------
	//------------------------------------SETUP1--------------------------------------------------------------------------------------------------------------------------------------
	public List<List<GameObject>> SETUP1 (Quest CurrentQuest,List<GameObject> Stages,List<GameObject> Weapons,GameObject TestCard){
		List<GameObject> stage1, stage2, stage3, stage4, stage5;
		List<List <GameObject>> Finalorder = { stage1, stage2, stage3, stage4, stage5 };
		List<GameObject> twoOrMore= null;
		int LastStage = HighestCard (Stages).GetComponent<AdventureCard> ().getBattlePoints ();



		for (int counter = CurrentQuest.stages; counter <= 0; counter--) {
			if (counter == CurrentQuest.stages) {
				//	int LastStage = HighestCard (Stages).GetComponent<AdventureCard> ().getBattlePoints ();
				Finalorder [0] [0] = HighestCard (Stages);
			
				int cardcount = 0;
				while (LastStage <= 50) {
					GameObject temp = HighestCard (Weapons);
					cardcount++;
					Finalorder [0] [cardcount] = temp;
					LastStage += temp.GetComponent<AdventureCard> ().getBattlePoints ();
					RemoveDups (temp, Weapons);
					Weapons.Remove (temp);
				}

			} else if (Test == true && counter == (CurrentQuest.stages) - 2) {
				Finalorder [counter - 2] = TestCard;
			} 



			else {//These are the rest of the cards not taking into account the other two if statemenets
				Dictionary<List<GameObject>,int> HowManyCards=null;
				foreach(GameObject i in Weapons){
					if (HowManyCards.ContainsKey (i)) {
						int temp = HowManyCards.TryGetValue (i);
						HowManyCards.Remove (i);
						HowManyCards.Add (i, temp + 1);
					}
				}
				if(counter==1){
					foreach (GameObject key in HowManyCards.Keys) {
						if (HowManyCards.TryGetValue >= 2) {
							twoOrMore.Add (key);
						}
					}
				}

				GameObject temp2 = HighestCard (twoorMore);//next highest card in the list of cards that are useable.
				Finalorder [counter] [0] = temp2;
				twoOrMore.Remove (temp2);

			
			
			
			}
		//start the ordering of the setup.
			return Finalorder;
		}
	}
		 



	//-------------------------------------SETUP1 END--------------------------------------------------------------------------------------------------------------------------------
	//--------------------------------------DO I PARTICIPATE N A TOURNAMENT--------------------------------------------------------------------------------------------------------------------------

	public List<GameObject> DoIParticipateInTournament(List<GameObject> Cards,List<User> players,int ShieldAmount){
		bool CanSomeoneWin = false;
		List<GameObject> CardsToPlay = null;
		foreach(User i in players){
			if((ShieldAmount+i.getShields>=5 &&i.getRank=="Squire")
				||(ShieldAmount+i.getShields>=7 &&i.getRank=="Knight")
				||(ShieldAmount+i.getShields>=10 &&i.getRank=="Champion Knight")
			){
				CanSomeoneWin = true;break;
				}
			}
		if (CanSomeoneWin == true) {
			foreach(GameObject k in Cards){
				if(!(CardsToPlay.Contains(k)&&k.GetType==("Weapon"||"Ally"))){
					CardsToPlay.Add (k);
			}
		}//end of the foreach loop
	
	
		}return CardsToPlay;





	//-------------------------------------DO I PARTICIAPTE IN A TOURNAMENT END------------------------------------------------------------------------------------------------------------------------------------
	//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------


	//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------




}
