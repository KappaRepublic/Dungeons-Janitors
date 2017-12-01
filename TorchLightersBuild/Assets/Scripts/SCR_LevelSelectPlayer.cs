using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

/*
* Class Name:
* Level Select Player
* ==========
* 
* Created: 05/10/17
* Author(s): Sebastian Poskitt-Marshall
*
* Purpose:
* Controls all actions related to player input within the level
* select screen
*/

public class SCR_LevelSelectPlayer : MonoBehaviour {

	public int playerVelocity = 3;
	bool movingLeft = false;

	GamePadState state;
	GamePadState prevState;

	// Use this for initialization
	void Start () {
		//AkSoundEngine.LoadBank (0, 0);
	}

	public void Footsteps(){
		AkSoundEngine.PostEvent ("Foots", gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		updateMovement ();
	}

	void updateMovement() {

		// Update the game controller
		prevState = state;
		state = GamePad.GetState (PlayerIndex.One);

		Rigidbody2D rigidBody = GetComponent<Rigidbody2D> ();

		if (Input.GetKey (KeyCode.A) || (prevState.ThumbSticks.Left.X < -0.1)) {
			rigidBody.velocity = new Vector2 (-1.0f, 0.0f) * playerVelocity;
			movingLeft = true;

			this.gameObject.GetComponent<Animator> ().Play ("ANIM_LevelPlayer_RunLeft");
		} else if (Input.GetKey (KeyCode.D) || (prevState.ThumbSticks.Left.X > 0.1)) {
			rigidBody.velocity = new Vector2 (1.0f, 0.0f) * playerVelocity;
			movingLeft = false;

			this.gameObject.GetComponent<Animator> ().Play ("ANIM_LevelPlayer_RunRight");
		} else {
			rigidBody.velocity = new Vector2 (0.0f, 0.0f) * playerVelocity;

			if (movingLeft) {
				this.gameObject.GetComponent<Animator> ().Play ("ANIM_LevelPlayer_IdleLeft");
			} else {
				this.gameObject.GetComponent<Animator> ().Play ("ANIM_LevelPlayer_IdleRight");
			}
		}
	}
}
