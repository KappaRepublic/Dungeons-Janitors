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
	public float trapCompletionPercentage = 70.0f;
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
	[Header("End Level Gate")]
	public GameObject endLevelGate;

	// Privates
	int originalMaxBlood = 0;
	int originalMaxCorpses = 0;

	bool torchComplete;
	bool trapComplete;
	bool bloodComplete;
	bool chestComplete;
	bool corpseComplete;

	// Use this for initialization
	void Start () {
		// Populate the object lists with all of the objects in the level
		populateObjectLists ();
	}
	
	// Update is called once per frame
	void Update () {
		calculatePercentages ();
		checkEndConditions ();
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
		calculateTrapPercentages ();
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
		// Spike levers
		GameObject[] tempLevers = GameObject.FindGameObjectsWithTag("Lever");
		// Wall traps
		GameObject[] tempWallTraps = GameObject.FindGameObjectsWithTag("PressurePlate");
		// Floor traps
		GameObject[] tempFloorTraps = GameObject.FindGameObjectsWithTag("TrapDoor");

		// Add all of the traps to the trap list
		for (int i = 0; i < tempLevers.Length; i++) {
			trapList.Add (tempLevers [i]);
		}

		for (int i = 0; i < tempWallTraps.Length; i++) {
			trapList.Add (tempWallTraps [i]);
		}

		for (int i = 0; i < tempFloorTraps.Length; i++) {
			trapList.Add (tempFloorTraps [i]);
		}
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
			torchComplete = false;
		} else {
			torchUiText.color = new Color (0.0f, 1.0f, 0.0f);
			torchComplete = true;
		}


		// Update the UI text to display the new percentage
		torchUiText.text = Mathf.Round(torchPercentage).ToString() + "%/" + torchCompletionPercentage.ToString () + "%";
	}
		
	void calculateTrapPercentages() {
		int trapsCleared = 0;

		for (int i = 0; i < trapList.Count; i++) {
			if (trapList [i].tag == "Lever") {
				if (trapList [i].GetComponent<SCR_SpikeLever> ().activated) {
					trapsCleared++;
				}
			}
			if (trapList [i].tag == "PressurePlate") {
				if (!trapList [i].GetComponent<SCR_PressurePlate> ().platePressed) {
					trapsCleared++;
				}
			}
			if (trapList [i].tag == "TrapDoor") {
				if (trapList [i].GetComponent<SCR_TrapDoor> ().trapReset) {
					trapsCleared++;
				}
			}
		}

		// Calculate the percentage of traps cleared
		float trapPercentage = ((float)trapsCleared / trapList.Count) * 100.0f;

		// Update the UI text colour to illustrate if a goal has been met
		if (trapPercentage < trapCompletionPercentage) {
			trapUiText.color = new Color (1.0f, 0.0f, 0.0f);
			trapComplete = false;
		} else {
			trapUiText.color = new Color (0.0f, 1.0f, 0.0f);
			trapComplete = true;
		}

		// Update the UI text to display the new percentage
		trapUiText.text = Mathf.Round(trapPercentage).ToString() + "%/" + trapCompletionPercentage.ToString() + "%";
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
			bloodComplete = false;
		} else {
			bloodUiText.color = new Color (0.0f, 1.0f, 0.0f);
			bloodComplete = true;
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
			chestComplete = false;
		} else {
			chestUiText.color = new Color (0.0f, 1.0f, 0.0f);
			chestComplete = true;
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
			corpseComplete = false;
		} else {
			corpseUiText.color = new Color (0.0f, 1.0f, 0.0f);
			corpseComplete = true;
		}


		// Update the UI text to display the new percentage
		corpseUiText.text = Mathf.Round(corpsePercentage).ToString() + "%/" + corpseCompletionPercentage.ToString () + "%";
	}

	void checkEndConditions() {
		if (torchComplete && trapComplete && bloodComplete && chestComplete && corpseComplete) {
			endLevelGate.SetActive (true);
		} else {
			endLevelGate.SetActive (false);
		}
	}
}
