using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone3 : MonoBehaviour, IDropHandler  {

	public void OnDrop(PointerEventData eventData){
		GameObject game_manager = GameObject.FindGameObjectWithTag ("GameController");
		game_manager.GetComponent<GameManager>().advDeck.GetComponent<AdventureDeck>().adventureDeck.Add(eventData.pointerDrag.gameObject.GetComponent<AdventureCard>().getName());
		Destroy (eventData.pointerDrag.gameObject);
	}

}
