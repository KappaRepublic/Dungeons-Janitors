using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Class Name
* SCR_LevelUpdate
* 
* ==========
* 
* Created: 08/11/2017
* Author(s): Sebastian Poskitt-Marshall
*
* Purpose:
* Checks the total percentage every second to update audio in level
* 
*/

public class SCR_LevelUpdate : MonoBehaviour {

	public SCR_ScoreTracker sTracker;

	void Start () {
		InvokeRepeating ("updateEverySecond", 0.0f, 1.0f);
	}

	// Update is called once per frame
	void updateEverySecond () {
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
	}
}
