using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Users: MonoBehaviour {
	protected int numberOfUsers;
	protected int numberOfAIUsers;
	GameObject userPrefab = Resources.Load ("PreFabs/player") as GameObject;
	//public GameObject userPrefab;
	List<GameObject> users = new List<GameObject>();
	List<GameObject> aiUsers = new List<GameObject> ();

	public Users(int numberOfUsers){
		this.numberOfUsers = numberOfUsers;
		for (int i = 0; i < numberOfUsers; i++) {
			GameObject tempUser = Instantiate(userPrefab) as GameObject;
			tempUser.GetComponent<User> ().Initialize ("Player" + i, false);
			users.Add (tempUser);
		}
	}
	public Users(int numberOfAIUsers, bool ai){
		this.numberOfAIUsers = numberOfAIUsers;
		for (int i = 0; i < numberOfAIUsers; i++) {
			GameObject tempAIUser = Instantiate(userPrefab) as GameObject;
			tempAIUser.GetComponent<User> ().Initialize ("PlayerAI" + i, true);
			aiUsers.Add (tempAIUser);
		}
	}


	public GameObject findByUserName(string user_name){
		GameObject result;
		result = users.Find (x => x.GetComponent<User>().getName () == user_name);
		return result;
	}
	public GameObject findByUserAIName(string user_name){
		GameObject result;
		result = aiUsers.Find (x => x.GetComponent<User>().getName () == user_name);
		return result;
	}
	public void addUser(string user_name){
		GameObject tempUser = Instantiate(userPrefab) as GameObject;
		tempUser.GetComponent<User> ().Initialize (user_name, false);
		users.Add (tempUser);
		numberOfUsers++;
	}
	public void addAIUser(string user_name){
		GameObject tempUser = Instantiate(userPrefab) as GameObject;
		tempUser.GetComponent<User> ().Initialize (user_name, true);
		aiUsers.Add (tempUser);
		numberOfAIUsers++;
	}

	public GameObject removeUser(string user_name){
		GameObject result;
		result = users.Find (x => x.GetComponent<User>().getName () == user_name);
		users.Remove (result);
		numberOfUsers--;
		return result;
	}
	public GameObject removeAIUser(string user_name){
		GameObject result;
		result = aiUsers.Find (x => x.GetComponent<User>().getName () == user_name);
		aiUsers.Remove (result);
		numberOfAIUsers--;
		return result;
	}
	public int getNumberOfUsers(){
		return this.numberOfUsers;
	}
	public int getNumberOfAIUsers(){
		return this.numberOfAIUsers;
	}
	public List<GameObject> getUsers(){
		return this.users;
	}
	public List<GameObject> getAIUsers(){
		return this.aiUsers;
	}
	public List<GameObject> getHighestRankUser(){
		List<GameObject> result = new List<GameObject>();

		int maxAttack = 0;
		foreach (GameObject i in users) {
			if (i.GetComponent<User>().getbaseAttack () > maxAttack) {
				maxAttack = i.GetComponent<User>().getbaseAttack ();
				result.Clear ();
				result.Add (i);
				continue;
			}
			if (i.GetComponent<User>().getbaseAttack () == maxAttack) {
				result.Add(i);
			}
		}
		foreach (GameObject i in result) {
			Debug.Log (i.GetComponent<User> ().getName ());
		}
		return result;
	}

	public List<GameObject> getLowestRankUser(){
		List<GameObject> result = new List<GameObject>();

		int lowAttack = 1000;
		foreach (GameObject i in users) {
			if (i.GetComponent<User>().getbaseAttack () < lowAttack) {
				lowAttack = i.GetComponent<User>().getbaseAttack ();
				result.Clear ();
				result.Add (i);
				continue;
			}
			if (i.GetComponent<User>().getbaseAttack () == lowAttack) {
				result.Add(i);
			}
		}
		foreach (GameObject i in result) {
			Debug.Log (i.GetComponent<User> ().getName ());
		}
		return result;
	}
}
