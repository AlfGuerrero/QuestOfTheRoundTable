using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
	//protected static readonly string[] TEST_NAME = {"Test of the Questing Beast", "Test of the Temptation", "Test of the Valor", "Test of the Morgen Le Fey"};

	protected new string name;
	protected int bidRequirements;
	protected int bonusBidRequirements;
	protected string type;
	public TestScriptObj test;

	void Start(){
		test = Resources.Load<TestScriptObj> ("Cards/Test Of Valor");
		name = test.name;
		type = "test";
		bidRequirements = test.bidRequirements;

		GetComponent<SpriteRenderer> ().sprite = test.image;
	}

	public string getName(){
		return this.name;
	}
	public string getType(){
		return this.type;
	}
	public int getbidRequirements(){
		return this.bidRequirements;
	}
	public int getbonusBidRequirements(){
		return this.bonusBidRequirements;
	}
}
