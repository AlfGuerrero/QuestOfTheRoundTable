using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class allykillscreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("Starting Up");
		GameObject allyCardDestroyable = Resources.Load ("PreFabs/allyCardDestroyable") as GameObject;
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        List<AdventureCard> alliesInPlay = new List<AdventureCard>();
        //find all allies in play
        List<GameObject> users = gm.getAllUsers();

        foreach (GameObject g in users)
        {
			Debug.Log("HOOPP1");
            foreach (AdventureCard c in g.GetComponent<User>().getAllies())
            {
				Debug.Log("HOOPP2");
                alliesInPlay.Add(c);
            } 
        }
		int counter = 0;
        //Display them
		foreach(AdventureCard a in alliesInPlay){
			Debug.Log(a.getName());
			GameObject card = Instantiate (allyCardDestroyable, this.gameObject.transform);
			card.gameObject.GetComponent<Image> ().sprite = Resources.Load ("sprites/"+a.getName ()) as Sprite;
			card.transform.position = new Vector2 (counter * 30f, card.transform.position.y);
				counter++;	
		}


    }
	

}
