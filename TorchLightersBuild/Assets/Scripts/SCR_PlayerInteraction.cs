using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerInteraction : MonoBehaviour {

	public Animator pAnimator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay2D(Collider2D col)
	{
		// Show that object has been found to debug information
		Debug.Log ("Found something");

		// Check for player input as long as a valid target is available
		if (Input.GetKeyDown (KeyCode.I)) {
			if (col.gameObject.tag == "Chest") {
				col.gameObject.GetComponent<SCR_Chest> ().refillChest ();
			}
			if (col.gameObject.tag == "Lever") {
				Debug.Log ("Spike Lever");
				col.gameObject.GetComponent<SCR_SpikeLever> ().activate ();
			}
			if (col.gameObject.tag == "Torch") {
				Debug.Log ("Torch");
				col.gameObject.GetComponent<SCR_Torch> ().lightTorch ();
				// Play the animation
				pAnimator.Play("ANIM_PlayerTorchLight_Left");
			}

			if (col.gameObject.tag == "WallTrap")
			{
				Debug.Log ("WallTrap");
				col.gameObject.GetComponent<SCR_WallTrap> ().resetTrap ();
			}


			if (col.gameObject.tag == "GateCollider")
			{
				Debug.Log ("GateCollider");
				col.gameObject.GetComponent<SCR_Gate> ().gateInteraction ();
			}

			if(col.gameObject.tag == "RubbleCollider")
			{
				Debug.Log("RubbleCollider");
				col.gameObject.GetComponent<SCR_Rubble> ().rubbleInteraction();
			}

			if (col.gameObject.tag == "TrapDoor")
			{
				Debug.Log ("TrapDoor");
				col.gameObject.GetComponent<SCR_TrapDoor> ().trapDoorInteraction ();
			}


			if (col.gameObject.tag == "DeadMonster")
			{
				Debug.Log ("DeadMonster");
				col.gameObject.GetComponent<SCR_DeadMonster> ().reviveMonster ();
			}

			if (col.gameObject.tag == "HungryMonster")
			{
				Debug.Log ("HungryMonster");
				col.gameObject.GetComponent<SCR_HungryMonster> ().FeedMonster ();

			}
			
		}
	}
}
