using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pussydestroyer : MonoBehaviour {

	public void clickerino(){
		Destroy (this.transform.parent.gameObject);
	}
}
