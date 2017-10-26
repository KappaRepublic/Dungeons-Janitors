using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_Timer : MonoBehaviour {

	float timer = 0.0f;

	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		// Convert the time to minutes and seconds
		float minutes = Mathf.Floor(timer / 60);
		float seconds = Mathf.RoundToInt (timer % 60);

		string minutesS = minutes.ToString ();
		string secondsS = seconds.ToString ();;

		if (minutes < 10) {
			minutesS = "0" + minutes.ToString();
		}
		if (seconds < 10) {
			secondsS = "0" + seconds.ToString();
		}

		GetComponent<Text> ().text = "" + minutesS + ":" + secondsS;


	}
}
