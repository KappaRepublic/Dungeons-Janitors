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

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gateOpen == true)
		{
			GetComponent<SpriteRenderer> ().sprite = openGate;
			GetComponent<BoxCollider2D> ().enabled = false;
        }

        if (gateOpen == false)
		{
			GetComponent<SpriteRenderer> ().sprite = closedGate;
			GetComponent<BoxCollider2D> ().enabled = true;

        }
    }

	void OnTriggerStay2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			if (Input.GetKeyDown (KeyCode.Space))
			{
				gateOpen = !gateOpen;
                 if (gateOpen == true)
                {
                    AkSoundEngine.PostEvent("Open_Gate", gameObject);
                }
                 else
                {
                    AkSoundEngine.PostEvent("Close_Gate", gameObject);
                }
            }
		}

	}
}
