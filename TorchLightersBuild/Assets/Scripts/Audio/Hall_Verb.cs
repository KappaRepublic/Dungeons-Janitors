using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hall_Verb : MonoBehaviour {

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")

   
            {
            
                AkSoundEngine.SetState("Reverb_Zone", "Hall");
           
            }
        }
    
}
