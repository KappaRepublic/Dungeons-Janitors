using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Class Name:
* SCR_TrapDoor
* ==========
* 
* Created: 24/10/17
* Author(s): Sebastian Poskitt-Marshall
*
* Purpose:
* Pit fall / Trap door trap functionality
*/

public class SCR_TrapDoor : MonoBehaviour {

	// Sprited for open and closed form
	// Element 0 is open, Element 1 is closed
	public Sprite[] graphics;

	// Has the trap been reset
	bool trapReset;

	// Function for resetting the trap
	public void reset() {
		// Set the trap to reset
		trapReset = true;
		AkSoundEngine.PostEvent ("Trapdoor_Close", gameObject);
		// Set the graphic to the closed door
		GetComponent<SpriteRenderer> ().sprite = graphics [1];
		// Set the collider to be a trigger
		GetComponent<BoxCollider2D>().isTrigger = true;
	}

	// Check for collisions after being reset
	void OnTriggerStay2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			Debug.Log ("TRAP SENDS PLAYER BACK TO CHECK POINT");
			// DO PLAYER RESET HERE
			col.GetComponent<SCR_Player>().kill();
			// Set the trap back to activated
			trapReset = false;
			AkSoundEngine.PostEvent ("Trapdoor_Open", gameObject);
			// Set the graphic to the open door
			GetComponent<SpriteRenderer>().sprite = graphics [0];
			// Set the collider to no longer be a trigger
			GetComponent<BoxCollider2D>().isTrigger = false;
		}
	}
}
