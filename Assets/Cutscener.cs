﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscener : MonoBehaviour
{

    public List<GameObject> spawnPlaces;

    public void StartCutscene(int dayCounter, ref StoryMaster storyMaster)
    {
        List<GameObject> l = new List<GameObject>(spawnPlaces);
        foreach(GameObject citizen in GameObject.FindGameObjectsWithTag("Citizen"))
        {
            int rand = Random.Range(0, l.Count);
            print(rand);
            citizen.transform.position = l[rand].transform.position;
            citizen.transform.localScale = new Vector3 (2, 2, 0);
            citizen.GetComponent<CitizenBehaviour>().IsClickable = false;
            citizen.GetComponent<CitizenBehaviour>().UnhighlightInteractable();
            citizen.GetComponent<CitizenBehaviour>().HideInfo();
            l.RemoveAt(rand);
        }
        if (dayCounter < 6)
        {

            if (dayCounter == 1) storyMaster.UpdateCurrentStory("Alone_by_bonfire");
            if (dayCounter == 2) storyMaster.UpdateCurrentStory("Day_two");
            if (dayCounter == 3) storyMaster.UpdateCurrentStory("Day_three");
            if (dayCounter == 4) storyMaster.UpdateCurrentStory("Day_four");
            if (dayCounter == 5) storyMaster.UpdateCurrentStory("Day_five");
        }
        else
        {
            storyMaster.BasicSelectionBetweenScenes();
        }
    }

    public void StopCutscene()
    {

        foreach (GameObject citizen in GameObject.FindGameObjectsWithTag("Citizen"))
        {
            float posY = Random.Range(-3, 3) + 0.5f;
            float posX = Random.Range(-5, 5) + 0.5f;
            Vector3 currentVector = new Vector3(posX, posY, 0f);

            CitizenBehaviour citizenBehaviour = citizen.GetComponent<CitizenBehaviour>();
            if (citizenBehaviour.hasTent)
            {
                citizen.transform.position = citizenBehaviour.tent.transform.position;
            } else
            {
                citizen.transform.position = currentVector;
                posY = Random.Range(-3, 3) + 0.5f;
                posX = Random.Range(-5, 5) + 0.5f;
                Vector3 newVector = new Vector3(posX, posY, 0f);

                if (newVector.x != currentVector.x && newVector.y != currentVector.y) {
                    currentVector = newVector;
                }

            }
            citizen.transform.localScale = new Vector3(1f, 1f, 0f);
            citizen.GetComponent<CitizenBehaviour>().IsClickable = true;
            citizen.GetComponent<CitizenBehaviour>().UnhighlightInteractable();
            citizen.GetComponent<CitizenBehaviour>().HideInfo();
        }
    }
}