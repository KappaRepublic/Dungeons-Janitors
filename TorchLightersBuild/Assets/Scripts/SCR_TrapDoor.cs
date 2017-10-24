using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Class Name
* ==========
* 
* Created: 24/10/17
* Base Class: (If applicable) Name of the base class.
* Author(s): Rory McLean
*
* Purpose: The purpose of this file.
* functionality for the trapDoor for the rockfall trap
*/

public class SCR_TrapDoor : MonoBehaviour 
{
	public Sprite trapDoorDisabled;
	public Sprite trapDoorEnabled;
	public GameObject trapDoor;
	public GameObject Rubble;
	public GameObject Wire;
	public static bool trapReady = false;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (trapReady == true)
		{
			Wire.SetActive (true);
		} else
		{
			Wire.SetActive (false);
		}
	}

	public void trapDoorInteraction()
	{
		trapDoor.gameObject.GetComponent<SpriteRenderer> ().sprite = trapDoorEnabled;

		if (SCR_Rubble.rubbleEquipped == true)
		{
			Rubble.transform.position = gameObject.transform.position;
			Rubble.gameObject.SetActive (true);
			trapReady = true;
		}
	}
}
