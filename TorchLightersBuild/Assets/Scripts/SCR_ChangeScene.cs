using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/*
	 * Class Name:
	 * ChangeScene
	 * ==========
	 * 
	 * Created: 02/10/17
	 * Base Class: (If applicable) Name of the base class.
	 * Author(s): Rory McLean
	 *
	 * Purpose: The purpose of this file.
	 * Simple changing between scenes
	 */

public class SCR_ChangeScene : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if (Input.GetKey (KeyCode.Escape))
		{
			Application.Quit ();
		}*/
	}

	public void changeGameScene(int level)
	{

		SceneManager.LoadScene (level);
	}
		
}
