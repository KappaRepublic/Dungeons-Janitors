using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ToolTip : MonoBehaviour {

	public GameObject toolTip;

	void OnTriggerEnter2D (Collider2D col) {
		toolTip.SetActive (true);
	}

	void OnTriggerExit2D (Collider2D col) {
		toolTip.SetActive (false);
	}
}
