using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
* SCR_EndLevelGate
* 
* ==========
* 
* Created: 14/11/2017
* Author(s): Sebastian Poskitt-Marshall
*
* Purpose:
* Functionlity for the end level gate. Will call results screen and return
* player to the level select screen.
* 
*/

public class SCR_EndLevelGate : MonoBehaviour {

	public GameObject gameHud;
	public GameObject player;
	public GameObject levelClearScreen;

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			gameHud.SetActive (false);
			player.SetActive (false);
			levelClearScreen.SetActive (true);
            AkSoundEngine.SetState("Music", "End");

        }
    }
}
