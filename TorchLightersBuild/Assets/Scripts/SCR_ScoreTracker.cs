using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* Class Name
* SCR_ScoreTracker
* 
* ==========
* 
* Created: 08/11/2017
* Author(s): Sebastian Poskitt-Marshall
*
* Purpose:
* Functionality for tracking progress in each level by caluclating the
* percentage of each goal that has been achieved.
* 
*/

public class SCR_ScoreTracker : MonoBehaviour {
	[Header("Completion Percentages")]
	public float torchCompletionPercentage = 50.0f;
	public float bloodCompletionPercentage = 60.0f;
	public float chestCompletionPercentage = 30.0f;
	public float corpseCompletionPercentage = 80.0f;
	[Header("UI Objects")]
	public Text torchUiText;
	public Text trapUiText;
	public Text bloodUiText;
	public Text chestUiText;
	public Text corpseUiText;
	[Header("Object Lists")]
	public List<GameObject> torchList;
	public List<GameObject> trapList;
	public List<GameObject> bloodList;
	public List<GameObject> chestList;
	public List<GameObject> corpseList;

	// Privates
	int originalMaxBlood = 0;
	int originalMaxCorpses = 0;

	// Use this for initialization
	void Start () {
		// Populate the object lists with all of the objects in the level
		populateObjectLists ();
	}
	
	// Update is called once per frame
	void Update () {
		calculatePercentages ();
	}
		
	void populateObjectLists() {
		// Call relevant functions to populate all lists
		populateTorchList ();
		populateTrapList ();
		populateBloodList ();
		populateChestList ();
		populateCorpseList ();

		// Update the max blood variable
		originalMaxBlood = bloodList.Count;
		originalMaxCorpses = corpseList.Count;
	}

	void calculatePercentages() {
		calculateTorchPercentages ();
		calculateBloodPercentages ();
		calculateChestPercentages ();
		calculateCorpsePercentages ();
	}

	void populateTorchList() {
		// Get a temporary array of all torches in the level
		GameObject[] tempList = GameObject.FindGameObjectsWithTag ("Torch");

		// Loop through the array and add each object to the torch list
		for (int i = 0; i < tempList.Length; i++) {
			torchList.Add (tempList [i]);
		}
	}

	void populateTrapList() {
	}

	void populateBloodList() {
		// Get a temporary array of all blood stains in the level
		GameObject[] tempList = GameObject.FindGameObjectsWithTag ("Blood");

		// Loop through the array and add each object to the blood list
		for (int i = 0; i < tempList.Length; i++) {
			bloodList.Add (tempList [i]);
		}
	}

	void populateChestList() {
		// Get a temporary array of all chests in the level
		GameObject[] tempList = GameObject.FindGameObjectsWithTag ("Chest");

		// Loop through the array and add each object to the blood list
		for (int i = 0; i < tempList.Length; i++) {
			chestList.Add (tempList [i]);
		}
	}

	void populateCorpseList() {
		// Get a temporary array of all corpses in the level
		GameObject[] tempList = GameObject.FindGameObjectsWithTag ("Corpse");

		// Loop through the array and add each object to the blood list
		for (int i = 0; i < tempList.Length; i++) {
			corpseList.Add (tempList [i]);
		}
	}

	void calculateTorchPercentages() {
		int torchesLit = 0;

		for (int i = 0; i < torchList.Count; i++) {
			if (torchList [i].GetComponent<SCR_Torch> ().torchLit) {
				// Increment the torch lit variable by 1
				torchesLit += 1;
			}
		}

		// Calculate the percentage of torches lit
		float torchPercentage = ((float)torchesLit / torchList.Count) * 100.0f;

		// Update the UI text colour to illustrate if a goal has been met
		if (torchPercentage < torchCompletionPercentage) {
			torchUiText.color = new Color (1.0f, 0.0f, 0.0f);
		} else {
			torchUiText.color = new Color (0.0f, 1.0f, 0.0f);
		}


		// Update the UI text to display the new percentage
		torchUiText.text = Mathf.Round(torchPercentage).ToString() + "%/" + torchCompletionPercentage.ToString () + "%";
	}

	void calculateBloodPercentages() {
		// Clear the blood list
		bloodList.Clear();

		// Repopulate the blood list
		populateBloodList();

		int bloodCleaned = originalMaxBlood - bloodList.Count;

		// Caluclate the percentage of cleaned blood
		float bloodPercentage = ((float)bloodCleaned / (float)originalMaxBlood) * 100.0f;

		// Update the UI text colout to illustrate if a goal has been met
		if (bloodPercentage < bloodCompletionPercentage) {
			bloodUiText.color = new Color (1.0f, 0.0f, 0.0f);
		} else {
			bloodUiText.color = new Color (0.0f, 1.0f, 0.0f);
		}


		// Update the UI text to display the new percentage
		bloodUiText.text = Mathf.Round(bloodPercentage).ToString() + "%/" + bloodCompletionPercentage.ToString () + "%";

	}

	void calculateChestPercentages() {
		int chestsFilled = 0;

		for (int i = 0; i < chestList.Count; i++) {
			if (chestList [i].GetComponent<SCR_Chest> ().chestRefilled) {
				// Increment the torch lit variable by 1
				chestsFilled += 1;
			}
		}

		// Calculate the percentage of chests filled
		float chestPercentage = ((float)chestsFilled / chestList.Count) * 100.0f;

		// Update the UI text colour to illustrate if a goal has been met
		if (chestPercentage < chestCompletionPercentage) {
			chestUiText.color = new Color (1.0f, 0.0f, 0.0f);
		} else {
			chestUiText.color = new Color (0.0f, 1.0f, 0.0f);
		}


		// Update the UI text to display the new percentage
		chestUiText.text = Mathf.Round(chestPercentage).ToString() + "%/" + chestCompletionPercentage.ToString () + "%";
	}

	void calculateCorpsePercentages() {
		// Clear the corpse list
		corpseList.Clear();

		// Repopulate the corpse list
		populateCorpseList();

		int corpsesCleaned = originalMaxCorpses - corpseList.Count;

		// Caluclate the percentage of cleaned blood
		float corpsePercentage = ((float)corpsesCleaned / (float)originalMaxCorpses) * 100.0f;

		// Update the UI text colout to illustrate if a goal has been met
		if (corpsePercentage < corpseCompletionPercentage) {
			corpseUiText.color = new Color (1.0f, 0.0f, 0.0f);
		} else {
			corpseUiText.color = new Color (0.0f, 1.0f, 0.0f);
		}


		// Update the UI text to display the new percentage
		corpseUiText.text = Mathf.Round(corpsePercentage).ToString() + "%/" + corpseCompletionPercentage.ToString () + "%";
	}
}
