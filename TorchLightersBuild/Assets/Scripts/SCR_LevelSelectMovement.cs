using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
			transform.position = new Vector3 (horzExtent , transform.position.y, transform.position.z);

		} else if (transform.position.x > horzExtent) {
			float offset = transform.position.x - horzExtent;
			transform.position = new Vector3 (-horzExtent , transform.position.y, transform.position.z);
		}
	}
}
