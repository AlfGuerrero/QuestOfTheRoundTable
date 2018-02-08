using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Users : MonoBehaviour {
	protected int numberOfUsers;
	List<User> users = new List<User>();

	public Users(int numberOfUsers, string user_name){
		this.numberOfUsers = numberOfUsers;
		for (int i = 0; i < numberOfUsers; i++) {
			users.Add (new User (user_name));
		}
	}

	public User findByUserName(string user_name){
		User result;
		result = users.Find (x => x.getName () == user_name);
		return result;
	}
	public void addUser(string user_name){
		users.Add (new User (user_name));
		numberOfUsers++;
	}

	public void removeUser(string user_name){
		User result;
		result = users.Find (x => x.getName () == user_name);
		users.Remove (result);
		numberOfUsers--;
	}
	public int getNumberOfUsers(){
		return numberOfUsers;
	}
}
