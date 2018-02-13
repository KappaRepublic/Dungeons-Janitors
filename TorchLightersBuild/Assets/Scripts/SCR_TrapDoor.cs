using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Class Name:
* SCR_TrapDoor
* ==========
* 
* Created: 24/10/17
* Author(s): Sebastian Poskitt-Marshall, Rory McLean
*
* Purpose:
* Pit fall / Trap door trap functionality
*/

public class SCR_TrapDoor : MonoBehaviour {

	// Sprites for open and closed form
	// Element 0 is open, Element 1 is closed
	public Sprite[] graphics;

	// Has the trap been reset
	public bool trapReset = false;

	// Function for resetting the trap
	public void reset() {
		// Set the trap to reset
		trapReset = true;
		// Set the graphic to the closed door
		GetComponent<SpriteRenderer> ().sprite = graphics [1];
		// Set the collider to be a trigger
		GetComponent<BoxCollider2D>().isTrigger = true;
	}

	// Check for collisions after being reset
	void OnTriggerStay2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			if (!col.gameObject.GetComponent<SCR_Player> ().dodging) {
				Debug.Log ("TRAP SENDS PLAYER BACK TO CHECK POINT");
				// DO PLAYER RESET HERE
				col.GetComponent<SCR_Player> ().kill (this.gameObject);
                AkSoundEngine.PostEvent("Pit_Death", gameObject);

                // Set the trap back to activated
                trapReset = false;
				// Set the graphic to the open door
				GetComponent<SpriteRenderer> ().sprite = graphics [0];
				// Set the collider to no longer be a trigger
				GetComponent<BoxCollider2D> ().isTrigger = false;
			}
		}
	}
}
