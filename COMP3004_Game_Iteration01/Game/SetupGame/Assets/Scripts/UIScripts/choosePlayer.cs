using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choosePlayer : MonoBehaviour {
	GameManager gm;
	void Start(){
	gm = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
    //ask what player

    public void onClickerino(int player){

		Destroy(GameObject.Find("playerScreen(Clone)").gameObject);

        
        List<GameObject> users = gm.getAllUsers();
        List<GameObject> userHand = users[player-1].GetComponent<User>().getCards();


        foreach (GameObject g in userHand)
        {
            //check for mordred
            if (g.GetComponent<AdventureCard>().getName() == "Mordred")
            {
                //show available allies to kill
                Instantiate(Resources.Load("PreFabs/allyKillScreen") as GameObject);
				break;
            }
        }
    }

}