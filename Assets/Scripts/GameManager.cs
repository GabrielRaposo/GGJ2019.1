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
    [SerializeField] private float secondsToDownfall, counterToFade = 100.0f;
    Image backgroundFade;


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
        backgroundFade = GameObject.FindGameObjectWithTag("Fade Background").GetComponent<Image>();
        backgroundFade.canvasRenderer.SetAlpha(0f);
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

    public void ResetCamp(CitizenBehaviour[] citizens)
    {
        UpdateFood();
        foreach (CitizenBehaviour citizen in citizens)
        {
            citizen.ResetTurnAction();
            citizen.UnhighlightInteractable();
        }
    }

    public void DesactivateCamp()
    {
        foreach (GameObject rootGameObject in SceneManager.GetSceneByName("TilemapTest").GetRootGameObjects())
        {
            if (rootGameObject.name == "canvas-fade") continue;
            rootGameObject.SetActive(false);
        }
    }

    public void ActivateCamp()
    {
        foreach (GameObject rootGameObject in SceneManager.GetSceneByName("TilemapTest").GetRootGameObjects())
        {
            if (rootGameObject.name == "canvas-fade") continue;
            rootGameObject.SetActive(true);
        }
    }

    public void AdvanceDayCamp()
    {
        CitizenBehaviour[] citizens = GameObject.FindObjectsOfType<CitizenBehaviour>();

        foodQuantity--;
        dayBehaviour.AdvanceDay(citizens);
        ResetCamp(citizens);
        // DesactivateCamp();
    }
    
    public IEnumerator Downfall()
    {
        // backgroundFade.CrossFadeAlpha(1.0f, secondsToDownfall / 2.0f, false);
        // yield return new WaitForSeconds(secondsToDownfall / 2.0f);
        // SceneManager.LoadScene("Fogueira", LoadSceneMode.Additive);
        AdvanceDayCamp();
        // backgroundFade.CrossFadeAlpha(0.0f, secondsToDownfall / 2.0f, false);
        yield return new WaitForSeconds(secondsToDownfall / 2.0f);
    }

	public void AdvanceDay()
	{
		if (CanAdvanceDay())
		{
            StartCoroutine(Downfall());
		}
		else
		{
			print("mano tem que fazer as ações");
		}
	}
}
