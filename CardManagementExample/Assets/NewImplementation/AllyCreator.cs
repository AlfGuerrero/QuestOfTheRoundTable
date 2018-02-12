using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyCreator : MonoBehaviour {
	//protected static readonly Sprite[] ALLY_SPRITES = { };
	protected static readonly string[] ADVENTURE_TYPE = {"Foe", "Ally", "Weapon", "Test"};
	protected static readonly string[] ALLY_NAME = {"Sir Gawain", "King Pellinore", "Sir Percival", "Sir Tristan", "King Arthur", "Queen Guinevere", "Merlin", "Queen Iseult", "Sir Lancelot", "Sir Galahad", "Armour"};
	// Use this for initialization
	void Start () {
		for (int i = 0; i < ALLY_NAME.Length; i++) {
			//createAlly (ALLY_NAME[i]);
		}
	}
	/*private void createAlly(string name){
			if (name.Equals (ALLY_NAME [0])) {
				//this.battlePoints = 10;
				//this.bonusBattlePoints = 20;
			AllyScriptObj.CreateInstance();
			new AllyScriptObj (name, 0, 0, 10, 20, false);
			} else if (name.Equals (ALLY_NAME [1])) {
				//this.battlePoints = 10;
				//this.bonusBidPoints = 4;
			AllyScriptObj.CreateInstance();
			new AllyScriptObj (name, 0, 4, 10, 0, false);
			} else if (name.Equals (ALLY_NAME [2])) {
				//this.battlePoints = 5;
				//this.bonusBattlePoints = 20;
			AllyScriptObj.CreateInstance();
			new AllyScriptObj (name, 0, 0, 5, 20, false);
			} else if (name.Equals (ALLY_NAME [3])) {
				//this.battlePoints = 10;
				//this.bonusBattlePoints = 20;
			AllyScriptObj.CreateInstance();
			new AllyScriptObj (name, 0, 0, 10, 20, false);
			} else if (name.Equals (ALLY_NAME [4])) {
				//this.battlePoints = 10;
				//this.bidPoints = 2;
			AllyScriptObj.CreateInstance();
			new AllyScriptObj (name, 2, 0, 10, 0, false);
			}else if (name.Equals (ALLY_NAME [5])) {
				//this.bidPoints = 3;
			AllyScriptObj.CreateInstance();
			new AllyScriptObj (name, 3, 0, 0, 0, false);
			}else if (name.Equals (ALLY_NAME [6])) {
				//this.merlin = true;
			AllyScriptObj.CreateInstance();
			new AllyScriptObj (name, 0, 0, 0, 0, true);
			}else if (name.Equals (ALLY_NAME [7])) {
				//this.bidPoints = 2;
				//this.bonusBidPoints = 4;
			AllyScriptObj.CreateInstance();
			new AllyScriptObj (name, 2, 4, 0, 0, false);
			}else if (name.Equals (ALLY_NAME [8])) {
				//this.bidPoints = 15;
				//this.bonusBattlePoints = 25;
			AllyScriptObj.CreateInstance();
			}else if (name.Equals (ALLY_NAME [9])) {
				//this.bidPoints = 15;
			AllyScriptObj.CreateInstance();
			new AllyScriptObj (name, 0, 0, 10, 20, false);
			}else if (name.Equals (ALLY_NAME [10])) {
				//this.bidPoints = 1;
				//this.battlePoints = 10;
			AllyScriptObj.CreateInstance();
			new AllyScriptObj (name, 0, 0, 10, 20, false);
			}*/
		
	//}
}
