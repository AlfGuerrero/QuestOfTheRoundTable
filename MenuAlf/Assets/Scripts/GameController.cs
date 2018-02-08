using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	int Players_turn = 0; 
	int Players_amount = 3;

	HorizontalLayoutGroup layout;

	public GameObject Card;

	public List<GameObject> createdObjects = new List<GameObject>();

	// use map.
	// Use this for initialization
	void Start () {
		layout = this.GetComponent<HorizontalLayoutGroup> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		//Event to cycle through players. 
		if (Input.GetKeyDown ("space"))
		{
			print ("Player: " + Players_turn % Players_amount + " turn.");
			Players_turn += 1;

			GameObject go = (GameObject)Instantiate(Card, new Vector2(0.0f, 0.0f), Quaternion.identity);
			go.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform);
			createdObjects.Add(go);

		}
	}
}
