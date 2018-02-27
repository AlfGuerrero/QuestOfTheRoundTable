using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Users: MonoBehaviour {
	protected int numberOfUsers;
	GameObject userPrefab = Resources.Load ("PreFabs/player") as GameObject;
	//public GameObject userPrefab;
	List<GameObject> users = new List<GameObject>();
	public Users(int numberOfPlayers, int numberOfAi){
		this.numberOfUsers = numberOfPlayers + numberOfAi;
		for (int i = 0; i < numberOfPlayers; i++) {
			GameObject tempUser = Instantiate(userPrefab) as GameObject;
			tempUser.GetComponent<User> ().Initialize ("Player" + i, false);
			users.Add (tempUser);
		}
		for (int i = 0; i < numberOfAi; i++) {
			GameObject tempUser = Instantiate(userPrefab) as GameObject;
			tempUser.GetComponent<User> ().Initialize ("Player" + i, true);
			users.Add (tempUser);
		}
	}
		
	public GameObject findByUserName(string user_name){
		GameObject result;
		result = users.Find (x => x.GetComponent<User>().getName () == user_name);
		return result;
	}

	public void addUser(string user_name, bool ai){
		GameObject tempUser = Instantiate(userPrefab) as GameObject;
		tempUser.GetComponent<User> ().Initialize (user_name, ai);
		users.Add (tempUser);
		numberOfUsers++;
	}
		
	public GameObject removeUser(string user_name){
		GameObject result;
		result = users.Find (x => x.GetComponent<User>().getName () == user_name);
		users.Remove (result);
		numberOfUsers--;
		return result;
	}

	public int getNumberOfUsers(){
		return this.numberOfUsers;
	}

	public List<GameObject> getUsers(){
		return this.users;
	}

	public List<GameObject> getHighestRankUser(){
		List<GameObject> result = new List<GameObject>();

		int maxAttack = 0;
		foreach (GameObject i in users) {
			if (i.GetComponent<User>().getShields () > maxAttack) {
				maxAttack = i.GetComponent<User>().getShields ();
				result.Clear ();
				result.Add (i);
				continue;
			}
			if (i.GetComponent<User>().getShields () == maxAttack) {
				result.Add(i);
			}
		}
		foreach (GameObject i in result) {
//			Debug.Log (i.GetComponent<User> ().getName ());
		}
		return result;
	}

	public List<GameObject> getLowestRankUser(){
		List<GameObject> result = new List<GameObject>();

		int lowAttack = 1000;
		foreach (GameObject i in users) {
			if (i.GetComponent<User>().getShields () < lowAttack) {
				lowAttack = i.GetComponent<User>().getShields ();
				result.Clear ();
				result.Add (i);
				continue;
			}
			if (i.GetComponent<User>().getShields () == lowAttack) {
				result.Add(i);
			}
		}
		foreach (GameObject i in result) {
//			Debug.Log (i.GetComponent<User> ().getName ());
		}
		return result;
	}
}
