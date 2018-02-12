using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Ally", menuName = "Cards/Ally")]
public class AllyScriptObj : ScriptableObject {


	public new string name;
	public Sprite image;

	public int bidPoints;
	public int bonusBidPoints;
	public int battlePoints;
	public int bonusBattlePoints;

	public bool merlin;

	public AllyScriptObj(string name, 
		int bidPoints, int bonusBidPoints, int battlePoints, 
		int bonusBattlePoints, bool merlin){
		this.name = name;
		this.image = image;
		this.bidPoints = bidPoints;
		this.bonusBidPoints = bonusBidPoints;
		this.battlePoints = battlePoints;
		this.bonusBattlePoints = bonusBattlePoints;
		this.merlin = merlin;
	}

}

