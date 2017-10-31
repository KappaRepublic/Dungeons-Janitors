using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Class Name
* Monster Script
* 
* Created: 10/10/17
* Base Class: (If applicable) Name of the base class.
* Author(s): Rory McLean
*
* Purpose: The purpose of this file.
* Functionality for the monsters, reviving them from being dead and feeding them when they are alive
* when a monster is fully happy they will move back and forth to simulate potrolling a dungeon
*/


public class SCR_Monster : MonoBehaviour 
{

	bool isAlive = false;
	bool isHungry = false;
	bool stopTimer = false;
	bool isHappy = false;

	float hungerTimer = 5.0f;

	public Sprite monsterDead;
	public Sprite monsterHungry;
	public Sprite monsterFed;


	float rightLimit;// = 2.5f;
	float leftLimit;// = 1.0f;
	float speed = 2.0f;
	int direction = 1;

	Vector3 movement;

	// Use this for initialization
	void Start () 
	{
		rightLimit = gameObject.transform.position.x + 2.5f;
		leftLimit = gameObject.transform.position.x - 2.5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log (hungerTimer);

		//when the monster is brought back
		//after a few seconds the monster will become hungry
		if (isAlive == true && stopTimer == false)
		{
			hungerTimer -= Time.deltaTime;
		}

		if (hungerTimer <= 0)
		{
			isHungry = true;
		}

		//when the monster is fed and happy, they will
		//move back and forth
		if (isHappy == true)
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


	void OnTriggerStay2D(Collider2D coll)
	{
		//if the player interacts with a dead monster
		if (coll.gameObject.tag == "Player" && isAlive == false)
		{
			if (Input.GetKeyDown (KeyCode.Space))
			{
				//the monster is brought back to life
				isAlive = true;
				GetComponent<SpriteRenderer> ().sprite = monsterHungry;
			}
			//if the player interacts with a alive/ hungry monster
		} else if (coll.gameObject.tag == "Player" && isHungry == true)
		{
			if (Input.GetKeyDown (KeyCode.Space))
			{
				//the monster is fed, the hunger timer stops and they are happy
				GetComponent<SpriteRenderer> ().sprite = monsterFed;
				stopTimer = true;
				isHungry = false;
				isHappy = true;
			}
		}
	}



}
