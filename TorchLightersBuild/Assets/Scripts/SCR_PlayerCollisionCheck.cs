using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Class Name:
* SCR_PlayerMovement
* ==========
* 
* Created: 04/10/17
* Author(s): Sebastian Poskitt-Marshall
*
* Purpose:
* Adjusts the players scale based on the direction they are facing in the level
* select screen.
*/

public class SCR_PlayerMovement : MonoBehaviour {

	public GameObject indicator;

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.A)) {
			transform.localScale = new Vector3(-2.0f, 5.0f, 1.0f);
		} else if (Input.GetKeyDown (KeyCode.D)) {
			transform.localScale = new Vector3(2.0f, 5.0f, 1.0f);
		}
	}
} 
