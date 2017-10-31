using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Class Name
* DeadMonster Script
* 
* Created: 31/10/17
* Base Class: (If applicable) Name of the base class.
* Author(s): Rory McLean
*
* Purpose: The purpose of this file.
* Functionality for the monsters, reviving them from being dead 
*/

public class SCR_DeadMonster : MonoBehaviour 
{
	bool isAlive = false;
	public Sprite monsterDead;
	public Sprite monsterFed;

	float rightLimit;// = 2.5f;
	float leftLimit;// = 1.0f;
	float speed = 2.0f;
	int direction = 1;

	Vector3 movement;
	Vector3 currentPosition;


	// Use this for initialization
	void Start () 
	{
		rightLimit = gameObject.transform.position.x + 2.5f;
		leftLimit = gameObject.transform.position.x - 2.5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isAlive == true)
		{
			if (transform.position.x > rightLimit)
			{
				direction = -1;
			} else if (transform.position.x < leftLimit)
			{
				direction = 1;
			}
			movement = Vector3.right * direction * speed * Time.deltaTime;
			transform.Translate (movement);

		}
	}


	public void reviveMonster()
	{
		isAlive = true;
		GetComponent<SpriteRenderer> ().sprite = monsterFed;
	}
}
