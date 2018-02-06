using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	protected static readonly string[] WEAPON_NAME = {"Horse(Clone)", "Sword(Clone)", "Dagger(Clone)", "Excalibur(Clone)", "Lance(Clone)", "Battle-ax(Clone)"};
	protected int battlePoints;
	public Weapon(string name){



	}

	public void Start(){
		GameObject playern = transform.parent.parent.gameObject;

		PlayerManager player = playern.GetComponent<PlayerManager> ();
		string name = this.name;
		if (name.Equals (WEAPON_NAME [0])) {
			player.setBattlePoints (10);
			this.battlePoints = 10;
		} else if (name.Equals (WEAPON_NAME [1])) {
			player.setBattlePoints (10);
			this.battlePoints = 10;
		} else if (name == (WEAPON_NAME [2])) {
			player.setBattlePoints (5);

			this.battlePoints = 5;
		} else if (name.Equals (WEAPON_NAME [3])) {
			player.setBattlePoints (30);

			this.battlePoints = 30;
		} else if (name.Equals (WEAPON_NAME [4])) {
			player.setBattlePoints (20);

			this.battlePoints = 20;
		} else if (name.Equals (WEAPON_NAME [5])) {
			player.setBattlePoints (15);

			this.battlePoints = 15;
		}
	}

	public string getName(){
		return this.name;
	}

	public int getBattlePoints(){
		return this.battlePoints;
	}

}
