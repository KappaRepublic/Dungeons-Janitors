using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* SCR_PlayerInteraction
* ==========
* 
* Created: 5/10/17
* Author(s): Sebastian Poskitt-Marshall
*
* Purpose: If a player is able to interact with an object, the check
* will be performed here, for example, lighting a torch. If the object
* itself is triggered by coming into contact with the player, the
* response it done in the script correlating to that object, for example,
* a pressure plate.
*/

public class SCR_PlayerInteraction : MonoBehaviour {

	public Animator pAnimator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag != "Player") {
			
			// Show that object has been found to debug information
			Debug.Log ("Found something");

			// Check for player input as long as a valid target is available
			if (Input.GetKeyDown (KeyCode.I)) {
				if (col.gameObject.tag == "Chest") {
					col.gameObject.GetComponent<SCR_Chest> ().refillChest ();
				}
				if (col.gameObject.tag == "Lever") {
					Debug.Log ("Spike Lever");
					col.gameObject.GetComponent<SCR_SpikeLever> ().activate ();
				}
				if (col.gameObject.tag == "Torch") {
					Debug.Log ("Torch");
					col.gameObject.GetComponent<SCR_Torch> ().lightTorch ();
					// Play the animation
					pAnimator.Play ("ANIM_PlayerTorchLight_Left");
				}
				if (col.gameObject.tag == "Corpse") {
					Debug.Log ("Corspe");
					Destroy (col.gameObject);
				}
				if (col.gameObject.tag == "TrapDoor") {
					Debug.Log ("Trap Door");
					col.gameObject.GetComponent<SCR_TrapDoor> ().reset ();
				}

			}
		}
	}
}
