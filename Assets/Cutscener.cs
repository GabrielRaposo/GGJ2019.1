using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscener : MonoBehaviour
{

    public List<GameObject> spawnPlaces;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCutscene(int dayCounter, ref StoryMaster storyMaster)
    {
        List<GameObject> l = new List<GameObject>(spawnPlaces);
        foreach(GameObject citizen in GameObject.FindGameObjectsWithTag("Citizen"))
        {
            int rand = Random.Range(0, l.Count);
            print(rand);
            citizen.transform.position = l[rand].transform.position;
            citizen.GetComponent<CitizenBehaviour>().IsClickable = false;
            citizen.GetComponent<CitizenBehaviour>().UnhighlightInteractable();
            citizen.GetComponent<CitizenBehaviour>().HideInfo();
            l.RemoveAt(rand);
        }
        if (dayCounter == 1)
        {
            storyMaster.UpdateCurrentStory("Alone_by_bonfire");
        }
        else
        {
            if (dayCounter == 2)
            {
                storyMaster.UpdateCurrentStory("Day_two");
            }
            else
            {
                if (dayCounter == 4)
                {

                }
                else
                {
                    storyMaster.BasicSelectionBetweenScenes();
                }
            }
        }
    }

    public void StopCutscene()
    {
        Vector3 currentVector = Vector3.zero;
        foreach (GameObject citizen in GameObject.FindGameObjectsWithTag("Citizen"))
        {
            CitizenBehaviour citizenBehaviour = citizen.GetComponent<CitizenBehaviour>();
            if (citizenBehaviour.hasTent)
            {
                citizen.transform.position = citizenBehaviour.tent.transform.position;
            } else
            {
                citizen.transform.position = currentVector;
                currentVector += new Vector3(2.0f, 0.0f, 0.0f);
            }
            citizen.GetComponent<CitizenBehaviour>().IsClickable = true;
            citizen.GetComponent<CitizenBehaviour>().UnhighlightInteractable();
            citizen.GetComponent<CitizenBehaviour>().HideInfo();
        }
    }
}
