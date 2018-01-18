using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public Vector2 dragOffset = new Vector2(0f, 0f);

	public void OnBeginDrag(PointerEventData eventData)    {
		dragOffset = eventData.position - (Vector2)this.transform.localPosition;
	}

	public void OnDrag(PointerEventData eventData) {
		this.transform.localPosition = eventData.position - dragOffset;
	}

	public void OnEndDrag(PointerEventData eventData) {
		
	}

}
