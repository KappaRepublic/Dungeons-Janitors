using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Class Name
* Bullet Script
* 
* ==========
* 
* Created: 05/10/17
* Base Class: (If applicable) Name of the base class.
* Author(s): Rory McLean
*
* Purpose: The purpose of this file.
* Functionality for the bullets
* ensuring they are destroyed when they hit an object
* 
*/

public class SCR_Bullet : MonoBehaviour 
{

	float destroyTimer = 5.0f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		destroyTimer -= Time.deltaTime;

		if (destroyTimer <= 0)
		{
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{

		if (col.gameObject.tag == "Player")
		{
			// SCR_Player.dead = true;
			Destroy (gameObject);
		}


		// 
	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.gameObject.tag == "DestructionZone") 
		{
			Destroy (gameObject);
		}
	}
}
