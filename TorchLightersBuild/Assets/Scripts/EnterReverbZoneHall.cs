using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnterReverbZoneHall : MonoBehaviour
{
	public enum RoomSize
	{
		Large,
		Medium,
		Small,
		Hall
	}

	public RoomSize roomSize;

    public void OnTriggerEnter2D(Collider2D col)
    {
		
        if (col.gameObject.tag == "Player")
        {
			Debug.Log ("It's working I guess");
			switch (roomSize) {
			case RoomSize.Small:
				AkSoundEngine.SetState ("Reverb_Zone", "Small");
				Debug.Log ("Small");
				break;
			case RoomSize.Medium:
				AkSoundEngine.SetState ("Reverb_Zone", "Medium");
				Debug.Log ("Medium");
				break;
			case RoomSize.Large:
				AkSoundEngine.SetState ("Reverb_Zone", "Large");
				Debug.Log ("Large");
				break;
			case RoomSize.Hall:
				AkSoundEngine.SetState ("Reverb_Zone", "Hall");
				Debug.Log ("Hall");
				break;
			default:
				break;
			}



        }
    }
}