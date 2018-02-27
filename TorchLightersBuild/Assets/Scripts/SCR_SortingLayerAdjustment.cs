using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_SortingLayerAdjustment : MonoBehaviour {

	SpriteRenderer sprRen;

	void Start() {
		sprRen = GetComponent<SpriteRenderer> ();
	}

	void LateUpdate() {

		if (sprRen.isVisible) {
			sprRen.sortingOrder = (int)Camera.main.WorldToScreenPoint (sprRen.bounds.min).y * -1 + 285;
		}
	}
}
