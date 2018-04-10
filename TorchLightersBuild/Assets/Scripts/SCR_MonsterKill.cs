using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MonsterKill : MonoBehaviour 
{

	public GameObject Player1;
	public GameObject Player2;

	public bool playerKilled = false;



	// Use this for initialization
	void Start () 
	{

		Player1 = GameObject.FindGameObjectsWithTag ("Player") [0];
		Player2 = GameObject.FindGameObjectsWithTag ("Player") [1];
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			if (col.gameObject.GetComponent<SCR_Player> ().player2)
			{
				Player2.GetComponent<SCR_Player> ().kill (this.gameObject);
				//playerKilled = true;
				//gameObject.GetComponentInParent<SCR_NewMonster> ().mAnimator.Play ("ANIM_Monster_Idle_Blood_Left");
				//gameObject.GetComponentInParent<SCR_NewMonster> ().mAnimator.SetBool ("bloodFinished", true);
			} else
			{
				Player1.GetComponent<SCR_Player> ().kill (this.gameObject);
				//playerKilled = true;
				//gameObject.GetComponentInParent<SCR_NewMonster> ().mAnimator.Play ("ANIM_Monster_Idle_Blood_Left");
				//gameObject.GetComponentInParent<SCR_NewMonster> ().mAnimator.SetBool ("bloodFinished", true);
			}

		} 
	}
}
