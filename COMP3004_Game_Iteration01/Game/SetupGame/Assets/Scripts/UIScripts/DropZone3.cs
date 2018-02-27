using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone3 : MonoBehaviour, IDropHandler  {

	public void OnDrop(PointerEventData eventData){
		Destroy (eventData.pointerDrag.gameObject);
	}

}
