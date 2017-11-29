using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_LevelUpdate : MonoBehaviour {

	public SCR_ScoreTracker sTracker;
	public float RTPC;

	// Update is called once per frame
	void Update () {
		// 0%, 20%, 40%, 60%, 80%

		if (sTracker.getTotalPercentage() < 20.0f) {
			// No state is set for less than 20%
			Debug.Log ("0%");
		} else if (sTracker.getTotalPercentage () >= 20.0f && sTracker.getTotalPercentage () < 40.0f) {
			AkSoundEngine.SetState ("Music", "L1");
			Debug.Log ("20%");
		} else if (sTracker.getTotalPercentage () >= 40.0f && sTracker.getTotalPercentage () < 60.0f) {
			AkSoundEngine.SetState ("Music", "L2");
			Debug.Log ("40%");
		} else if (sTracker.getTotalPercentage () >= 60.0f && sTracker.getTotalPercentage () < 80.0f) {
			AkSoundEngine.SetState ("Music", "L3");
			Debug.Log ("60%");
		} else if (sTracker.getTotalPercentage () >= 80.0f) {
			AkSoundEngine.SetState ("Music", "L4");
			Debug.Log ("80%");
		}

		RTPC = sTracker.getTotalPercentage ();
			
		AkSoundEngine.SetRTPCValue (RTPC, Ambience);

		AkSoundEngine.SetRTPCValue (Ambience, RTPC);
		
	}
}
