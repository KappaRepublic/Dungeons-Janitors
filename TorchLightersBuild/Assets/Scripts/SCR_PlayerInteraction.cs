using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

/*
* SCR_PlayerInteraction
* ==========
* 
* Created: 5/10/17
* Author(s): Sebastian Poskitt-Marshall, Rory McLean
*
* Purpose: If a player is able to interact with an object, the check
* will be performed here, for example, lighting a torch. If the object
* itself is triggered by coming into contact with the player, the
* response it done in the script correlating to that object, for example,
* a pressure plate.
*/

public class SCR_PlayerInteraction : MonoBehaviour {

	public Animator pAnimator;
	public bool player2 = false;

	bool buttonDown = false;
	public List<GameObject> collidingObjects;

	GamePadState state;
	GamePadState prevState;

	GamePadState player2State;
	GamePadState player2prevState;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		// Update the game controller
		prevState = state;
		state = GamePad.GetState (PlayerIndex.One);

		player2prevState = player2State;
		player2State = GamePad.GetState (PlayerIndex.Two);

		if (!player2) {
			// Check for player input as long as a valid target is available
			if (Input.GetKeyDown (KeyCode.Return) || (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed)) {

				for (int i = 0; i < collidingObjects.Count; i++) {
					if (collidingObjects [i] != null) {
						if (collidingObjects [i].tag == "Chest") {
							collidingObjects [i].GetComponent<SCR_Chest> ().refillChest ();
							AkSoundEngine.PostEvent ("Chest_Refill", gameObject);

						}
						if (collidingObjects [i].tag == "Lever") {
							Debug.Log ("Spike Lever");
							collidingObjects [i].GetComponent<SCR_SpikeLever> ().activate ();
							AkSoundEngine.PostEvent ("Pull_Lever", gameObject);

						}
						if (collidingObjects [i].tag == "Torch") {
							Debug.Log ("Torch");
							collidingObjects [i].GetComponent<SCR_Torch> ().lightTorch ();
							AkSoundEngine.PostEvent ("Swing_Torch", gameObject);

							GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<SCR_Player> ().lightingTorch = true;
							StartCoroutine (lightTorch ());
						}
						if (collidingObjects [i].tag == "Corpse") {
							Debug.Log ("Corspe");
							Destroy (collidingObjects [i]);
							AkSoundEngine.PostEvent ("Cleanup_Corpse", gameObject);

						}
						if (collidingObjects [i].gameObject.tag == "TrapDoor") {
							Debug.Log ("Trap Door");
							collidingObjects [i].GetComponent<SCR_TrapDoor> ().reset ();
							AkSoundEngine.PostEvent ("Set_Trapdoor", gameObject);


						}
						if (collidingObjects [i].gameObject.tag == "WallTrap") {
							Debug.Log ("Wall Trap");
							collidingObjects [i].GetComponent<SCR_WallTrap> ().resetTrap ();
							AkSoundEngine.PostEvent ("Arrow_Reload", gameObject);

						}
						if (collidingObjects [i].gameObject.tag == "GateCollider") {
							Debug.Log ("Gate");
							if (!collidingObjects [i].GetComponent<SCR_Gate> ().gateIsOpened) {
								collidingObjects [i].GetComponent<SCR_Gate> ().activateGate ();


							}
						}
					}
				}
			}
		} else {
			// Check for player input as long as a valid target is available
			if (Input.GetKeyDown (KeyCode.Delete) || (player2prevState.Buttons.A == ButtonState.Released && player2State.Buttons.A == ButtonState.Pressed)) {

				for (int i = 0; i < collidingObjects.Count; i++) {
					if (collidingObjects [i] != null) {
						if (collidingObjects [i].tag == "Chest") {
							collidingObjects [i].GetComponent<SCR_Chest> ().refillChest ();
							AkSoundEngine.PostEvent ("Chest_Refill", gameObject);

						}
						if (collidingObjects [i].tag == "Lever") {
							Debug.Log ("Spike Lever");
							collidingObjects [i].GetComponent<SCR_SpikeLever> ().activate ();
							AkSoundEngine.PostEvent ("Pull_Lever", gameObject);

						}
						if (collidingObjects [i].tag == "Torch") {
							Debug.Log ("Torch");
							collidingObjects [i].GetComponent<SCR_Torch> ().lightTorch ();
							AkSoundEngine.PostEvent ("Swing_Torch", gameObject);

							GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<SCR_Player> ().lightingTorch = true;
							StartCoroutine (lightTorch ());
						}
						if (collidingObjects [i].tag == "Corpse") {
							Debug.Log ("Corspe");
							Destroy (collidingObjects [i]);
							AkSoundEngine.PostEvent ("Cleanup_Corpse", gameObject);

						}
						if (collidingObjects [i].gameObject.tag == "TrapDoor") {
							Debug.Log ("Trap Door");
							collidingObjects [i].GetComponent<SCR_TrapDoor> ().reset ();
							AkSoundEngine.PostEvent ("Set_Trapdoor", gameObject);


						}
						if (collidingObjects [i].gameObject.tag == "WallTrap") {
							Debug.Log ("Wall Trap");
							collidingObjects [i].GetComponent<SCR_WallTrap> ().resetTrap ();
							AkSoundEngine.PostEvent ("Arrow_Reload", gameObject);

						}
						if (collidingObjects [i].gameObject.tag == "GateCollider") {
							Debug.Log ("Gate");
							if (!collidingObjects [i].GetComponent<SCR_Gate> ().gateIsOpened) {
								collidingObjects [i].GetComponent<SCR_Gate> ().activateGate ();


							}
						}
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
			//Debug.Log("Object Found");

			collidingObjects.Add (col.gameObject);

			// collidingObject = col.gameObject;

		}
	}

	IEnumerator lightTorch() {
		yield return new WaitForSeconds (0.65f);
		GameObject.FindGameObjectWithTag ("Player").gameObject.GetComponent<SCR_Player> ().lightingTorch = false;
	}
}
