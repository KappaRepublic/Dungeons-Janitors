using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_NewMonster : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//temp code for moving a monster outside of the bounds colliders.
		//Delete after monster is fully functional 
		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			Vector3 position = this.transform.position;
			position.x++;
			this.transform.position = position;
		}

		if (Input.GetKeyDown (KeyCode.UpArrow))
		{
			Vector3 position = this.transform.position;
			position.y++;
			this.transform.position = position;
		}
	}
}
