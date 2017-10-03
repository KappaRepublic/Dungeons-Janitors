using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerCollisionCheck : MonoBehaviour {

	public GameObject indicator;

	void OnCollisionEnter (Collision col)
	{
		indicator.SetActive (true);
	}
} 
