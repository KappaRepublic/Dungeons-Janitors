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
	public GameObject player;
	public GameObject player2;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectsWithTag ("Player")[0];
		player2 = GameObject.FindGameObjectsWithTag ("Player")[1];
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


	void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.gameObject.tag == "Player")
		{
            AkSoundEngine.PostEvent("Arrow_Kill", player);
			if (col.gameObject.GetComponent<SCR_Player> ().player2) {
				player2.GetComponent<SCR_Player>().kill (this.gameObject);
			} else {
				player.GetComponent<SCR_Player>().kill (this.gameObject);
			}


            Destroy(gameObject);

        }

        if (col.gameObject.tag == "DestructionZone") 
		{
			Destroy (gameObject);
	
				AkSoundEngine.PostEvent ("Arrow_Miss", gameObject);
			}

		}
	}

