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
	// public Sprite closedGate;
	// public Sprite openGate;
	public GameObject gateObject;
	float openTime = 5.0f;
	public bool gateIsOpened;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gateIsOpened) {
			if (gateOpen == true) {
				openTime -= Time.deltaTime;
			}

			if (openTime <= 0.0f) {
				openTime = 5.0f;


				// gateObject.GetComponent<SpriteRenderer> ().sprite = openGate;
				gateObject.GetComponent<BoxCollider2D> ().enabled = false;
				
				gateOpen = false;
			}
		}
	}

	public void activateGate() 
	{
		if (!gateIsOpened) {
            AkSoundEngine.PostEvent("Open_Gate", gameObject);
            //gateOpen = !gateOpen;

            /*if (gateOpen == true)
		{
			//seb is a silly goose
			// I concur
			gateObject.GetComponent<SpriteRenderer> ().sprite = openGate;
			gateObject.GetComponent<BoxCollider2D> ().enabled = false;
			AkSoundEngine.PostEvent ("Close_Gate", gameObject);

		}*/
            gateOpen = true;
			gateIsOpened = true;
			this.gameObject.transform.GetChild (0).gameObject.GetComponent<Animator> ().Play ("ANIM_GateOpen");

			//if (gateOpen == false)
			/*{
			openTime = 5.0f;
			gateObject.GetComponent<SpriteRenderer> ().sprite = closedGate;
			gateObject.GetComponent<BoxCollider2D> ().enabled = true;
			AkSoundEngine.PostEvent ("Open_Gate", gameObject);
			gateOpen = false;
		}*/
		}
        else
        {
            AkSoundEngine.PostEvent("Close_Gate", gameObject);
        }
	}
		
}
