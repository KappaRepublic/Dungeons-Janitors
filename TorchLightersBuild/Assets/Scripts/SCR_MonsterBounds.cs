using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MonsterBounds : MonoBehaviour 
{
	//lerp functionality found at:
	//http://www.blueraja.com/blog/4-4/how-to-use-unity-3ds-linear-interpolation-vector3-lerp-correctly
	public GameObject Monster;
	public GameObject Player;
	public GameObject Player2;

	bool leftBounds = false;
	public bool player1EnteredBounds = false;
	public bool player2EnteredBounds = false;


	float timeTakenDuringLerp = 1.0f;

	bool _isLerping;
	Vector3 _startPosition;
	Vector3 _endPosition;
	float _timeStartedLerping;


	void StartLerping()
	{
		//Debug.Log ("going to center");
		_isLerping = true;
		_timeStartedLerping = Time.time;

		//	gameObject.GetComponentInChildren<SCR_NewMonster> ().facingLeft);
		//depending on which way the player is facing, change animation
		if (gameObject.GetComponentInChildren<SCR_NewMonster> ().facingLeft == false)
		{
			Debug.Log ("LEFT");
			//gameObject.GetComponentInChildren<SCR_NewMonster> ().mAnimator.SetBool ("LeftToRight", true);
			gameObject.GetComponentInChildren<SCR_NewMonster> ().mAnimator.SetBool ("moveLeft", true);
			gameObject.GetComponentInChildren<SCR_NewMonster> ().mAnimator.SetBool ("moveRight", false);
		} else
		{
			Debug.Log ("RIGHT");
			//gameObject.GetComponentInChildren<SCR_NewMonster> ().mAnimator.SetBool ("RightToLeft", true);
			gameObject.GetComponentInChildren<SCR_NewMonster> ().mAnimator.SetBool ("moveRight", true);
			gameObject.GetComponentInChildren<SCR_NewMonster> ().mAnimator.SetBool ("moveLeft", false);
		}

		//we set the start position to the current position, and the finish to be the center of the bounds
		_startPosition = Monster.transform.position;
		_endPosition = new Vector3(gameObject.transform.position.x,
			gameObject.transform.position.y,
			gameObject.transform.position.z);
	}

	void StartLerpingPlayer()
	{
		_isLerping = true;
		_timeStartedLerping = Time.time;

		_startPosition = Monster.transform.position;

		//if player one enters, move towards player 1
		if (player1EnteredBounds == true)
		{
//			Debug.Log ("monster is facing" +
//				gameObject.GetComponentInChildren<SCR_NewMonster> ().facingLeft);
			//depending on which way the player is facing, change animation
			if (gameObject.GetComponentInChildren<SCR_NewMonster> ().facingLeft == false)
			{
				gameObject.GetComponentInChildren<SCR_NewMonster> ().mAnimator.SetBool ("moveRight", true);
				gameObject.GetComponentInChildren<SCR_NewMonster> ().mAnimator.SetBool ("moveLeft", false);
			} else
			{
				gameObject.GetComponentInChildren<SCR_NewMonster> ().mAnimator.SetBool ("moveLeft", true);
				gameObject.GetComponentInChildren<SCR_NewMonster> ().mAnimator.SetBool ("moveRight", false);
			}
				

			_endPosition = new Vector3 (Player.transform.position.x,
				Player.transform.position.y,
				Player.transform.position.z);


		} else if (player2EnteredBounds == true)
		{
			_endPosition = new Vector3 (Player2.transform.position.x,
				Player2.transform.position.y,
				Player2.transform.position.z);
		}
	}

	// Use this for initialization
	void Start () 
	{
		Player = GameObject.FindGameObjectsWithTag ("Player") [0];
		Player2 = GameObject.FindGameObjectsWithTag("Player")[1];
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		//when the monster leaves the bounds, start lerping

		if(leftBounds == true)
		{
			StartLerping ();
			leftBounds = false;
		}


		//when the player enters the bounds
		if (player1EnteredBounds == true)
		{
			StartLerpingPlayer ();
			player1EnteredBounds = false;

		} 

		if (player2EnteredBounds == true)
		{
			StartLerpingPlayer ();
			player2EnteredBounds = false;
		}

	}

	void FixedUpdate()
	{

		//bool playerDead = gameObject.GetComponentInChildren<SCR_MonsterKill> ().playerKilled;

		bool playerDead = Player.GetComponent<SCR_Player> ().getIsDead ();

		if (_isLerping)
		{
			// we want percentage = 0.0 when Time.time = _timeStartedLerping
			//and percentage = 1.0 when Time.time = _timeStartedLerping + timeTakenDuringLerp
			//in other words, we want to know what percentage of "timeTakenDuringLerp" the value
			//"Time.time - timeStartedLerping" is.
			float timeSinceStarted = Time.time - _timeStartedLerping;
			float percentageComplete = timeSinceStarted / timeTakenDuringLerp;


			//preform the actual lerp

			//README would you do the "if your killed stop moving, play animation then start moving" thing here? maybe...

			if (playerDead == true)
			{
				
				//Debug.Log ("Player dead is: " + playerDead);
				gameObject.GetComponentInChildren<SCR_NewMonster> ().mAnimator.Play ("ANIM_Monster_Idle_Blood_Left");
				gameObject.GetComponentInChildren<SCR_NewMonster> ().mAnimator.SetBool ("bloodFinished", true);
				//playerDead = false;

			}else
			{
				Monster.transform.position = Vector3.Lerp (_startPosition, _endPosition, percentageComplete);

				if (percentageComplete >= 1.0f)
				{
					_isLerping = false;
				}
			}



		} else
		{
			gameObject.GetComponentInChildren<SCR_NewMonster> ().mAnimator.SetBool ("moveRight", false);
			gameObject.GetComponentInChildren<SCR_NewMonster> ().mAnimator.SetBool ("moveLeft", false);
			gameObject.GetComponentInChildren<SCR_NewMonster> ().mAnimator.SetBool ("LeftToRight", false);
			gameObject.GetComponentInChildren<SCR_NewMonster> ().mAnimator.SetBool ("LeftToRight", false);
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Monster")
		{
			//Debug.Log ("monster has left bounds");
			leftBounds = true;
		}

		if (col.gameObject.tag == "Player")
		{
			leftBounds = true;
		}
	}



	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			if (col.gameObject.GetComponent<SCR_Player> ().player2)
			{
				player2EnteredBounds = true;
			} else
			{
				player1EnteredBounds = true;
			}
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.GetComponent<SCR_Player> ().player2)
		{
			player2EnteredBounds = true;
		} else
		{
			player1EnteredBounds = true;
		}
	}

}
