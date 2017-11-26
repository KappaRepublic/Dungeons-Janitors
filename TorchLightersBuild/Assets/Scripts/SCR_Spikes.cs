using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Spikes : MonoBehaviour 
{

	public Sprite spikesDown, spikesUp;
	public bool activated = true;
	public int steps = 0;
	public GameObject player;


	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update()
	{
		//if the player steps on this trap twice then kill the player
		if (steps >= 2)
		{
			steps = 0;
			transform.parent.GetComponent<SCR_SpikeAll> ().allSpikes ();
			//swapState ();
			//respawn player
			player.GetComponent<SCR_Player>().kill (this.gameObject);
            AkSoundEngine.PostEvent("Dead", gameObject);

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
			}

		}
	}
}
