using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
	protected static readonly string[] TEST_NAME = {"Test of the Questing Beast", "Test of the Temptation", "Test of the Valor", "Test of the Morgen Le Fey"};
	protected string name;
	protected int bidRequirements;
	protected int bonusBidRequirements;
	public Test(string name){
		this.name = name;
		if (name.Equals (TEST_NAME [0])) {
			this.bonusBidRequirements = 4;
		}else if (name.Equals (TEST_NAME [3])) {
			this.bidRequirements = 3;
		}
	}

	public string getName(){
		return this.name;
	}
	public int getbidRequirements(){
		return this.bidRequirements;
	}
	public int getbonusBidRequirements(){
		return this.bonusBidRequirements;
	}
}
