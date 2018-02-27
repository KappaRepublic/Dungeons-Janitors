using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Class Name:
* SCR_LevelSelectMovement
* ==========
* 
* Created: 03/10/17
* Author(s): Sebastian Poskitt-Marshall
*
* Purpose:
* Allows objects within the level select screen to move and wrap
* around the screen when certain counditions on position are met.
*/


public class SCR_LevelSelectMovement : MonoBehaviour {
	public float speed = 0;
	
	// Update is called once per frame
	void Update () {
		// Listen for players key press
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (speed, 0.0f, 0.0f);
		} else if (Input.GetKey (KeyCode.D)) {
			transform.Translate (-speed, 0.0f, 0.0f);
		}

		// Find the horizontal boundaries of the camera
		float horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height;
		float adjustment = (GetComponent<Renderer> ().bounds.size.x) * 0.1f; //0.1825f; // Value to adjust new position by to avoid offset




		Debug.Log (GetComponent<Renderer> ().bounds.size.x);


		// Check if the object is off screen
		if (transform.position.x < -horzExtent) {
			float offset = transform.position.x + horzExtent;
			transform.position = new Vector3 (horzExtent + (offset * 0.5f), transform.position.y, transform.position.z);

		} else if (transform.position.x > horzExtent) {
			float offset = transform.position.x - horzExtent;
			transform.position = new Vector3 (-horzExtent + (offset * 0.5f), transform.position.y, transform.position.z);
		}
	}
}
