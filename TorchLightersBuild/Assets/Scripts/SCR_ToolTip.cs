using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Class Name:
* SCR_ToolTip
* ==========
* 
* Created: 21/11/17
* Author(s): Sebastian Poskitt-Marshall
*
* Purpose:
* Displays a minimap of level before entering it on the level
* select screen
*/

public class SCR_ToolTip : MonoBehaviour {

	public GameObject toolTip;

	void OnTriggerEnter2D (Collider2D col) {
		toolTip.SetActive (true);
	}

	void OnTriggerExit2D (Collider2D col) {
		toolTip.SetActive (false);
	}
}
