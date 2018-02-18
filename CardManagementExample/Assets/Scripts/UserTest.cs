using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Users newUsers = new Users (4);
		foreach (GameObject i in newUsers.getUsers()) {
			Debug.Log ("Name: " + i.GetComponent<User>().getName () + " and battle point: " + i.GetComponent<User>().getbaseAttack ());
		}
		//Debug.Log(newUsers.findByUserName ("Player0").GetComponent<User>().getbaseAttack());
		//Debug.Log(newUsers.findByUserName ("Player2").GetComponent<User>().getbaseAttack());
		newUsers.findByUserName ("Player2").GetComponent<User>().setBaseAttack(20);
		newUsers.findByUserName ("Player3").GetComponent<User>().setBaseAttack(10);
		foreach (GameObject i in newUsers.getUsers()) {
			Debug.Log ("Name: " + i.GetComponent<User>().getName () + " and battle point: " + i.GetComponent<User>().getbaseAttack ());
		}

		newUsers.getHighestRankUser ();
		/*foreach (GameObject i in newUsers.getHighestRankUser()) {
			Debug.Log ("Name: " + i.GetComponent<User>().getName ());
		}*/

		//Debug.Log (newUsers.getHighestRankUser());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
