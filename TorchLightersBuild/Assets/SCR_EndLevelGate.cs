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

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			SceneManager.LoadScene (0);
		}
	}
}
