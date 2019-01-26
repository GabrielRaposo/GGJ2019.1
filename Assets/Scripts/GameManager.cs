using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum actions
{
	none,
	cleanTent,
	getFood,
    cleanDebris
}

public enum resourceTypes 
{
    stone,
    wood,
    decoration
}

public class GameManager : MonoBehaviour
{

	[SerializeField] private DayBehaviour dayBehaviour;
	[SerializeField] private GameObject selectedCitizen;
	[SerializeField] private GameObject foodPanel;
	[SerializeField] private int foodQuantity = 0;
	[SerializeField] private Texture foodFilled, foodUnfilled;

	public const int maxFoodQuantity = 3;

	public int FoodQuantity
	{
		get { return foodQuantity; }
		set { foodQuantity = value; }
	}

	public GameObject SelectedCitizen
	{
		get { return selectedCitizen; }
		set { selectedCitizen = value; }
	}

	public List<GameObject> GetInteractableItemsInCurrentDay
	{
		get
		{
			dayBehaviour.InitInteractableObjects();
			return dayBehaviour.interactableItemsInCurrentDay;
		}
	}

	// Start is called before the first frame update
	void Start()
    {
		dayBehaviour = GetComponent<DayBehaviour>();
		foodPanel = GameObject.Find("Food Panel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void BeginFirstDay()
	{
		dayBehaviour.BeginDay();
		foodQuantity = 1;
	}

	public bool CanAdvanceDay()
	{
		GameObject[] citizens = GameObject.FindGameObjectsWithTag("Citizen");
		foreach (GameObject citizen in citizens)
		{
			if (citizen.GetComponent<CitizenBehaviour>().turnActionType == actions.none) return false;
		}
		if (foodQuantity == 0)
		{
			bool foodAction = false;
			foreach (GameObject citizen in citizens)
			{
				if (citizen.GetComponent<CitizenBehaviour>().turnActionType == actions.getFood) foodAction = true;
			}
			if (!foodAction) return false;
		}
		return true;
	}

	private void UpdateFood()
	{
		for (int i = 0; i < maxFoodQuantity; i++)
		{
			if (i < foodQuantity)
			{
				foodPanel.transform.GetChild(i).GetComponent<RawImage>().texture = foodFilled;
			} else
			{
				foodPanel.transform.GetChild(i).GetComponent<RawImage>().texture = foodUnfilled;
			}
		}
	}

	public void AdvanceDay()
	{
		if (CanAdvanceDay())
		{
			CitizenBehaviour[] citizens = GameObject.FindObjectsOfType<CitizenBehaviour>();
			
			foodQuantity--;
			dayBehaviour.AdvanceDay(citizens);
			UpdateFood();
			foreach (CitizenBehaviour citizen in citizens)
			{
				citizen.ResetTurnAction();
                citizen.UnhighlightInteractable();
			}
		}
		else
		{
			print("mano tem que fazer as ações");
		}
	}
}
