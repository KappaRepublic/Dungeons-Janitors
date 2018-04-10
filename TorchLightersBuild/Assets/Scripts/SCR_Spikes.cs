using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Class Name:
* SCR_Spikes
* ==========
* 
* Created: 03/10/17
* Author(s): Sebastian Poskitt-Marshall, Rory McLean
*
* Purpose:
* Functionality for the spikes within the level, including
* setting them up and down based on levers.
*/

public class SCR_Spikes : MonoBehaviour 
{

	public Sprite spikesDown, spikesUp;
	public bool activated = true;
	public int steps = 0;
	public GameObject player;
	public GameObject player2;

	bool player2Check = false;

	bool touchingCheck = false;


	void Start()
	{
		player = GameObject.FindGameObjectsWithTag ("Player")[0];
		player2 = GameObject.FindGameObjectsWithTag ("Player")[1];
	}

	void Update()
	{
		//if the player steps on this trap twice then kill the player
		if (steps >= 2) {
			steps = 0;
			transform.parent.GetComponent<SCR_SpikeAll> ().allSpikes ();
			Debug.Log ("Ouch");
			//swapState ();
			//respawn player
			if (player2Check) {
				Debug.Log ("Player 2");
				player2.GetComponent<SCR_Player> ().kill (this.gameObject);
				AkSoundEngine.PostEvent ("Dead", gameObject);
			} else {
				Debug.Log ("Player 1");
				player.GetComponent<SCR_Player> ().kill (this.gameObject);
				AkSoundEngine.PostEvent ("Dead", gameObject);
			}





		} else if (steps == 1) {
			this.GetComponent<Animator> ().Play ("ANIM_SpikePrimed");
		}
    }

	// Change the state of the spikes
	public void swapState()
	{
		// Swap activated state boolean
		activated = !activated;
		// Update graphic based on current state
		if (activated) 
		{
			// GetComponent<SpriteRenderer> ().sprite = spikesUp;
			GetComponent<Animator> ().Play ("ANIM_SpikeActivate");
			GetComponent<BoxCollider2D> ().enabled = true;
			AkSoundEngine.PostEvent ("Spikes_Up", gameObject);
			steps = 0;


			//if player is colliding 
			if (touchingCheck == true)
			{
				if (player2Check) {
					Debug.Log ("Player 2");
					player2.GetComponent<SCR_Player> ().kill (this.gameObject);
					AkSoundEngine.PostEvent ("Dead", gameObject);
				} else {
					Debug.Log ("Player 1");
					player.GetComponent<SCR_Player> ().kill (this.gameObject);
					AkSoundEngine.PostEvent ("Dead", gameObject);
				}
			}

		} else 
		{


			// GetComponent<SpriteRenderer> ().sprite = spikesDown;
			GetComponent<Animator> ().Play ("ANIM_SpikeDeactivate");
			GetComponent<BoxCollider2D> ().enabled = false;
			AkSoundEngine.PostEvent ("Spikes_Down", gameObject);


        }
    }


	public void OnTriggerEnter2D(Collider2D col)
	{

		if (col.gameObject.tag == "Player" && activated == false)
		{
			if (!col.gameObject.GetComponent<SCR_Player> ().dodging) {
				//when the player walks on spike trap, add to a counter
				steps += 1;
				if (col.gameObject.GetComponent<SCR_Player> ().player2) {
					player2Check = true;
				} else {
					player2Check = false;
				}
			}

		}
	}


	public void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			if (player2Check)
			{
				touchingCheck = true;
			} else
			{
				touchingCheck = true;
			}
		}
	}
}
