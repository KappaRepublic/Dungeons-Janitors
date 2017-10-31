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

	bool buttonDown = false;
	public List<GameObject> collidingObjects;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// Check for player input as long as a valid target is available
		if (Input.GetKeyDown (KeyCode.I)) {

			Debug.Log ("I Pressed");

			for (int i = 0; i < collidingObjects.Count; i++) {
				if (collidingObjects[i] != null) {
					if (collidingObjects[i].tag == "Chest") {
						collidingObjects[i].GetComponent<SCR_Chest> ().refillChest ();
					}
					if (collidingObjects[i].tag == "Lever") {
						Debug.Log ("Spike Lever");
						collidingObjects[i].GetComponent<SCR_SpikeLever> ().activate ();
					}
					if (collidingObjects[i].tag == "Torch") {
						Debug.Log ("Torch");
						collidingObjects[i].GetComponent<SCR_Torch> ().lightTorch ();
						// Play the animation
						pAnimator.Play ("ANIM_PlayerTorchLight_Left");
					}
					if (collidingObjects[i].tag == "Corpse") {
						Debug.Log ("Corspe");
						Destroy (collidingObjects[i]);
					}
					if (collidingObjects[i].gameObject.tag == "TrapDoor") {
						Debug.Log ("Trap Door");
						collidingObjects[i].GetComponent<SCR_TrapDoor> ().reset ();
					}
					if (collidingObjects [i].gameObject.tag == "GateCollider") {
						Debug.Log ("Gate");
						collidingObjects [i].GetComponent<SCR_Gate> ().gateInteraction ();
					}
					if (collidingObjects [i].gameObject.tag == "WallTrap") {
						Debug.Log ("Wall Trap");
						collidingObjects [i].GetComponent<SCR_WallTrap> ().resetTrap ();
					}
				}
			}
		}


	}

	void FixedUpdate()
	{
		collidingObjects.Clear ();
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag != "Player" & col.gameObject.tag != "Blood") {
			
			// Show that object has been found to debug information
			Debug.Log("Object Found");

			collidingObjects.Add (col.gameObject);

			// collidingObject = col.gameObject;

		}
	}
}
