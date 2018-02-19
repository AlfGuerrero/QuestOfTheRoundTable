using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour {

	protected new string name;
	protected string bonusFoe;
	protected int stages;
	protected string type;

	protected QuestScriptObj quest;
	protected string card;
	// Use this for initialization
	void Start () {
		quest = Resources.Load<QuestScriptObj> ("Quest/"+card);
		name = quest.name;
		type = "quest";
		GetComponent<SpriteRenderer> ().sprite = quest.image;
		stages = quest.stages;
		bonusFoe = quest.bonusFoe;
	}
	public string getName(){
		return this.name;
	}
	public string getType(){
		return this.type;
	}
	public int getStages(){
		return this.stages;
	}
	public string getBonusFoe(){
		return this.bonusFoe;
	}
	public void setCard (string cardName){
		card = cardName;
	}
}
