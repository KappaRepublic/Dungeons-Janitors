using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_LevelSelectBackgroundScroller : MonoBehaviour {
	public float speed = 0;

	void Update() {
		// Listen for players key press
		if (Input.GetKey(KeyCode.A)){
			// Get new position
			float oX = GetComponent<Renderer>().material.mainTextureOffset.x;
			oX -= speed;
			// Update to new position
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (oX, 0.0f);
		}
		else if (Input.GetKey(KeyCode.D)){
			// Get new position
			float oX = GetComponent<Renderer>().material.mainTextureOffset.x;
			oX += speed;
			// Update to new position
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (oX, 0.0f);
		}


	}
}
