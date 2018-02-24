using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AssemblyCSharp
{
	public interface AiInterface
	{
		Dictionary<bool,GameObject> DoIParticipateInTournament(List<GameObject> Cards);
		 GameObject HighestCard (List<GameObject> CurrentCards);
		List<GameObject> discardAfterWinningTest (int roundWon, List<GameObject> Foes, List<GameObject> weapons);
		int nextBid (int currentbid, int RoundNumber, List<GameObject> Foes, List<GameObject> weapons);
		List<GameObject> FirstBid (List<GameObject>Foes);
		List<GameObject> SecondBid (List<GameObject>weapons);
		List<List<GameObject>> DoISponsorAQuest (QuestScriptObj CurrentQuest, List<User> Players, List<GameObject>AIHand);
		void DoIParticiapteInQuest ();
		void play2();
		void TooManyCards (int DiscardAmmount, List<GameObject> CardsInHand);
		List<GameObject> ListOfFoes (List<GameObject> AIHand);
		List<GameObject> ListOfWeapons (List<GameObject>AIHand);
		List<GameObject> RemoveDups (GameObject Value, List<GameObject> Hand);
	}
}

