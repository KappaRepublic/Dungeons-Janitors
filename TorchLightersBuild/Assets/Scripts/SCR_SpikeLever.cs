using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_SpikeLever : MonoBehaviour {

	// Array of the spikes activated by this lever
	public GameObject[] linkedSpikes;
	public Sprite leverOn, leverOff;
	bool activated = false;

	// Activate the lever
	public void activate() {
		if (!activated) {
			for (int i = 0; i < linkedSpikes.Length; i++) {
				linkedSpikes [i].GetComponent<SCR_Spikes>().swapState ();
                AkSoundEngine.PostEvent("Pull_Lever", gameObject);

            }

            GetComponent<SpriteRenderer> ().sprite = leverOn;
			activated = true;

        }
    }
}
