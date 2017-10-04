using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Level : MonoBehaviour {

	// Game object that highlights this trigger is interactable
	public GameObject indicator;
	// What level this trigger will load when used
	public int gameLevelToLoad;

	void OnTriggerStay (Collider col)
	{
		// Show indication that object is interactable
		indicator.SetActive (true);
	}

	void OnTriggerExit (Collider col)
	{
		// Remove indication that object is interactable
		indicator.SetActive(false);
	}
}
