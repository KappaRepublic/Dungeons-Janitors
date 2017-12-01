using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Class Name:
* SCR_Level
* ==========
* 
* Created: 04/10/17
* Author(s): Sebastian Poskitt-Marshall
*
* Purpose:
* Checks collision between the player and trigger areas for selecting
* a level at the level selection stage. If the correct input is given
* whilst a collision is occuring, moves the player to a scene relating
* to the gameLevelToLoad variable.
*/

public class SCR_Level : MonoBehaviour {

	// Game object that highlights this trigger is interactable
	public GameObject indicator;
	// What level this trigger will load when used
	public int gameLevelToLoad;

	void OnTriggerStay (Collider col)
	{
		// Show indication that object is interactable
		indicator.SetActive (true);
		// Check for player input
		if (Input.GetKeyDown (KeyCode.W)) {
			Application.LoadLevel (gameLevelToLoad);
		}
	}

	void OnTriggerExit (Collider col)
	{
		// Remove indication that object is interactable
		indicator.SetActive(false);
	}
}
