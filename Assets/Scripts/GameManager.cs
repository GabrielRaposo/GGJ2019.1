using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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
    [SerializeField] private Cutscener cutscener;
    [SerializeField] private DayBehaviour dayBehaviour;
    [SerializeField] private GameObject selectedCitizen;
    [SerializeField] private GameObject foodPanel;
    [SerializeField] private int foodQuantity = 0;
    [SerializeField] private Texture foodFilled, foodUnfilled;
    [SerializeField] private float secondsToDownfall, counterToFade = 100.0f;
    private StoryMaster storyMaster;
    Image backgroundFade;

    private List<string> persistentObjectsBetweenScenes = new List<string>(new string[] { "canvas-fade", "GameManager", "Citizen" });


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
        storyMaster = GetComponent<StoryMaster>();
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

    public void DeactivateCamp()
    {
        selectedCitizen = null;
        foreach (GameObject rootGameObject in SceneManager.GetSceneByName("TilemapTest").GetRootGameObjects())
        {
            if (persistentObjectsBetweenScenes.Exists( elem => rootGameObject.name.Contains(elem)) ) continue;
            rootGameObject.SetActive(false);
        }
    }

    public void ActivateCamp()
    {
        selectedCitizen = null;
        foreach (GameObject rootGameObject in SceneManager.GetSceneByName("TilemapTest").GetRootGameObjects())
        {
            if (persistentObjectsBetweenScenes.Exists(elem => rootGameObject.name.Contains(elem))) continue;
            rootGameObject.SetActive(true);
        }
    }

    public void AdvanceDayCamp()
    {
        CitizenBehaviour[] citizens = GameObject.FindObjectsOfType<CitizenBehaviour>();

        foodQuantity--;
        dayBehaviour.AdvanceDay(citizens);
        ResetCamp(citizens);
        DeactivateCamp();
    }
    
    public IEnumerator Downfall()
    {
        backgroundFade.CrossFadeAlpha(1.0f, secondsToDownfall / 3.0f, false);
        yield return new WaitForSeconds(secondsToDownfall / 3.0f);

        SceneManager.LoadScene("Fogueira", LoadSceneMode.Additive);
        yield return new WaitForSeconds(secondsToDownfall / 3.0f);

        storyMaster.text = GameObject.FindGameObjectWithTag("Dialog Box").GetComponent<TextMeshProUGUI>();
        cutscener = GameObject.FindGameObjectWithTag("Cutscener").GetComponent<Cutscener>();
        cutscener.StartCutscene(dayBehaviour.DayCounter, ref storyMaster);
        AdvanceDayCamp();
        backgroundFade.CrossFadeAlpha(0.0f, secondsToDownfall / 3.0f, false);
        yield return new WaitForSeconds(secondsToDownfall / 3.0f);
    }

    public IEnumerator Sunrise()
    {
        backgroundFade.CrossFadeAlpha(1.0f, secondsToDownfall / 3.0f, false);
        yield return new WaitForSeconds(secondsToDownfall / 3.0f);

        ActivateCamp();
        cutscener.StopCutscene();
        SceneManager.UnloadSceneAsync("Fogueira");
        yield return new WaitForSeconds(secondsToDownfall / 3.0f);

        backgroundFade.CrossFadeAlpha(0.0f, secondsToDownfall / 3.0f, false);
        yield return new WaitForSeconds(secondsToDownfall / 3.0f);
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
