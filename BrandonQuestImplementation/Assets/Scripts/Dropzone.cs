using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler {
	QuestManager q = GameObject.Find("QuestManager");
	//count cards attached as children for cards in play



	public void OnDrop(PointerEventData eventData){
		Draggable z = eventData.pointerDrag.GetComponent<Draggable> ();
		if(z.GetType = "foe"){
			z.parentToReturnTo = this.transform;
		}
	}

	public void OnPointerEnter(PointerEventData eventData){

	}
	public void OnPointerExit(PointerEventData eventData){

	}
}