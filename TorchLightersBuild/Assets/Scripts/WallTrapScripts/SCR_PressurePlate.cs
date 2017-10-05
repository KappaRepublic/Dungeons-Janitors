using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SCR_PressurePlate : MonoBehaviour 
{
	/*
* Class Name
* PressurePlate Script
* 
* ==========
* 
* Created: 05/10/17
* Base Class: (If applicable) Name of the base class.
* Author(s): Rory McLean
*
* Purpose: The purpose of this file.
* Functionality for the pressureplate attached to the wall trap. 
* when you hit the pressureplate the wall trap will fire
*/

	public GameObject bulletPrefab;
	public GameObject wallTrap;
	float bulletImpulse = 5.0f;
	GameObject theBullet;

	public static bool platePressed;

	// Use this for initialization
	void Start () 
	{
		platePressed = false;
	}

	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player" && platePressed == false)
		{
			platePressed = true;

			theBullet = (GameObject)Instantiate (bulletPrefab, wallTrap.transform.position + wallTrap.transform.forward, wallTrap.transform.rotation);
			theBullet.GetComponent<Rigidbody2D> ().AddForce (wallTrap.transform.up * bulletImpulse, ForceMode2D.Impulse);

		}

	}
}
