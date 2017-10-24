using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Class Name
* Torch Script
* 
* ==========
* 
* Created: 05/10/17
* Base Class: (If applicable) Name of the base class.
* Author(s): Rory McLean
*
* Purpose: The purpose of this file.
* Functionality for the torchs
* lighting them when the player is in proxsimity and presses the light button
* 
*/

public class SCR_Torch : MonoBehaviour 
{
	bool torchLit = false;
	public Sprite unlitSprite;
	public Sprite litSprite;
	public GameObject lightSource;

	//changes the sprite to signify the light is on
	public void lightTorch(){
		torchLit = true;
		GetComponent<SpriteRenderer> ().sprite = litSprite;
		//activates the light source for the lighting system.
		lightSource.SetActive (true);
	}
}
