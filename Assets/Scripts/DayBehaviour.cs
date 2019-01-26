using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayBehaviour : MonoBehaviour
{

	public List<GameObject> interactableItemsInCurrentDay;
	[SerializeField] GameManager gameManager;
	[SerializeField] GameObject dayTextObject;
	[SerializeField] float dayTextDuration;

	PeopleBehaviour peopleBehaviour; 

	int dayCounter = 0;
	
	public int DayCounter
	{
		get { return dayCounter; }
		set { dayCounter = value; }
	}

	// Start is called before the first frame update
	void Start()
    {
		peopleBehaviour = GetComponent<PeopleBehaviour>();
		gameManager = GetComponent<GameManager>();
		interactableItemsInCurrentDay = new List<GameObject>();
		StartCoroutine(showDayText());
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	IEnumerator showDayText()
	{
		int counterMax = 100;
		float alpha = 1;
		dayTextObject.GetComponent<TextMeshProUGUI>().text = "Day " + dayCounter;
		dayTextObject.SetActive(true);
		for (int i = 0; i < counterMax; i++) {
			alpha = alpha - 1.0f / counterMax;
			dayTextObject.GetComponent<TextMeshProUGUI>().alpha = alpha;
			yield return new WaitForSeconds(dayTextDuration / counterMax);
		}
		dayTextObject.SetActive(false);
		dayCounter++;
	}

	public void InitInteractableObjects()
	{
		List<GameObject> itemsCurrentDay = interactableItemsInCurrentDay;
		if (interactableItemsInCurrentDay.Count == 0)
		{
			Interactable[] interactables = GameObject.FindObjectsOfType<Interactable>();
			foreach (Interactable interactable in interactables)
			{
				itemsCurrentDay.Add(interactable.gameObject);
			}
		}
	}

	public void RemoveInteractableObject(GameObject obj)
	{
		interactableItemsInCurrentDay.Remove(obj);
	}

	public void BeginDay()
	{
		InitInteractableObjects();
		if (dayCounter == 2) {
			peopleBehaviour.SpawnNewcomers(1);
		}
	}

	public void AdvanceDay(CitizenBehaviour[] citizens)
	{
		foreach (CitizenBehaviour citizen in citizens)
		{
			citizen.turnAction();
		}
		BeginDay();
		StartCoroutine("showDayText");
	}
}
