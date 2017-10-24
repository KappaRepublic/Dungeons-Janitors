using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Rubble : MonoBehaviour 
{

	/*
* Class Name
* ==========
* 
* Created: 24/10/17
* Base Class: (If applicable) Name of the base class.
* Author(s): Rory McLean
*
* Purpose: The purpose of this file.
* functionality for the rubble which is dropped via the rockfall trap
*/

	public static bool rubbleEquipped = false;

	public static Vector3 rubbleStartPosition;

	// Use this for initialization
	void Start () 
	{
		rubbleStartPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}


	//player picks up the rubble
	public void  rubbleInteraction()
	{
		gameObject.SetActive (false);
		rubbleEquipped = true;
	}
}
