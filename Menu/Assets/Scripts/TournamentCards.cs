using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class TournamentCards : MonoBehaviour {
	protected static readonly string[] TOURNAMENT_NAME={"CAMELOT","ORKNEY","TINTAGEL","YORK"};
	protected int BonousShield;
	// Use this for initialization
	public void Start () {
		GameObject playern = transform.parent.parent.gameObject;

		PlayerManager player = playern.GetComponent<PlayerManager> ();
		string name = this.name;

		if (name.Equals (TOURNAMENT_NAME [0])) {
			BonousShield = 3;
		} else if (name.Equals (TOURNAMENT_NAME [1])) {
			BonousShield=2;
		} else if (name.Equals (TOURNAMENT_NAME [2])) {
			BonousShield=1;
		} else if (name.Equals (TOURNAMENT_NAME [3])) {
			BonousShield=0;
		}



	}
	
	// Update is called once per frame

}
