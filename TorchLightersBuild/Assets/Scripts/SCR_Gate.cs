using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Class Name
* gate Script
* 
* ==========
* 
* Created: 05/10/17
* Base Class: (If applicable) Name of the base class.
* Author(s): Rory McLean
*
* Purpose: The purpose of this file.
* Functionality for the gates
* when they are closed they open, when open they close
* 
*/

public class SCR_Gate : MonoBehaviour 
{

	bool gateOpen = false;
	public Sprite closedGate;
	public Sprite openGate;

	public GameObject gate;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//changes the sprite and disables the collider so the player can walk through
		if (gateOpen == true)
		{
			gate.gameObject.GetComponent<SpriteRenderer> ().sprite = openGate;
			gate.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		}

		//visaversa
		if (gateOpen == false)
		{
			gate.gameObject.GetComponent<SpriteRenderer> ().sprite = closedGate;
			gate.gameObject.GetComponent<BoxCollider2D> ().enabled = true;
		}
	}

	//when the player interacts with a gate, if its open, close it. and if its
	//closed, open it.
	public void gateInteraction()
	{
		
		gateOpen = !gateOpen;

		//Debug.Log (gateOpen);
	}
}
