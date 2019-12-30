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
    cleanDebris,
    getWood,
    getStone,
    getDecoration,
    craft
}

public enum resourceTypes
{
    stone,
    wood,
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private Cutscener cutscener;
    [SerializeField] private DayBehaviour dayBehaviour;
    [SerializeField] private PeopleBehaviour peopleBehaviour;
    [SerializeField] private GameObject selectedCitizen;
    [SerializeField] private GameObject foodPanel;
    [SerializeField] private int foodQuantity = 0;
    [SerializeField] private Texture foodFilled, foodUnfilled;
    [SerializeField] private float secondsToDownfall, counterToFade = 100.0f;
    [SerializeField] public GameObject craftedItem;
    private StoryMaster storyMaster;
    Image backgroundFade;

    private List<string> persistentObjectsBetweenScenes = new List<string>(new string[] { "canvas-fade", "GameManager", "Citizen", "Main Camera" });


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
        peopleBehaviour = GetComponent<PeopleBehaviour>();
        foodPanel = GameObject.Find("Food Panel");
        backgroundFade = GameObject.FindGameObjectWithTag("Fade Background").GetComponent<Image>();
        backgroundFade.canvasRenderer.SetAlpha(0f);
        storyMaster = GetComponent<StoryMaster>();
        UpdateFood();

		if(dayBehaviour.DayCounter == 0)
		{
			StartCoroutine(Downfall());
		}
		
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

            if (!foodAction)
            {
                Debug.Log("Mano tu tem que pegar comida");
                StartCoroutine(FoodAlarm());
                return false;
            }
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
                foodPanel.transform.GetChild(i).GetComponent<RawImage>().color = Color.white;
            } else
            {
                foodPanel.transform.GetChild(i).GetComponent<RawImage>().texture = foodUnfilled;
                foodPanel.transform.GetChild(i).GetComponent<RawImage>().color = new Color(0.6f, 0.6f, 0.6f, 0.8f);
            }
        }
    }

    private IEnumerator FoodAlarm()
    {
        Image window = foodPanel.GetComponent<Image>();
        float clock = 0;
        float maxTime = 0.21f;
        int reps = 0;
        int maxReps = 5;

        Vector3 startingScale = foodPanel.transform.localScale;
        Vector3 maxScale = new Vector3(1.75f,1.75f,1f);

        while (reps<=maxReps)
        {
            if (reps % 2 == 0)
            {
                while (clock<maxTime)
                {
                    clock += Time.deltaTime;

                    foodPanel.transform.localScale = Vector3.Lerp(startingScale, maxScale, (clock / maxTime));
                    Vector3 colorVec = Vector3.Lerp(Vector3.one, new Vector3(Color.red.r, Color.red.g, Color.red.b),
                        (clock / maxTime));
                    window.color = new Color(colorVec.x, colorVec.y, colorVec.z);
            
                    yield return null;
                }    
            }
            else
            {
                while (clock<maxTime)
                {
                    clock += Time.deltaTime;

                    foodPanel.transform.localScale = Vector3.Lerp(maxScale, startingScale, (clock / maxTime));
                    Vector3 colorVec = Vector3.Lerp(new Vector3(Color.red.r, Color.red.g, Color.red.b), Vector3.one,
                        (clock / maxTime));
                    window.color = new Color(colorVec.x, colorVec.y, colorVec.z);
            
                    yield return null;
                }
            }
            
            
            
            reps++;
            clock = 0;
        }

        foodPanel.transform.localScale = startingScale;
        window.color = Color.white;

    }

    public void ResetCamp(CitizenBehaviour[] citizens)
    {
        UpdateFood();
        foreach (CitizenBehaviour citizen in citizens)
        {
            citizen.ResetTurnAction();
            citizen.SetHighlightInteractableAll(false);
            citizen.SetClickable(true);
        }

        foreach (var o in FindObjectsOfType(typeof(ActionMarkers)))
        {
            var am = (ActionMarkers) o;
            am.ClearAll();
        }
        
    }

    public void DeactivateCamp()
    {
        selectedCitizen = null;
        foreach (GameObject rootGameObject in SceneManager.GetSceneByName("TilemapTest").GetRootGameObjects())
        {
            if (persistentObjectsBetweenScenes.Exists(elem => rootGameObject.name.Contains(elem))) continue;
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

		if(dayBehaviour.DayCounter >=1)
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

        if (dayBehaviour.DayCounter == 2)
        {
            peopleBehaviour.SpawnNewcomers(1);
        }

        if (dayBehaviour.DayCounter == 4)
        {
            peopleBehaviour.SpawnNewcomers(2);
        }
        updateAllMoods();
        cutscener.StartCutscene(dayBehaviour.DayCounter, ref storyMaster);
        backgroundFade.CrossFadeAlpha(0.0f, secondsToDownfall / 3.0f, false);
        AdvanceDayCamp();
        yield return new WaitForSeconds(secondsToDownfall / 3.0f);
        storyMaster.passStory = true;
    }

    public IEnumerator Sunrise()
    {
        craftedItem = null;
        backgroundFade.CrossFadeAlpha(1.0f, secondsToDownfall / 3.0f, false);
        yield return new WaitForSeconds(secondsToDownfall / 3.0f);

        ActivateCamp();
        cutscener.StopCutscene();
        SceneManager.UnloadSceneAsync("Fogueira");
        yield return new WaitForSeconds(secondsToDownfall / 3.0f);

        backgroundFade.CrossFadeAlpha(0.0f, secondsToDownfall / 3.0f, false);
        yield return new WaitForSeconds(secondsToDownfall / 3.0f);

		

		if(dayBehaviour.DayCounter == 1)
		{
			Debug.Log($"SUNRISE DIA: {dayBehaviour.DayCounter}");
			storyMaster.Bark(Barks.TENT, FindObjectOfType<CitizenBehaviour>());			
		}
		if (dayBehaviour.DayCounter == 2) {
			Debug.Log($"SUNRISE DIA: {dayBehaviour.DayCounter}");
			storyMaster.Bark(Barks.FOOD, FindObjectOfType<CitizenBehaviour>());			
		}

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


    public void updateAllMoods()
    {
        GameObject[] citizens = GameObject.FindGameObjectsWithTag("Citizen");
        foreach (GameObject c in citizens)
        {
            Theme prof = c.GetComponent<CitizenBehaviour>().citizenData.proficience;
            Theme like = c.GetComponent<CitizenBehaviour>().citizenData.like;
            Theme dislike = c.GetComponent<CitizenBehaviour>().citizenData.dislike;
            if (craftedItem != null)
            {
                List<Theme> itemThemes = craftedItem.GetComponent<DecorationScript>().themes;
                foreach (Theme theme in itemThemes)
                {
                    if (prof == theme)
                    {
                        c.GetComponent<SatisfactionManager>().updateSatisfaction(2);
                    }
                    else if (like == theme)
                    {
                        c.GetComponent<SatisfactionManager>().updateSatisfaction(4);
                    }
                    else if (prof == theme)
                    {
                        c.GetComponent<SatisfactionManager>().updateSatisfaction(-3);
                    }
                }
            }
            c.GetComponent<SatisfactionManager>().checkSatisfactionEndOfDay();
        }
    }
}
