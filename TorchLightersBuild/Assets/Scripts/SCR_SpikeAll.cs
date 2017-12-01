using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
