using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandManager : MonoBehaviour {

	HorizontalLayoutGroup layout;

	GameObject [] cardsInHand;

	// Use this for initialization
	void Start () {
		layout = this.GetComponent<HorizontalLayoutGroup> ();
	}
	
	// Update is called once per frame
	void Update () {
		SetCardsInList ();
		CardDistribution ();

	}

	void DrawCard(){

	}

	void CardDistribution(){

		int handSize = this.transform.childCount;


		if (handSize <= 7) {
			layout.spacing = -90;
			//1;
			//boxCollider.offset = new Vector2(1f,boxCollider.offset.y);
			//ResizeCardColliders(f);
		} else if (handSize <= 12) {
			layout.spacing = -34;
			//-15;
			//boxCollider.offset = new Vector2(-15f,boxCollider.offset.y);
			ResizeCardColliders(1f);
		} else {
			layout.spacing = -28;
			//-26
			//boxCollider.offset = new Vector2(-26f,boxCollider.offset.y);
			ResizeCardColliders(2f);
		}

	}

	void SetCardsInList(){
		cardsInHand = GameObject.FindGameObjectsWithTag ("Card");
	}

	void ResizeCardColliders(float offsetX){
		foreach(GameObject card in cardsInHand){
			BoxCollider2D col = card.GetComponent<BoxCollider2D> ();
			col.offset = new Vector2 (offsetX, col.offset.y);
		}
	}
}
