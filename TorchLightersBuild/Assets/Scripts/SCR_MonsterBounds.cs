using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MonsterBounds : MonoBehaviour 
{

	//lerp functionality found at:
	//http://www.blueraja.com/blog/4-4/how-to-use-unity-3ds-linear-interpolation-vector3-lerp-correctly
	public GameObject Monster;
	bool leftBounds = false;


	float timeTakenDuringLerp = 1.0f;

	bool _isLerping;
	Vector3 _startPosition;
	Vector3 _endPosition;
	float _timeStartedLerping;

	void StartLerping()
	{
		_isLerping = true;
		_timeStartedLerping = Time.time;

		//we set the start position to the current position, and the finish to be the center of the bounds
		_startPosition = Monster.transform.position;
		_endPosition = new Vector3(gameObject.transform.position.x,
			gameObject.transform.position.y,
			gameObject.transform.position.z);
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//when the monster leaves the bounds, start lerping
		if(leftBounds == true)
		{
			/*Monster.transform.position = new Vector3 (gameObject.transform.position.x,
				gameObject.transform.position.y,
				gameObject.transform.position.z);*/
			StartLerping ();
			leftBounds = false;
		}
	}

	void FixedUpdate()
	{
		if (_isLerping)
		{
			// we want percentage = 0.0 when Time.time = _timeStartedLerping
			//and percentage = 1.0 when Time.time = _timeStartedLerping + timeTakenDuringLerp
			//in other words, we want to know what percentage of "timeTakenDuringLerp" the value
			//"Time.time - timeStartedLerping" is.
			float timeSinceStarted = Time.time - _timeStartedLerping;
			float percentageComplete = timeSinceStarted / timeTakenDuringLerp;

			//preform the actual lerp
			Monster.transform.position = Vector3.Lerp (_startPosition, _endPosition, percentageComplete);

			if (percentageComplete >= 1.0f)
			{
				_isLerping = false;
			}

		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Monster")
		{
			Debug.Log ("monster has left bounds");
			leftBounds = true;
		}
	}

}
