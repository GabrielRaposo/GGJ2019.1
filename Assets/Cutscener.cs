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
            citizen.transform.position = l[rand].transform.position;
            citizen.GetComponent<CitizenBehaviour>().IsClickable = false;
            citizen.GetComponent<CitizenBehaviour>().UnhighlightInteractable();
            citizen.GetComponent<CitizenBehaviour>().HideInfo();
            spawnPlaces.RemoveAt(rand);
        }
        if (dayCounter == 1)
        {
            storyMaster.UpdateCurrentStory("Alone_by_bonfire");
        }
        if (dayCounter == 2)
        {
            storyMaster.UpdateCurrentStory("Day_two");
        }
    }

    public void StopCutscene()
    {
        foreach (GameObject citizen in GameObject.FindGameObjectsWithTag("Citizen"))
        {
            citizen.transform.position = Vector3.zero;
            citizen.GetComponent<CitizenBehaviour>().IsClickable = true;
            citizen.GetComponent<CitizenBehaviour>().UnhighlightInteractable();
            citizen.GetComponent<CitizenBehaviour>().HideInfo();
        }
    }
}
