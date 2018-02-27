using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserTest : MonoBehaviour {
	Users newUsers;
	// Use this for initialization
	void Start () {
		newUsers = new Users (1,1);
		foreach (GameObject i in newUsers.getUsers()) {
			Debug.Log ("Name: " + i.GetComponent<User>().getName () + " and battle point: " + i.GetComponent<User>().getbaseAttack ());
		}
		Debug.Log(newUsers.findByUserName ("Player0").GetComponent<User>().getName());

		newUsers.findByUserName ("Player0").GetComponent<User> ().getHand ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			foreach (GameObject i in newUsers.findByUserName ("Player0").GetComponent<User> ().getCards ()) {
				
			}
		}
	}
}
