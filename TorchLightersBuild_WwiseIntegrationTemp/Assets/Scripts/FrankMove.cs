using UnityEngine;
using System.Collections;

public class FrankMove : MonoBehaviour
{
	private Rigidbody2D myRigid;
	private Animator myAnimator;


	float moveSpeed = 2.0f;
	private bool facingRight;

	public static bool usingLanturn;
	bool moving_;

	bool dashright_ = false;
	Vector2 forceright = new Vector2 (2000.0f, 0.0f);
	float dashRightTimer = 2.0f;



	bool dashleft_ = false;
	Vector2 forceleft = new Vector2 (-2000.0f, 0.0f);

	bool dashup_ = false;
	Vector2 forceup = new Vector2 (0.0f, 2000.0f);

	bool dashdown_ = false;
	Vector2 forcedown = new Vector2 (0.0f, -2000.0f);


	// Use this for initialization
	void Start () 
	{
		//allows us to access franks rigidbody2D
		myRigid = GetComponent<Rigidbody2D> ();
		facingRight = true;
		usingLanturn = false;
		moving_ = true;
		myAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log (myRigid.position);

	}

	//works with physics (called at fixed time)
	void FixedUpdate()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");


		if (dashright_ == false && dashleft_ == false && dashup_ == false && dashdown_ == false)
		{
			Controls (horizontal, vertical);
		} else
		{
			//dash stuff
			if (dashright_ == true)
			{
				myRigid.AddForce(forceright);
				dashRightTimer -= Time.deltaTime;
                AkSoundEngine.PostEvent("Dash", gameObject);


                if (dashRightTimer <= 0)
				{
					dashright_ = false;
					dashRightTimer = 1.0f;

                }
            }

			if(dashleft_ == true)
			{
				myRigid.AddForce(forceleft);
				dashleft_ = false;
			}

			if (dashup_ == true)
			{
				myRigid.AddForce (forceup);
				dashup_ = false;
			}

			if (dashdown_ == true)
			{
				myRigid.AddForce (forcedown);
				dashdown_ = false;
			}
		}

		Flip (horizontal);
		Dash (horizontal, vertical);

	}

	//might change the way movement is done
	private void Controls(float horizontal, float vertical)
	{
		//Debug.Log (horizontal);

		if (moving_ == true)
		{
			myRigid.velocity = new Vector2 (horizontal * moveSpeed, vertical * moveSpeed);
		} 

		//play the moving animation when moving left and right
		if (horizontal != 0.0f)
		{
			//plays the moving left and right animation when you move left or right
			myAnimator.SetFloat ("Speed", Mathf.Abs (horizontal));
		} 

		//AND UP AND DOWN!
		if (vertical != 0.0f)
		{
			myAnimator.SetFloat ("Speed", Mathf.Abs (vertical));
		} 


		//use lanturn
		if (Input.GetKey (KeyCode.L))
		{
			myAnimator.SetBool ("fire", true);
			usingLanturn = true;
			myRigid.velocity = new Vector2 (0.0f, 0.0f);
			moving_ = false;
		} else
		{
			myAnimator.SetBool ("fire", false);
			usingLanturn = false;
			moving_ = true;
		}

	}

	//flip the sprie depending on direction moving
	private void Flip(float horizontal)
	{
		if (horizontal < 0 && facingRight || horizontal > 0 && !facingRight)
		{
			//flip the x scale of the transform, turns the sprite around
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	//dash
	private void Dash(float horizontal, float vertical)
	{
		//dash (need a way to store the direction i'm moving and use that as dash direction) basically cant dash in diagonals
		//moving right

		if (Input.GetKeyDown (KeyCode.Space) && horizontal > 0.0f)
		{
			dashright_ = true;
			dashRightTimer -= dashRightTimer;
		}


		//moving left
		if (Input.GetKeyDown (KeyCode.Space) && horizontal < 0.0f)
		{
			//myRigid.velocity = new Vector2 (-5.0f, 0.0f);
			dashleft_ = true;
		}


		//moving up
		if (Input.GetKeyDown (KeyCode.Space) && vertical > 0.0f)
		{
			dashup_ = true;
		}

		//moving down
		if (Input.GetKeyDown (KeyCode.Space) && vertical < 0.0f)
		{
			dashdown_ = true;
		}
	}


}


