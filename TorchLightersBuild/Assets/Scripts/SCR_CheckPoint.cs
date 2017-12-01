using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Class Name
* checkpoint Script
* 
* ==========
* 
* Created: 13/10/17
* Base Class: (If applicable) Name of the base class.
* Author(s): Rory McLean / Sebastian Poskitt-Marshall
*
* Purpose: The purpose of this file.
* functinality for the checkpoint
* 
*/

public class SCR_CheckPoint : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}


	void OnTriggerEnter2D(Collider2D coll)
	{
		//if the player touches a checkpoint object, that checkpoint is selected to be
		//the current checkpoint. so when the player dies they spawn at the most
		//recently touched checkpoint
		if (coll.gameObject.tag == "Player")
		{
			coll.gameObject.GetComponent<SCR_Player> ().checkPoint = this.gameObject;
		}

	}
}
