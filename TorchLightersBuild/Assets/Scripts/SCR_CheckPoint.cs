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
* Author(s): Rory McLean
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
		if (coll.gameObject.tag == "Player")
		{
			coll.gameObject.GetComponent<SCR_Player> ().checkPoint = this.gameObject;
		}

	}
}
