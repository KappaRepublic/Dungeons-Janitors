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

public class SCR_ScoreTracker : MonoBehaviour
{
    [Header("Completion Percentages")]
    public float torchCompletionPercentage = 50.0f;
    public float trapCompletionPercentage = 70.0f;
    public float bloodCompletionPercentage = 60.0f;
    public float chestCompletionPercentage = 30.0f;
    public float corpseCompletionPercentage = 80.0f;
    [Header("UI Objects")]
    [Header("Torch UI")]
    public Image torchUiBar;
    public GameObject torchGoalIndicator;
    [Header("Trap UI")]
    public Image trapUiBar;
    public GameObject trapGoalIndicator;
    [Header("Blood UI")]
    public Image bloodUiBar;
    public GameObject bloodGoalIndicator;
    [Header("Chest UI")]
    public Image chestUiBar;
    public GameObject chestGoalIndicator;
    [Header("Corpse UI")]
    public Image corpseUiBar;
    public GameObject corpseGoalIndicator;
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

    float finalPercentage;

    // Use this for initialization
    void Start()
    {

        setupUiComponents();
        // Populate the object lists with all of the objects in the level
        populateObjectLists();
    }

    // Update is called once per frame
    void Update()
    {
        calculatePercentages();
        checkEndConditions();
    }

    void setupUiComponents()
    {
        torchGoalIndicator.transform.Translate(new Vector3((69.0f / 100.0f) * torchCompletionPercentage, 0.0f, 0.0f));
        trapGoalIndicator.transform.Translate(new Vector3((69.0f / 100.0f) * trapCompletionPercentage, 0.0f, 0.0f));
        bloodGoalIndicator.transform.Translate(new Vector3((69.0f / 100.0f) * bloodCompletionPercentage, 0.0f, 0.0f));
        chestGoalIndicator.transform.Translate(new Vector3((69.0f / 100.0f) * chestCompletionPercentage, 0.0f, 0.0f));
        corpseGoalIndicator.transform.Translate(new Vector3((69.0f / 100.0f) * corpseCompletionPercentage, 0.0f, 0.0f));
    }

    void populateObjectLists()
    {
        // Call relevant functions to populate all lists
        populateTorchList();
        populateTrapList();
        populateBloodList();
        populateChestList();
        populateCorpseList();

        // Update the max blood variable
        originalMaxBlood = bloodList.Count;
        originalMaxCorpses = corpseList.Count;
    }

    void calculatePercentages()
    {
        calculateTorchPercentages();
        calculateTrapPercentages();
        calculateBloodPercentages();
        calculateChestPercentages();
        calculateCorpsePercentages();
    }

    void populateTorchList()
    {
        // Get a temporary array of all torches in the level
        GameObject[] tempList = GameObject.FindGameObjectsWithTag("Torch");

        // Loop through the array and add each object to the torch list
        for (int i = 0; i < tempList.Length; i++)
        {
            torchList.Add(tempList[i]);
        }
    }

    void populateTrapList()
    {
        // Spike levers
        GameObject[] tempSpikes = GameObject.FindGameObjectsWithTag("Spike");
        // Wall traps
        GameObject[] tempWallTraps = GameObject.FindGameObjectsWithTag("PressurePlate");
        // Floor traps
        GameObject[] tempFloorTraps = GameObject.FindGameObjectsWithTag("TrapDoor");

        // Add all of the traps to the trap list
        for (int i = 0; i < tempSpikes.Length; i++)
        {
            trapList.Add(tempSpikes[i]);
        }

        for (int i = 0; i < tempWallTraps.Length; i++)
        {
            trapList.Add(tempWallTraps[i]);
        }

        for (int i = 0; i < tempFloorTraps.Length; i++)
        {
            trapList.Add(tempFloorTraps[i]);
        }
    }

    void populateBloodList()
    {
        // Get a temporary array of all blood stains in the level
        GameObject[] tempList = GameObject.FindGameObjectsWithTag("Blood");

        // Loop through the array and add each object to the blood list
        for (int i = 0; i < tempList.Length; i++)
        {
            bloodList.Add(tempList[i]);
        }
    }

    void populateChestList()
    {
        // Get a temporary array of all chests in the level
        GameObject[] tempList = GameObject.FindGameObjectsWithTag("Chest");

        // Loop through the array and add each object to the blood list
        for (int i = 0; i < tempList.Length; i++)
        {
            chestList.Add(tempList[i]);
        }
    }

    void populateCorpseList()
    {
        // Get a temporary array of all corpses in the level
        GameObject[] tempList = GameObject.FindGameObjectsWithTag("Corpse");

        // Loop through the array and add each object to the blood list
        for (int i = 0; i < tempList.Length; i++)
        {
            corpseList.Add(tempList[i]);
        }
    }

    void calculateTorchPercentages()
    {
        int torchesLit = 0;

        for (int i = 0; i < torchList.Count; i++)
        {
            if (torchList[i].GetComponent<SCR_Torch>().torchLit)
            {
                // Increment the torch lit variable by 1
                torchesLit += 1;
            }
        }

        // Calculate the percentage of torches lit
        float torchPercentage = ((float)torchesLit / torchList.Count) * 100.0f;

        // Update the UI text colour to illustrate if a goal has been met
        if (torchPercentage < torchCompletionPercentage)
        {
            torchUiBar.color = new Color(0.639f, 0.349f, 0.380f, 1.0f);
            torchComplete = false;
        }
        else if (torchPercentage >= torchPercentage && torchPercentage < 100.0f)
        {
            torchUiBar.color = new Color(0.486f, 0.819f, 0.290f, 1.0f);
            torchComplete = true;
        }
        else
        {
            torchUiBar.color = new Color(0.368f, 0.717f, 0.858f, 1.0f);
        }

        // Update the torch ui bar
        torchUiBar.fillAmount = (torchPercentage / 100.0f);

        // Update the UI text to display the new percentage
    }

    void calculateTrapPercentages()
    {
        int trapsCleared = 0;

        for (int i = 0; i < trapList.Count; i++)
        {
            if (trapList[i].tag == "Spike")
            {
                if (!trapList[i].GetComponent<SCR_Spikes>().activated)
                {
                    Debug.Log("SPIKES");
                    trapsCleared++;
                }
            }
            if (trapList[i].tag == "PressurePlate")
            {
                if (!trapList[i].GetComponent<SCR_PressurePlate>().platePressed)
                {
                    trapsCleared++;
                }
            }
            if (trapList[i].tag == "TrapDoor")
            {
                if (trapList[i].GetComponent<SCR_TrapDoor>().trapReset)
                {
                    trapsCleared++;
                }
            }
        }

        // Calculate the percentage of traps cleared
        float trapPercentage = ((float)trapsCleared / trapList.Count) * 100.0f;

        // Update the UI text colour to illustrate if a goal has been met
        if (trapPercentage < trapCompletionPercentage)
        {
            trapUiBar.color = new Color(0.639f, 0.349f, 0.380f, 1.0f);
            trapComplete = false;
        }
        else if (trapPercentage >= trapPercentage && trapPercentage < 100.0f)
        {
            trapUiBar.color = new Color(0.486f, 0.819f, 0.290f, 1.0f);
            trapComplete = true;
        }
        else
        {
            trapUiBar.color = new Color(0.368f, 0.717f, 0.858f, 1.0f);
        }

        // Update the trap ui bar
        trapUiBar.fillAmount = (trapPercentage / 100.0f);

    }

    void calculateBloodPercentages()
    {
        // Clear the blood list
        bloodList.Clear();

        // Repopulate the blood list
        populateBloodList();

        int bloodCleaned = originalMaxBlood - bloodList.Count;

        // Caluclate the percentage of cleaned blood
        float bloodPercentage = ((float)bloodCleaned / (float)originalMaxBlood) * 100.0f;

        // Update the UI text colout to illustrate if a goal has been met
        if (bloodPercentage < bloodCompletionPercentage)
        {
            bloodUiBar.color = new Color(0.639f, 0.349f, 0.380f, 1.0f);
            bloodComplete = false;
        }
        else if (bloodPercentage >= bloodPercentage && bloodPercentage < 100.0f)
        {
            bloodUiBar.color = new Color(0.486f, 0.819f, 0.290f, 1.0f);
            bloodComplete = true;
        }
        else
        {
            bloodUiBar.color = new Color(0.368f, 0.717f, 0.858f, 1.0f);
        }

        // Update the blood ui bar
        bloodUiBar.fillAmount = (bloodPercentage / 100.0f);

    }

    void calculateChestPercentages()
    {
        int chestsFilled = 0;

        for (int i = 0; i < chestList.Count; i++)
        {
            if (chestList[i].GetComponent<SCR_Chest>().chestRefilled)
            {
                // Increment the torch lit variable by 1
                chestsFilled += 1;
            }
        }

        // Calculate the percentage of chests filled
        float chestPercentage = ((float)chestsFilled / chestList.Count) * 100.0f;

        // Update the UI text colour to illustrate if a goal has been met
        if (chestPercentage < chestCompletionPercentage)
        {
            chestUiBar.color = new Color(0.639f, 0.349f, 0.380f, 1.0f);
            chestComplete = false;
        }
        else if (chestPercentage >= chestPercentage && chestPercentage < 100.0f)
        {
            chestUiBar.color = new Color(0.486f, 0.819f, 0.290f, 1.0f);
            chestComplete = true;
        }
        else
        {
            chestUiBar.color = new Color(0.368f, 0.717f, 0.858f, 1.0f);
        }

        // Update the chest ui bar
        chestUiBar.fillAmount = (chestPercentage / 100.0f);


    }

    void calculateCorpsePercentages()
    {
        // Clear the corpse list
        corpseList.Clear();

        // Repopulate the corpse list
        populateCorpseList();

        int corpsesCleaned = originalMaxCorpses - corpseList.Count;

        // Caluclate the percentage of cleaned blood
        float corpsePercentage = ((float)corpsesCleaned / (float)originalMaxCorpses) * 100.0f;

        // Update the UI text colout to illustrate if a goal has been met
        if (corpsePercentage < corpseCompletionPercentage)
        {
            corpseUiBar.color = new Color(0.639f, 0.349f, 0.380f, 1.0f);
            corpseComplete = false;
        }
        else if (corpsePercentage >= corpsePercentage && corpsePercentage < 100.0f)
        {
            corpseUiBar.color = new Color(0.486f, 0.819f, 0.290f, 1.0f);
            corpseComplete = true;

        }
        else
        {
            corpseUiBar.color = new Color(0.368f, 0.717f, 0.858f, 1.0f);
        }

        // Update the corpse ui bar
        corpseUiBar.fillAmount = (corpsePercentage / 100.0f);

    }

    void checkEndConditions()
    {
        if (torchComplete && trapComplete && bloodComplete && chestComplete && corpseComplete)
        {
            endLevelGate.SetActive(true);
        }
    }

    public float getTorchPercentage()
    {
        int torchesLit = 0;

        for (int i = 0; i < torchList.Count; i++)
        {
            if (torchList[i].GetComponent<SCR_Torch>().torchLit)
            {
                // Increment the torch lit variable by 1
                torchesLit += 1;
            }
        }

        // Calculate the percentage of torches lit
        float torchPercentage = ((float)torchesLit / torchList.Count) * 100.0f;

        return Mathf.Round(torchPercentage);
    }

    public float getTrapPercentage()
    {
        int trapsCleared = 0;

        for (int i = 0; i < trapList.Count; i++)
        {
            if (trapList[i].tag == "Spike")
            {
                if (!trapList[i].GetComponent<SCR_Spikes>().activated)
                {
                    Debug.Log("SPIKES");
                    trapsCleared++;
                }
            }
            if (trapList[i].tag == "PressurePlate")
            {
                if (!trapList[i].GetComponent<SCR_PressurePlate>().platePressed)
                {
                    trapsCleared++;
                }
            }
            if (trapList[i].tag == "TrapDoor")
            {
                if (trapList[i].GetComponent<SCR_TrapDoor>().trapReset)
                {
                    trapsCleared++;
                }
            }
        }

        // Calculate the percentage of traps cleared
        float trapPercentage = ((float)trapsCleared / trapList.Count) * 100.0f;

        return Mathf.Round(trapPercentage);
    }

    public float getBloodPercentage()
    {
        // Clear the blood list
        bloodList.Clear();

        // Repopulate the blood list
        populateBloodList();

        int bloodCleaned = originalMaxBlood - bloodList.Count;

        // Caluclate the percentage of cleaned blood
        float bloodPercentage = ((float)bloodCleaned / (float)originalMaxBlood) * 100.0f;

        return Mathf.Round(bloodPercentage);
    }

    public float getChestPercentage()
    {
        int chestsFilled = 0;

        for (int i = 0; i < chestList.Count; i++)
        {
            if (chestList[i].GetComponent<SCR_Chest>().chestRefilled)
            {
                // Increment the torch lit variable by 1
                chestsFilled += 1;
            }
        }

        // Calculate the percentage of chests filled
        float chestPercentage = ((float)chestsFilled / chestList.Count) * 100.0f;

        return Mathf.Round(chestPercentage);
    }


    public float getCorpsePercentage()
    {
        // Clear the corpse list
        corpseList.Clear();

        // Repopulate the corpse list
        populateCorpseList();

        int corpsesCleaned = originalMaxCorpses - corpseList.Count;

        // Caluclate the percentage of cleaned blood
        float corpsePercentage = ((float)corpsesCleaned / (float)originalMaxCorpses) * 100.0f;

        return Mathf.Round(corpsePercentage);
    }

    public float getTotalPercentage()
    {

        int torchesLit = 0;

        for (int i = 0; i < torchList.Count; i++)
        {
            if (torchList[i].GetComponent<SCR_Torch>().torchLit)
            {
                // Increment the torch lit variable by 1
                torchesLit += 1;
            }
        }

        int trapsCleared = 0;

        for (int i = 0; i < trapList.Count; i++)
        {
            if (trapList[i].tag == "Spike")
            {
                if (!trapList[i].GetComponent<SCR_Spikes>().activated)
                {
                    Debug.Log("SPIKES");
                    trapsCleared++;
                }
            }
            if (trapList[i].tag == "PressurePlate")
            {
                if (!trapList[i].GetComponent<SCR_PressurePlate>().platePressed)
                {
                    trapsCleared++;
                }
            }
            if (trapList[i].tag == "TrapDoor")
            {
                if (trapList[i].GetComponent<SCR_TrapDoor>().trapReset)
                {
                    trapsCleared++;
                }
            }
        }

        // Clear the blood list
        bloodList.Clear();

        // Repopulate the blood list
        populateBloodList();

        int bloodCleaned = originalMaxBlood - bloodList.Count;



        int chestsFilled = 0;

        for (int i = 0; i < chestList.Count; i++)
        {
            if (chestList[i].GetComponent<SCR_Chest>().chestRefilled)
            {
                // Increment the torch lit variable by 1
                chestsFilled += 1;
            }
        }


        // Clear the corpse list
        corpseList.Clear();

        // Repopulate the corpse list
        populateCorpseList();

        int corpsesCleaned = originalMaxCorpses - corpseList.Count;

        int totalObjectsCleared = torchesLit + trapsCleared + bloodCleaned + chestsFilled + corpsesCleaned;
        // Debug.Log("Cleared: " + totalObjectsCleared);
        int maxObjects = torchList.Count + trapList.Count + originalMaxBlood + chestList.Count + originalMaxCorpses;
        // Debug.Log("Final: " + maxObjects);

        float finalPercentage = ((float)totalObjectsCleared / (float)maxObjects) * 100.0f;

        // Debug.Log(finalPercentage);

        return Mathf.Round(finalPercentage);



    }
}
    