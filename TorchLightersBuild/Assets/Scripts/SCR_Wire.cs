using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Wire : MonoBehaviour 
{
	public GameObject Rubble;
	public GameObject TrapDoor;
	public Sprite trapDoorDisabled;

	bool wireHit = false;
	bool playerOnTrap = false;
	float hitTimer = 2.0f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (wireHit == true)
		{
			hitTimer -= Time.deltaTime;
		}
	
		if (hitTimer <= 0.0f && playerOnTrap)
		{
			SCR_Player.dead = true;
			SCR_TrapDoor.trapReady = false;
			hitTimer = 2.0f;
			wireHit = false;
			SCR_Rubble.rubbleEquipped = false;
			Debug.Log ("DIES");
		} 
		else if (hitTimer <= 0.0f && !playerOnTrap)
		{
			SCR_TrapDoor.trapReady = false;
			hitTimer = 2.0f;
			wireHit = false;
			SCR_Rubble.rubbleEquipped = false;
			Debug.Log ("LIVES");
		}
	}



	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			wireHit = true;
			Rubble.SetActive (true);
			SCR_Rubble.rubbleEquipped = false;
			Rubble.transform.position = SCR_Rubble.rubbleStartPosition;
			TrapDoor.GetComponent<SpriteRenderer> ().sprite = trapDoorDisabled;
		}
	}

	public void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			playerOnTrap = true;
			Debug.Log ("On");
		} 
		else
		{
			playerOnTrap = false;
			Debug.Log ("Off");
		}
	}

}


