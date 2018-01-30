using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;


public class Card {
	protected static readonly string[] TYPE = {"Adventure", "Story"};
	protected string type; //ex. story or adventure
	protected string name; //ex. horse, sword, quest for camelot

	public Card(){
		this.type = "";
		this.name = "";
	}
	public Card(string type, string name){
		this.type = type;
		this.name = name;
	}
	public string getType(){
		return this.type;
	}
	public string getName(){
		return this.name;
	}
}
