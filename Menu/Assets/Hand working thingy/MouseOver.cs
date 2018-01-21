using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour {

	Vector3 startPos;

	public void OnMouseEnter()
	{
		startPos = this.transform.localPosition;
		//this.transform.SetAsLastSibling ();
	}

	public void OnMouseOver()
	{
		this.transform.localScale = new Vector3 (2,2,1);
		this.transform.localPosition = new Vector3 (startPos.x, startPos.y + this.GetComponent<RectTransform>().rect.height / 2, startPos.z);
	}

	public void OnMouseExit()
	{
		this.transform.localScale = new Vector3 (1,1,1);
		this.transform.localPosition = startPos;
	}

}
