using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SCR_OpenMenu : MonoBehaviour 
{
	/*
	 * Class Name:
	 * OpenMenu
	 * ==========
	 * 
	 * Created: 02/10/17
	 * Base Class: (If applicable) Name of the base class.
	 * Author(s): Rory McLean
	 *
	 * Purpose: The purpose of this file.
	 * simple pause menu for the game scene
	 * 
	 */

	//rawimage to represent the pause menu
	public RawImage pauseMenu;
	//global variable for game being paused
	public bool isPaused;

	// Use this for initialization
	void Start () 
	{
		isPaused = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//pressing escape will function the same as the menu button
		if (Input.GetKeyDown (KeyCode.Escape) && isPaused == false)
		{
			Pause ();
		} else if (Input.GetKeyDown (KeyCode.Escape) && isPaused == true)
		{
			UnPause ();
		}
	}


	public void openPauseMenu()
	{
		if (isPaused == false)
		{
			Pause ();
		} else if (isPaused == true)
		{
			UnPause ();
		}
	}


	public void Pause()
	{
		isPaused = true;
		pauseMenu.gameObject.SetActive (true);
		Time.timeScale = 0.0f;
	}

	public void UnPause()
	{
		isPaused = false;
		pauseMenu.gameObject.SetActive (false);
		Time.timeScale = 1.0f;
	}

	//exit application
	public void Quit()
	{
		Application.Quit();
	}


	//restarts the current level
	public void Restart()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		UnPause ();
	}
}
