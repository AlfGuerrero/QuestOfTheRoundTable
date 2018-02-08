using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandDropzone : MonoBehaviour, IDropHandler {

	public void OnDrop(PointerEventData eventData){
		Draggable z = eventData.pointerDrag.GetComponent<Draggable> ();
		z.parentToReturnTo = this.transform;
	}

	public void OnPointerEnter(PointerEventData eventData){

	}
	public void OnPointerExit(PointerEventData eventData){

	}
}