using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClickDestroy : MonoBehaviour {

	public void clickerino(){
		Destroy (this.transform.parent.gameObject);
	}
}
