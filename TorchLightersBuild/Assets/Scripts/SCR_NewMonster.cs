using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_NewMonster : MonoBehaviour 
{
	public GameObject Player1;
	public GameObject Player2;

	public Animator mAnimator;

	//bool directionLeft = false;

	AnimatorStateInfo animStateInfo;

	public bool playerKilled = false;


	public bool facingLeft = false;

	public Vector3 prevVel = Vector3.zero;

	public Vector3 PrevPosition;

	// Use this for initialization
	void Start () 
	{
		mAnimator = GetComponent<Animator> ();

		Player1 = GameObject.FindGameObjectsWithTag ("Player") [0];
		Player2 = GameObject.FindGameObjectsWithTag ("Player") [1];
	}
	
	// Update is called once per frame
	void Update () 
	{
		//THIS WONT WORK BECAUSE EVEN IF ITS MOVING RIGHT (FROM THE LEFT the x IS STILL < 0 ) YA TIT!
		//determine which way the monster is moving
		//PrevPosition = gameObject.transform.position;

		Vector3 curVel = (transform.position - prevVel) / Time.deltaTime;

		if (curVel.x > 0)
		{
			facingLeft = false;
		} else 
		{
			facingLeft = true;
		}
		prevVel = transform.position;

//		PrevPosition = gameObject.transform.position;
//
//		//maybe?
//		if (curVel.x >= PrevPosition.x)
//		{
//			facingLeft = false;
//		} else
//		{
//			facingLeft = true;
//		}



		//temp code for moving a monster outside of the bounds colliders.
		//Delete after monster is fully functional 
		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			Vector3 position = this.transform.position;
			position.x++;
			this.transform.position = position;
			facingLeft = false;
		}

		if (Input.GetKeyDown (KeyCode.UpArrow))
		{
			Vector3 position = this.transform.position;
			position.y++;
			this.transform.position = position;
			facingLeft = true;
		}

		/////////////////////////////////////////////////////


		animStateInfo = mAnimator.GetCurrentAnimatorStateInfo (0);
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			//play the attacking animation
			//mAnimator.SetBool ("PlayerInRange", true);

			if (facingLeft == false)
			{
				mAnimator.Play ("ANIM_Monster_Attack_Right");
			} else
			{
				mAnimator.Play ("ANIM_Monster_Attack_Left");
			}

		} 

	}
}
