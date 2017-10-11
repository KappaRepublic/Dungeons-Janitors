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
	public Sprite[] directions;
	public float rollCooldown = 1.0f;

	// Use this for initialization
	void Start () {
		
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
			sprRenderer.sprite = directions [0];
			velocity.y += 1.0f;
			playerInteractionArea.transform.rotation = Quaternion.Euler(0, 0, 0);;
		} 
		if (Input.GetKey (KeyCode.S)) {
			sprRenderer.sprite = directions [2];
			velocity.y -= 1.0f;
			playerInteractionArea.transform.rotation = Quaternion.Euler(0, 0, 180);;
		}
		if (Input.GetKey (KeyCode.A)) {
			sprRenderer.sprite = directions [3];
			velocity.x -= 1.0f;
			playerInteractionArea.transform.rotation = Quaternion.Euler(0, 0, 90);;
		}
		if (Input.GetKey (KeyCode.D)) {
			sprRenderer.sprite = directions [1];
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
	}
}
