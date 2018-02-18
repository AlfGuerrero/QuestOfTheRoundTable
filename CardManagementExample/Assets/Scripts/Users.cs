using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Users: MonoBehaviour {
	protected int numberOfUsers;
	GameObject userPrefab = Resources.Load ("PreFabs/player") as GameObject;
	//public GameObject userPrefab;
	List<GameObject> users = new List<GameObject>();
	public Users(int numberOfUsers){
		this.numberOfUsers = numberOfUsers;
		for (int i = 0; i < numberOfUsers; i++) {
			GameObject tempUser = Instantiate(userPrefab) as GameObject;
			tempUser.GetComponent<User> ().Initialize ("Player" + i);
			users.Add (tempUser);
		}
	}

	public GameObject findByUserName(string user_name){
		/*GameObject result;
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		for (int i = 0; i < players.Length; i++) {
			if (players [i].GetComponent<User> ().getName ().Equals (user_name)) {
				return players [i];
			}
		}
		return null;*/
		GameObject result;
		result = users.Find (x => x.GetComponent<User>().getName () == user_name);
		return result;
	}
	public void addUser(string user_name){
		GameObject tempUser = Instantiate(userPrefab) as GameObject;
		tempUser.GetComponent<User> ().Initialize (user_name);
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
		return numberOfUsers;
	}
	public List<GameObject> getUsers(){
		return this.users;
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
	/*public IEnumerator<GameObject> GetEnumerator()
	{
		return users.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return users.GetEnumerator();
	}*/
}
