using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Class Name:
* Player
* ==========
* 
* Created: 05/10/17
* Author(s): Sebastian Poskitt-Marshall
*
* Purpose:
* Controls all actions related to player input, as well as
* creating the correct results for said actions.
*/

public class SCR_Player : MonoBehaviour {

	public float playerSpeed = 4.0f;
	public GameObject playerInteractionArea;
	public Animator pAnimator;
	public float rollCooldown = 1.0f;

	// Use this for initialization
	void Start () {
		pAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		// Update cool downs

		// Process player input
		processInput ();
	}

	// Process input checks for what the player is inputting and calls
	// the functions correlating to each key
	void processInput(){

		Vector2 velocity = new Vector2(0.0f, 0.0f);

		SpriteRenderer sprRenderer = GetComponent<SpriteRenderer> ();

		if (Input.GetKey (KeyCode.W)) {
			velocity.y += 1.0f;
			playerInteractionArea.transform.rotation = Quaternion.Euler(0, 0, 0);;
		} 
		if (Input.GetKey (KeyCode.S)) {
			velocity.y -= 1.0f;
			playerInteractionArea.transform.rotation = Quaternion.Euler(0, 0, 180);;
		}
		if (Input.GetKey (KeyCode.A)) {
			velocity.x -= 1.0f;
			playerInteractionArea.transform.rotation = Quaternion.Euler(0, 0, 90);;
		}
		if (Input.GetKey (KeyCode.D)) {
			velocity.x += 1.0f;
			playerInteractionArea.transform.rotation = Quaternion.Euler(0, 0, 270);;
		}

		updateMovement (velocity);
	}

	// Updates movement using the passed velocity vector
	void updateMovement(Vector2 vel) {
		Rigidbody2D rigidBody = GetComponent<Rigidbody2D> ();
		// rigidBody.AddForce (new Vector2(vel.x * playerSpeed, vel.y * playerSpeed));
		rigidBody.velocity = vel * playerSpeed;

		// Update the players animations
		updateAnimations(vel);
	}

	void updateAnimations(Vector2 vel) {
		if (vel.x > 0.0f) {
			// Moving right
			if (vel.y < 0.0f) {
				// Moving down
				if (Input.GetKey (KeyCode.Space)) {
					// If player is mopping
					pAnimator.Play("ANIM_PlayerMop_DRight");
				} else {
					// If player is not mopping
					pAnimator.Play("ANIM_PlayerRun_DRight");
				}
			} else if (vel.y > 0.0f) {
				// Moving up
				if (Input.GetKey (KeyCode.Space)) {
					// If player is mopping
				} else {
					// If player is not mopping
					pAnimator.Play("ANIM_PlayerRun_URight");
				}
			} else if (vel.y == 0.0f) {
				// Not moving on the y axis
				if (Input.GetKey (KeyCode.Space)) {
					// If player is mopping
				} else {
					// If player is not mopping
					pAnimator.Play("ANIM_PlayerRun_Right");
				}
			}
		} else if (vel.x < 0.0f) {
			// Moving Left
			if (vel.y < 0.0f) {
				// Moving down
				if (Input.GetKey (KeyCode.Space)) {
					// If player is mopping
					pAnimator.Play("ANIM_PlayerMop_DLeft");
				} else {
					// If player is not mopping
					pAnimator.Play("ANIM_PlayerRun_DLeft");
				}
			} else if (vel.y > 0.0f) {
				// Moving up
				if (Input.GetKey (KeyCode.Space)) {
					// If player is mopping
				} else {
					// If player is not mopping
					pAnimator.Play("ANIM_PlayerRun_ULeft");
				}
			} else if (vel.y == 0.0f) {
				// Not moving on the y axis
				if (Input.GetKey (KeyCode.Space)) {
					// If player is mopping
					pAnimator.Play("ANIM_PlayerMop_Left");
				} else {
					// If player is not mopping
					pAnimator.Play("ANIM_PlayerRun_Left");
				}
			}
		} else if (vel.x == 0.0f) {
			// Not moving on the x axis
			if (vel.y < 0.0f) {
				// Moving down
				if (Input.GetKey (KeyCode.Space)) {
					// If player is mopping
					pAnimator.Play("ANIM_PlayerMop_DLeft");
				} else {
					// If player is not mopping
					pAnimator.Play("ANIM_PlayerRun_DLeft");
				}
			} else if (vel.y > 0.0f) {
				// Moving up
				if (Input.GetKey (KeyCode.Space)) {
					// If player is mopping
				} else {
					// If player is not mopping
					pAnimator.Play("ANIM_PlayerRun_ULeft");
				}
			} else if (vel.y == 0.0f) {
				// Not moving on the y axis
				if (Input.GetKey (KeyCode.Space)) {
					// If player is mopping
					pAnimator.Play("ANIM_PlayerMop_DLeft");
				} else {
					// If player is not mopping
					pAnimator.Play("ANIM_PlayerRun_DLeft");
				}
			}
		}
	}
}
