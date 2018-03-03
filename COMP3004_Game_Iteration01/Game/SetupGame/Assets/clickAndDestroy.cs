using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class clickAndDestroy : MonoBehaviour, IPointerClickHandler{
	GameManager gm;
	void Start(){
		gm = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	public void OnPointerClick(PointerEventData eventData){
		Debug.Log (this.GetComponent<Image> ().sprite.name);

		List<GameObject> users = gm.getAllUsers();
		foreach(GameObject g in users){
			foreach(AdventureCard a in g.GetComponent<User>().getAllies()){
				if(a.getName() == this.GetComponent<Image> ().sprite.name){
					Debug.Log ("Removing the ally: "+this.GetComponent<Image> ().sprite.name);
					g.GetComponent<User> ().removeAlly (a.getName ());
					Destroy (this.transform.parent);
				}

			}

		}

	}
}
