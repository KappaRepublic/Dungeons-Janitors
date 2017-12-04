using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Class Name:
* SCR_SpikeAll
* ==========
* 
* Created: 18/10/17
* Author(s): Sebastian Poskitt-Marshall, Rory McLean
*
* Purpose:
* Attaches a group of spikes to a group of levers within the level
* to link up their functionality.
*/

public class SCR_SpikeAll : MonoBehaviour 
{
	public GameObject[] linkedspikes;
	public GameObject[] linkedLever;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}


	public void allSpikes()
	{
		for (int i = 0; i < linkedspikes.Length; i++)
		{
			linkedspikes [i].GetComponent<SCR_Spikes>().swapState ();
			linkedspikes [i].GetComponent<SCR_Spikes> ().steps = 0;

		}

		for (int i = 0; i < linkedLever.Length; i++) {
			linkedLever[i].GetComponent<SCR_SpikeLever> ().activated = false;
		}


	}
}
