using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SCR_PressurePlate : MonoBehaviour 
{
	/*
* Class Name
* PressurePlate Script
* 
* ==========
* 
* Created: 05/10/17
* Base Class: (If applicable) Name of the base class.
* Author(s): Rory McLean
*
* Purpose: The purpose of this file.
* Functionality for the pressureplate attached to the wall trap. 
* when you hit the pressureplate the wall trap will fire
*/

	public GameObject bulletPrefab;
	public GameObject wallTrap;
	float bulletImpulse = 5.0f;
	GameObject theBullet;

	public Sprite downPlate;
	public Sprite upPlate;

	public float rotation = 0.0f;

	public bool platePressed;

	// Use this for initialization
	void Start () 
	{
		platePressed = true;
	}

	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player" && platePressed == false)
		{
			if (!coll.gameObject.GetComponent<SCR_Player> ().dodging) {
				platePressed = true;
	
				AkSoundEngine.PostEvent ("Pull_Lever", gameObject);
			
				wallTrap.GetComponent<Animator> ().Play ("ANIM_WallGun_Empty");

				//theBullet = (GameObject)Instantiate (Resources.Load ("Bullet"), wallTrap.transform.position + wallTrap.transform.forward, wallTrap.transform.rotation);

				//spawn a bullet, place it on top of the walltrap, move it "forward"
				theBullet = (GameObject)Instantiate (bulletPrefab, wallTrap.transform.position + wallTrap.transform.forward, wallTrap.transform.rotation);
				theBullet.transform.Rotate(new Vector3(0.0f, 0.0f, rotation));

				theBullet.GetComponent<Rigidbody2D> ().AddForce (-(theBullet.transform.up * bulletImpulse), ForceMode2D.Impulse);
				AkSoundEngine.PostEvent ("Arrow_Fire", gameObject);

				this.GetComponent<SpriteRenderer> ().sprite = downPlate;
			}
				
        }

    }

	public void setUpPosition() {
		this.GetComponent<SpriteRenderer> ().sprite = upPlate;
	}
}
