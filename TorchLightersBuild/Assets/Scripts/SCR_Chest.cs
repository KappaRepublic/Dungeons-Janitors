using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Class Name
* SCR_Chest
* 
* ==========
* 
* Created: 04/10/2017
* Author(s): Sebastian Poskitt-Marshall
*
* Purpose:
* Simple functionality for refilling chests
* 
*/

public class SCR_Chest : MonoBehaviour {

	public Sprite chestOpenSprite, chestClosedSprite;
	public bool chestRefilled;

	// Refills chest
	public void refillChest(){
		GetComponent<SpriteRenderer> ().sprite = chestClosedSprite;
		chestRefilled = true;
	}
}
