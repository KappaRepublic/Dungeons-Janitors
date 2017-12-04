using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
* Class Name:
* SCR_LevelElevator
* ==========
* 
* Created: 21/11/17
* Author(s): Sebastian Poskitt-Marshall
*
* Purpose:
* Enters the linked scene when player interacts with the object
* in level.
*/

public class SPR_LevelElevator : MonoBehaviour {

	public int sceneToLoad;
	public float timeToOpen = 0.7f;
	bool opened;

	void Update() {
		if (opened) {
			timeToOpen -= Time.deltaTime;
			if (timeToOpen <= 0.0f) {
				SceneManager.LoadScene (sceneToLoad);
			}
		}
	}

	void OnTriggerStay2D(Collider2D col) {
		if (Input.GetKey (KeyCode.W)  || Input.GetKeyDown(KeyCode.Joystick1Button0)) {
			this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			this.gameObject.GetComponent<Animator> ().enabled = true;
			col.gameObject.GetComponent<SCR_LevelSelectPlayer> ().enabled = false;
            AkSoundEngine.PostEvent("OpenLift", gameObject);

            opened = true;
		}
	}
}
