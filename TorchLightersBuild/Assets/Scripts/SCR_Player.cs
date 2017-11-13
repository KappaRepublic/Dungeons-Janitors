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
	public float rollCooldown = 0.0f;
	public float maxRollCooldown = 0.32f;
	public float rollCooldownActionTimer = 0.0f;
	public float maxRollCooldownActionTimer = 0.5f;
	public GameObject checkPoint;
	public bool dodging = false;
	public bool canRoll = true;

	public GameObject pCamera;

	bool cameraZoomed = false;
	bool directionLeft = false;
	bool directionUp = false;
	bool staticX = false;
	bool staticY = false;

	public bool lightingTorch;

	AnimatorStateInfo animStateInfo;

	public float footStepTimer = 0.4f;

	public bool player2 = false;

	// Use this for initialization
	void Start () {
		pAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		// Update cool downs
		rollCooldown -= Time.deltaTime;
		rollCooldownActionTimer -= Time.deltaTime;

		if (rollCooldown <= 0.0f) {
			dodging = false;
		}

		if (rollCooldownActionTimer <= 0.0f) {
			canRoll = true;
		}

		animStateInfo = pAnimator.GetCurrentAnimatorStateInfo (0);
	
		// Process player input
		processInput ();
	}

	public void IsMopping()
	{
		AkSoundEngine.PostEvent ("Swing_Mop", gameObject);
	}

	public void IsWalking()
	{
		AkSoundEngine.PostEvent ("Footstep", gameObject);
	}

	public void IsUsingTorch()
	{
		AkSoundEngine.PostEvent ("Swing_Torch", gameObject);
	}

	// Process input checks for what the player is inputting and calls
	// the functions correlating to each key
	void processInput(){

		Vector2 velocity = new Vector2(0.0f, 0.0f);

		if (player2) {
			if (Input.GetKey (KeyCode.UpArrow)) {
				velocity.y += 1.0f;
			} 
			if (Input.GetKey (KeyCode.DownArrow)) {
				velocity.y -= 1.0f;
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				velocity.x -= 1.0f;
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				velocity.x += 1.0f;
			}
		} else {
			if (Input.GetKey (KeyCode.W)) {
				velocity.y += 1.0f;
			} 
			if (Input.GetKey (KeyCode.S)) {
				velocity.y -= 1.0f;
			}
			if (Input.GetKey (KeyCode.A)) {
				velocity.x -= 1.0f;
			}
			if (Input.GetKey (KeyCode.D)) {
				velocity.x += 1.0f;
			}
			if (Input.GetKeyDown (KeyCode.K)) {
				if (canRoll) {
					// Start the animation
					if (directionLeft) {
						if (staticY) {
							pAnimator.Play("ANIM_PlayerDash_Left");
						} else if (directionUp) {
							pAnimator.Play("ANIM_PlayerDash_ULeft");
						} else {
							pAnimator.Play("ANIM_PlayerDash_DLeft");
						}
					} else {
						if (staticY) {
							pAnimator.Play("ANIM_PlayerDash_Right");
						} else if (directionUp) {
							pAnimator.Play("ANIM_PlayerDash_URight");
						} else {
							pAnimator.Play("ANIM_PlayerDash_DRight");
						}
					}




					canRoll = false;
					dodging = true;
					Vector2 dodgeDirection = new Vector2 (velocity.x * 2.0f, velocity.y * 2.0f);
					velocity.x = 0.0f;
					velocity.y = 0.0f;
					rollCooldown = maxRollCooldown;
					rollCooldownActionTimer = maxRollCooldownActionTimer;
					dodgeRoll (dodgeDirection);
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			cameraZoomed = !cameraZoomed;

			if (cameraZoomed) {
				pCamera.GetComponent<Camera> ().orthographicSize = 14.4f;
			} else if (!cameraZoomed) {
				pCamera.GetComponent<Camera> ().orthographicSize = 4.8f;
			}
		}

		if (Input.GetKey (KeyCode.Home)) {
			Application.LoadLevel (0);
		}

		if (!dodging) {
			updateMovement (velocity);
		}
	}

	// Updates movement using the passed velocity vector
	void updateMovement(Vector2 vel) {
		Rigidbody2D rigidBody = GetComponent<Rigidbody2D> ();
		// rigidBody.AddForce (new Vector2(vel.x * playerSpeed, vel.y * playerSpeed));
		rigidBody.velocity = vel * playerSpeed;

		// Update the players animations
		updateState(vel);
	}

	void dodgeRoll(Vector2 dir) {
		Rigidbody2D rigidBody = GetComponent<Rigidbody2D> ();

		rigidBody.velocity = dir * playerSpeed;
	}

	void updateState(Vector2 vel) {
		if (!lightingTorch) {
			if (vel.x > 0.0f) {
				// Moving right
				directionLeft = false;
				staticX = false;
				if (vel.y < 0.0f) {
					// Moving down
					directionUp = false;
					staticY = false;
					if (Input.GetKey (KeyCode.Space)) {
						// If player is mopping
						pAnimator.Play ("ANIM_PlayerMop_DRight");
					} else {
						// If player is not mopping
						pAnimator.Play ("ANIM_PlayerRun_DRight");
					}
				} else if (vel.y > 0.0f) {
					// Moving up
					directionUp = true;
					staticY = false;
					if (Input.GetKey (KeyCode.Space)) {
						// If player is mopping
						pAnimator.Play ("ANIM_PlayerMop_URight");
					} else {
						// If player is not mopping
						pAnimator.Play ("ANIM_PlayerRun_URight");
					}
				} else if (vel.y == 0.0f) {
					// Not moving on the y axis
					staticY = true;
					if (Input.GetKey (KeyCode.Space)) {
						// If player is mopping
						pAnimator.Play ("ANIM_PlayerMop_Right");
					} else {
						// If player is not mopping
						pAnimator.Play ("ANIM_PlayerRun_Right");
					}
				}
			} else if (vel.x < 0.0f) {
				// Moving Left
				staticX = false;
				directionLeft = true;
				if (vel.y < 0.0f) {
					// Moving down
					directionUp = false;
					staticY = false;
					if (Input.GetKey (KeyCode.Space)) {
						// If player is mopping
						pAnimator.Play ("ANIM_PlayerMop_DLeft");
					} else {
						// If player is not mopping
						pAnimator.Play ("ANIM_PlayerRun_DLeft");
					}
				} else if (vel.y > 0.0f) {
					// Moving up
					directionUp = true;
					staticY = false;
					if (Input.GetKey (KeyCode.Space)) {
						// If player is mopping
						pAnimator.Play ("ANIM_PlayerMop_ULeft");
					} else {
						// If player is not mopping
						pAnimator.Play ("ANIM_PlayerRun_ULeft");
					}
				} else if (vel.y == 0.0f) {
					// Not moving on the y axis
					staticY = true;
					if (Input.GetKey (KeyCode.Space)) {
						// If player is mopping
						pAnimator.Play ("ANIM_PlayerMop_Left");
					} else {
						// If player is not mopping
						//if (animStateInfo.nameHash != Animator.StringToHash ("ANIM_PlayerRun_Left")) {
						pAnimator.Play ("ANIM_PlayerRun_Left");
						// }
					}
				}
			} else if (vel.x == 0.0f) {
				// Not moving on the x axis
				staticX = true;
				if (vel.y < 0.0f) {
					// Moving down
					directionUp = false;
					staticY = false;
					if (Input.GetKey (KeyCode.Space)) {
						// If player is mopping
						pAnimator.Play ("ANIM_PlayerMop_DLeft");
					} else {
						// If player is not mopping
						pAnimator.Play ("ANIM_PlayerRun_DLeft");
					}
				} else if (vel.y > 0.0f) {
					// Moving up
					directionUp = true;
					staticY = false;
					if (Input.GetKey (KeyCode.Space)) {
						// If player is mopping
						pAnimator.Play ("ANIM_PlayerMop_ULeft");
					} else {
						// If player is not mopping
						pAnimator.Play ("ANIM_PlayerRun_ULeft");
					}
				} else if (vel.y == 0.0f) {
					// Not moving on the y axis
					staticY = true;
					if (directionUp) {
						if (directionLeft) {
							pAnimator.Play ("ANIM_Player_IdleULeft");
						} else {
							pAnimator.Play ("ANIM_Player_IdleURight");
						}
					} else {
						if (directionLeft) {
							pAnimator.Play ("ANIM_Player_IdleDLeft");
						} else {
							pAnimator.Play ("ANIM_Player_IdleDRight");
						}
					}


				}
			}
		} else {
			if (directionLeft) {
				pAnimator.Play ("ANIM_PlayerTorchLight_Left");
			} else {
				pAnimator.Play ("ANIM_PlayerTorchLight_Right");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Blood" && Input.GetKey(KeyCode.Space)) {
			Destroy (col.gameObject);
		}
	}

	public void kill()
	{
		transform.position = new Vector3(checkPoint.transform.position.x, checkPoint.transform.position.y, -2.0f);
	}
}
