using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Chest : MonoBehaviour {

	public Sprite chestOpenSprite, chestClosedSprite;

	// Refills chest
	public void refillChest(){
		GetComponent<SpriteRenderer> ().sprite = chestClosedSprite;
        AkSoundEngine.PostEvent("Refill_Chest", gameObject);
	}
}
