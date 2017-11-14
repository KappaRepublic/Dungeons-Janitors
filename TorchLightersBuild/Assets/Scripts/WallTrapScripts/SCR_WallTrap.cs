using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Class Name
* wallTrap Script
* 
* ==========
* 
* Created: 05/10/17
* Base Class: (If applicable) Name of the base class.
* Author(s): Rory McLean
*
* Purpose: The purpose of this file.
* Functionality for the walltrap
* ensuring the bullets and pressureplate will not activate unless the walltrap has been refilled
*/

public class SCR_WallTrap : MonoBehaviour 
{
	public static Vector3 currentPosition;
	public SCR_PressurePlate pressure;

	// Use this for initialization
	void Start () 
	{
		currentPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log (SCR_PressurePlate.platePressed);
	}

	public void resetTrap()
	{		
		if (pressure.platePressed == true)
		{
            AkSoundEngine.PostEvent("Arrow_Fire", gameObject);

            pressure.platePressed = false;

		}
	}
}
