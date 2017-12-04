using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
* Class Name:
* SCR_LevelSelectBackgroundMovement
* ==========
* 
* Created: 17/11/17
* Author(s): Sebastian Poskitt-Marshall
*
* Purpose:
* Updates and shows all the required information at the end of
* each level on the results screen.
*/

public class SCR_ResultScreen : MonoBehaviour {

	public Text timeTaken;
	public Text torchScore;
	public Text trapScore;
	public Text bloodScore;
	public Text chestScore;
	public Text corpseScore;
	public Text totalScore;

	public SCR_Timer timer;
	public SCR_ScoreTracker sTracker;

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Show percentages of each category
		torchScore.text = sTracker.getTorchPercentage().ToString() + "%";
		trapScore.text = sTracker.getTrapPercentage ().ToString () + "%";
		bloodScore.text = sTracker.getBloodPercentage ().ToString () + "%";
		chestScore.text = sTracker.getChestPercentage ().ToString () + "%";
		corpseScore.text = sTracker.getCorpsePercentage ().ToString () + "%";
		totalScore.text = sTracker.getTotalPercentage ().ToString () + "%";

		// Show the total time taken

		string minutesS = timer.getMinutes().ToString ();
		string secondsS = timer.getSeconds().ToString ();

		if (timer.getMinutes() < 10) {
			minutesS = "0" + timer.getMinutes().ToString ();
		}
		if (timer.getSeconds() < 10) {
			secondsS = "0" + timer.getSeconds().ToString ();
		}

		timeTaken.text = minutesS + ":" + secondsS;
	}

	public void buttonContinue() {
		SceneManager.LoadScene (1);
	}

	public void buttonRetry() {
		Destroy (player);
		SceneManager.LoadScene (Application.loadedLevel);

		// AkSoundEngine.UnloadBank ("Main", null);
		AkSoundEngine.SetState("Music", "None");
		// AkSoundEngine.PostEvent("Music_Start", gameObject);
	}
}
