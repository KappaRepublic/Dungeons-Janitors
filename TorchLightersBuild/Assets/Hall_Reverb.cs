using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnterReverbZoneHall : MonoBehaviour
{
    public void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.name == "Camera")
        {
            AkSoundEngine.SetState("Reverb_Zone", "Large");
        }
    }
}