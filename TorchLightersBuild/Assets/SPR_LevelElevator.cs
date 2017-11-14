using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SPR_LevelElevator : MonoBehaviour {

	public int sceneToLoad;
	public float timeToOpen = 0.7f;
	bool opened;

	void Update() {
		if (opened) {
			timeToOpen -= Time.deltaTime;
			if (timeToOpen <= 0.0f) {
				SceneManager.LoadScene (1);
			}
		}
	}

	void OnTriggerStay2D(Collider2D col) {
		if (Input.GetKey (KeyCode.W)) {
			this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			this.gameObject.GetComponent<Animator> ().enabled = true;
			col.gameObject.GetComponent<SCR_LevelSelectPlayer> ().enabled = false;
			opened = true;
		}
	}
}
