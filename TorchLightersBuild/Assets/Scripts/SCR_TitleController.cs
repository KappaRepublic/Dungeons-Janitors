using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

/*
* Class Name:
* Title Controller
* ==========
* 
* Created: 30/11/2017
* Author(s): Sebastian Poskitt-Marshall
*
* Purpose:
* Controls the title screen via keyboard and controller input
* as well as containing the relevant functions required to be
* called on the title screen
*/

public class SCR_TitleController : MonoBehaviour {

	public int currentOption = 0;

	public GameObject[] titleObjects;

	GamePadState state;
	GamePadState prevState;

	bool optionMoved = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Call the function to update input
		processInput ();
		// Update the title screen images
		updateTitleImages();
	}

	void processInput() {
		// Update the game controller
		prevState = state;
		state = GamePad.GetState (PlayerIndex.One);

		// Increment selected option when W is pressed
		if (!optionMoved) {
			if (Input.GetKeyDown (KeyCode.W) || (state.ThumbSticks.Left.Y > 0.1)) {
				currentOption--;
				if (currentOption < 0) {
					currentOption = 3;
				}
				if (state.ThumbSticks.Left.Y > 0.1) {
					optionMoved = true;
				}
				// Decrement selected option when D is pressed
			} else if (Input.GetKeyDown (KeyCode.S) || (state.ThumbSticks.Left.Y < -0.1)) {
				currentOption++;
				if (currentOption > 3) {
					currentOption = 0;
				}
				if (state.ThumbSticks.Left.Y < -0.1) {
					optionMoved = true;
				}
			}
		} else {
			if (state.ThumbSticks.Left.Y == 0.0f) {
				optionMoved = false;
			}
		}

		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0)) {
			switch (currentOption) {
			case 0:
				SceneManager.LoadScene (1);
				break;
			case 1:
				break;
			case 2:
				break;
			case 3:
				Application.Quit ();
				break;
			default:
				break;
			}
		}
	}

	void updateTitleImages() {
		switch (currentOption) {
		case 0:
			titleObjects [0].SetActive (true);
			titleObjects [1].SetActive (false);
			titleObjects [2].SetActive (false);
			titleObjects [3].SetActive (false);
			break;
		case 1:
			titleObjects [0].SetActive (false);
			titleObjects [1].SetActive (true);
			titleObjects [2].SetActive (false);
			titleObjects [3].SetActive (false);
			break;
		case 2:
			titleObjects [0].SetActive (false);
			titleObjects [1].SetActive (false);
			titleObjects [2].SetActive (true);
			titleObjects [3].SetActive (false);
			break;
		case 3:
			titleObjects [0].SetActive (false);
			titleObjects [1].SetActive (false);
			titleObjects [2].SetActive (false);
			titleObjects [3].SetActive (true);
			break;
		default:
			break;
		}
	}
}
