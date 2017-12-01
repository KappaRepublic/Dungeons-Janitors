using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MopDirection : MonoBehaviour {

	Vector3 mousePos;
	Vector3 objectPos;
	float angle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mouseWorldPosition - transform.position);

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Blood") {
			Destroy (col.gameObject);
		}
	}
}
