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
* Author(s): Rory McLean, Sebastian Poskitt-Marshall
*
* Purpose:
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

	public void lightTorch(){

		if (!torchLit) {

			torchLit = true;

			int rand = Random.Range (0, 2);

			// Choose a random animation to play for variance in graphics.
			switch (rand) {
			case 0:
				GetComponent<Animator> ().Play ("ANIM_TorchBeingLit01");
				break;
			case 1:
				GetComponent<Animator> ().Play ("ANIM_TorchBeingLit02");
				break;
			case 2:
				GetComponent<Animator> ().Play ("ANIM_TorchBeingLit03");
				break;
			default:
				break;
			}

		}

		lightSource.SetActive (true);
	}
}
