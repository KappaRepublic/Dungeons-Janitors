using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Spikes : MonoBehaviour {

	public Sprite spikesDown, spikesUp;
	bool activated = true;
	
	// Change the state of the spikes
	public void swapState(){
		// Swap activated state boolean
		activated = !activated;
		// Update graphic based on current state
		if (activated) {
			GetComponent<SpriteRenderer> ().sprite = spikesUp;
            AkSoundEngine.PostEvent("Trigger_Trap", gameObject);

        }
        else {
			GetComponent<SpriteRenderer> ().sprite = spikesDown;
			GetComponent<BoxCollider2D> ().enabled = false;
            AkSoundEngine.PostEvent("Set_Trap", gameObject);

        }
    }
}
