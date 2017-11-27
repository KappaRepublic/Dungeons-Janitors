using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_LevelSelectPlayer : MonoBehaviour {

	public int playerVelocity = 3;
	bool movingLeft = false;

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
		Rigidbody2D rigidBody = GetComponent<Rigidbody2D> ();

		if (Input.GetKey (KeyCode.A)) {
			rigidBody.velocity = new Vector2 (-1.0f, 0.0f) * playerVelocity;
			movingLeft = true;

			this.gameObject.GetComponent<Animator> ().Play ("ANIM_LevelPlayer_RunLeft");
		} else if (Input.GetKey (KeyCode.D)) {
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
