using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Foe", menuName = "Cards/Foe")]
public class AllyScriptObj : ScriptableObject {


	public new string name;
	public Sprite image;

	public int bidPoints;
	public int bonusBidPoints;
	public int battlePoints;
	public int bonusBattlePoints;

	public bool merlin;

}

