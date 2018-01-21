using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandManager : MonoBehaviour {

	int handSize;
	HorizontalLayoutGroup layout;

	// Use this for initialization
	void Start () {
		layout = this.GetComponent<HorizontalLayoutGroup> ();
	}
	
	// Update is called once per frame
	void Update () {
		CardDistribution ();
	}

	void DrawCard(){

	}

	void CardDistribution(){

		handSize = this.transform.childCount;

		if (handSize <= 7) {
			layout.spacing = 0;
		} else {
			layout.spacing = -41;
		}

	}
}
