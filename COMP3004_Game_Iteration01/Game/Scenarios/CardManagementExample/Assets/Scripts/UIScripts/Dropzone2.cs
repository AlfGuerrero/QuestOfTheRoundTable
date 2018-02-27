using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone2 : MonoBehaviour, IDropHandler  {

	public void OnDrop(PointerEventData eventData){
		User player = GameObject.Find ("Hand").transform.parent.GetComponent<User> ();
		AdventureCard z = eventData.pointerDrag.GetComponent<AdventureCard> ();
		if(z.getType() == "Ally"){
			player.setBaseAttack (player.getbaseAttack() + z.getBattlePoints ());
			//player.setBids(player.getBaseBids() + z.getBids)
//			Debug.Log(");
			//player.addAlly(z);
			z.gameObject.SetActive(false);


			Destroy(z.gameObject);
		}
	}

}
