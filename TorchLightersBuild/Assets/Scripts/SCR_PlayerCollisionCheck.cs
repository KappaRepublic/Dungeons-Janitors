using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerCollisionCheck : MonoBehaviour {

	public GameObject indicator;

	void OnTriggerEnter (Collider col)
	{
		indicator.SetActive (true);
		Debug.Log ("Collision");
	}
} 
