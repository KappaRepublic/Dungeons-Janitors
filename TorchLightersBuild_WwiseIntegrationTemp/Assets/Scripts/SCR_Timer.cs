using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_Timer : MonoBehaviour {

	float timer = 0.0f;
	float startTimer = 4.0f;

	float minutes;
	float seconds;
	
	// Update is called once per frame
	void Update () {
		if (startTimer <= 0.0f) {
			timer += Time.deltaTime;

			// Convert the time to minutes and seconds
			minutes = Mathf.Floor (timer / 60);
			seconds = Mathf.RoundToInt (timer % 60);

			string minutesS = minutes.ToString ();
			string secondsS = seconds.ToString ();
			;

			if (minutes < 10) {
				minutesS = "0" + minutes.ToString ();
			}
			if (seconds < 10) {
				secondsS = "0" + seconds.ToString ();
			}

			GetComponent<Text> ().text = "" + minutesS + ":" + secondsS;
		} else {
			startTimer -= Time.deltaTime;

			GetComponent<Text> ().text = "00" + ":" + "00";
		}
	}

	public float getMinutes() {
		return minutes;
	}

	public float getSeconds() {
		return seconds;
	}
}
