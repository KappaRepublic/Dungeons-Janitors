using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Class Name:
* SCR_LevelSelectBackgroundMovement
* ==========
* 
* Created: 03/10/17
* Author(s): Sebastian Poskitt-Marshall
*
* Purpose:
* Allows objects within the level select screen to move and wrap
* around the screen when certain counditions on position are met.
*/

public class SCR_LevelSelectBackgroundMovement : MonoBehaviour {

	public float speed = 0;

	// Update is called once per frame
	void Update () {
		// Listen for players key press
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (speed, 0.0f, 0.0f);
		} else if (Input.GetKey (KeyCode.D)) {
			transform.Translate (-speed, 0.0f, 0.0f);
		}

		float horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height;
		float xSize = GetComponent<Renderer> ().bounds.size.x;

		// Check if the object is off screen
		if (transform.position.x < -xSize) {
			float offset = transform.position.x + horzExtent;
			transform.position = new Vector3 (xSize + offset + horzExtent, transform.position.y, transform.position.z);

		} else if (transform.position.x > xSize) {
			float offset = transform.position.x - horzExtent;
			transform.position = new Vector3 (-xSize + offset - horzExtent, transform.position.y, transform.position.z);
		}
	}
}

