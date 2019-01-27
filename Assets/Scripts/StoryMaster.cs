using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;

public enum Barks { GET_FOOD, REMOVE_DEBRIE, GET_DECOR_WATER, GET_DECOR_FIRE, GET_DECOR_EARTH, GET_DECOR_AIR, GET_STONE, GET_WOOD}

public class StoryMaster : MonoBehaviour
{
	public TextAsset inkAsset;
	private Story story;

	public TextMeshProUGUI text;

	private Dictionary<CitizenBehaviour, CitizenData> mapCitizenData;

	public List<CitizenData> citizens;
	private List<CitizenData> orderedCitizensForStory;

	public GameManager gameManager;

	private delegate string GetName(int index);
	private delegate string GetSurname(int index);
	private delegate int GetLike(int index);
	private delegate int GetDislike(int index);
	private delegate int GetProficiency(int index);

	private GetName getName;
	private GetSurname getSurname;
	private GetLike getLike;
	private GetDislike getDislike;
	private GetProficiency getProficiency;


    public GameObject newItem;

    private void Awake()
    {
        story = new Story(inkAsset.text);
        story.ChoosePathString("Leaving_camp");

        // citizens = new List<CitizenData> { new CitizenData(), new CitizenData(), new CitizenData(), new CitizenData() };

        SetExternalInkFunctions();
		InkUseCitizens();
    }

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (story.canContinue)
            {
                text.text = story.Continue();
                string name = text.text.Substring(0,text.text.IndexOf(':'));
                Debug.Log(name);
                bool gambiarra = false; int index = 0;
                foreach(CitizenData singleCitizens in citizens)
                {
                    if (name.Equals(singleCitizens.name))
                    {
                        gambiarra = true;
                        break;
                    }
                    index++;
                }
                if (gambiarra == true)
                {
                    switch (index)
                    {
                        case 0:
                            text.text = "<color=red>" + text.text.Substring(0, text.text.IndexOf(':')+1) + "</color>" + text.text.Substring(text.text.IndexOf(':') + 1, text.text.Length - text.text.IndexOf(':') - 1);
                            break;
                        case 1:
                            text.text = "<color=blue>" + text.text.Substring(0, text.text.IndexOf(':')+1) + "</color>" + text.text.Substring(text.text.IndexOf(':') + 1, text.text.Length - text.text.IndexOf(':') - 1);
                            break;
                        case 2:
                            text.text = "<color=green>" + text.text.Substring(0, text.text.IndexOf(':')+1) + "</color>" + text.text.Substring(text.text.IndexOf(':') + 1, text.text.Length - text.text.IndexOf(':') - 1);
                            break;
                        case 3:
                            text.text = "<color=purple>" + text.text.Substring(0, text.text.IndexOf(':')+1) + "</color>" + text.text.Substring(text.text.IndexOf(':') + 1, text.text.Length - text.text.IndexOf(':') - 1);
                            break;
                        default:
                            Debug.Log("Não deveria entrar aqui");
                            break;
                    }
                }
                text.text = FormatKeyword(text.text, "tomorrow", 'i');
                text.text = FormatKeyword(text.text, "never need to swim", 'i');
                text.text = FormatKeyword(text.text, "hope it rains", 'i');
                text.text = FormatKeyword(text.text, "live by the beach", 'i');
                text.text = FormatKeyword(text.text, "fish", 'i');
                text.text = FormatKeyword(text.text, "No more alcohol", 'i');
                text.text = FormatKeyword(text.text, "hiking", 'i');
                text.text = FormatKeyword(text.text, "used to plant", 'i');
                text.text = FormatKeyword(text.text, "jewelry", 'i');
                text.text = FormatKeyword(text.text, "home", 'i');
                text.text = FormatKeyword(text.text, "dirt", 'i');
                text.text = FormatKeyword(text.text, "cliff", 'i');
                text.text = FormatKeyword(text.text, "mine", 'i');
                text.text = FormatKeyword(text.text, "fire", 'i');
                text.text = FormatKeyword(text.text, "lighting", 'i');
                text.text = FormatKeyword(text.text, "warmer", 'i');
                text.text = FormatKeyword(text.text, "incense", 'i');
                text.text = FormatKeyword(text.text, "spicy", 'i');
                text.text = FormatKeyword(text.text, "cooler", 'i');
                text.text = FormatKeyword(text.text, "wound", 'i');
                text.text = FormatKeyword(text.text, "kite", 'i');
                text.text = FormatKeyword(text.text, "clouds", 'i');
                text.text = FormatKeyword(text.text, "tornado", 'i');
                text.text = FormatKeyword(text.text, "sea", 'i');
                text.text = FormatKeyword(text.text, "home", 'i');
                text.text = FormatKeyword(text.text, "alright", 'i');
                text.text = FormatKeyword(text.text, "best", 'i');
                text.text = FormatKeyword(text.text, "Leaving", 'i');
                text.text = FormatKeyword(text.text, "leave", 'i');
                text.text = FormatKeyword(text.text, "didn't matter", 'i');
                text.text = FormatKeyword(text.text, "bad day", 'i');
                text.text = FormatKeyword(text.text, "feathers", 'i');
                text.text = FormatKeyword(text.text, "tree", 'i');
                text.text = FormatKeyword(text.text, "waves", 'i');
                text.text = FormatKeyword(text.text, "meat", 'i');
                text.text = FormatKeyword(text.text, "food", 'i');
                text.text = FormatKeyword(text.text, "bard", 'i');
                text.text = FormatKeyword(text.text, "glide", 'i');
                text.text = FormatKeyword(text.text, "craft", 'i');
                text.text = FormatKeyword(text.text, "craftsman", 'i');
                text.text = FormatKeyword(text.text, "dance", 'i');
                text.text = FormatKeyword(text.text, "hot", 'i');
                text.text = FormatKeyword(text.text, "mines", 'i');
                text.text = FormatKeyword(text.text, "burn", 'i');
                text.text = FormatKeyword(text.text, "memories", 'i');
                text.text = FormatKeyword(text.text, "barman", 'i');
                text.text = FormatKeyword(text.text, "self-healing", 'i');
                text.text = FormatKeyword(text.text, "love", 'i');
                text.text = FormatKeyword(text.text, "revolting", 'i');
            }
            else
            {
                StartCoroutine(gameManager.Sunrise());
            }
        }       
    }

    private string FormatKeyword(string str, string keyword, char richTextCommand)
    {
        int strLength = str.Length;
        int keywordLength = keyword.Length;
        if (str.Contains(keyword))
        {
            int parsePosition = str.IndexOf(keyword);
            return str.Substring(0, parsePosition) + "<" + richTextCommand + ">" + keyword + "</" + richTextCommand + ">" + str.Substring(parsePosition + keywordLength, strLength - parsePosition - keywordLength);
        }
        else
        {
            return str;
        }
    }

    public void UpdateCitizenData()
    {
        List<CitizenData> list = new List<CitizenData>();
        foreach(GameObject citizenGameObject in GameObject.FindGameObjectsWithTag("Citizen"))
        {
            print(citizenGameObject.GetComponent<CitizenBehaviour>().CitizenData);
            list.Add(citizenGameObject.GetComponent<CitizenBehaviour>().CitizenData);
        }
        citizens = list;
    }

    public void UpdateCurrentStory(string pathString)
	{
		UpdateCitizenData();
        story.ChoosePathString(pathString);
        text.text = "";
        text.text = story.Continue();
    }

    public void BasicSelectionBetweenScenes()
    {
        int i = 0;
        int r = 0;
		orderedCitizensForStory = new List<CitizenData>(citizens);

        foreach(CitizenData cd in citizens)
        {
            if (!cd.revealedLike)
            {
                i++;
            }
            if (!cd.revealedDislike)
            {
                i++;
            }
            if (!cd.revealProficience)
            {
                i++;
            }
        }

        r = Random.Range(0, i);

        UpdateCitizenData();
        for (int j = 0; j < citizens.Count; j++)
        {
            if (!citizens[j].revealedLike)
            {
                r--;
                if (r == 0)
                {
					GoToLikeStory(j);
                }
            }
            if (!citizens[j].revealedDislike)
            {
                r--;
                if(r == 0)
                {
					GoToDislikeStory(j);
                }
            }
            if (!citizens[j].revealProficience)
            {
                r--;
                if(r == 0)
                {
					GoToProficiencyStory(j);
                }
            }
        }
    }

	private void GoToLikeStory(int citizenIndex)
	{
		citizens[citizenIndex].revealedLike = true;
		ReorderCitizens(citizenIndex);

		switch (citizens[0].like)
		{
			case Theme.WATER:
                UpdateCurrentStory($"LikeWater{Random.Range(0,4).ToString()}");
				break;
			case Theme.FIRE:
                UpdateCurrentStory($"LikeFire{Random.Range(0, 4).ToString()}");
				break;
			case Theme.EARTH:
                UpdateCurrentStory($"LikeEarth{Random.Range(0, 4).ToString()}");
				break;
			case Theme.AIR:
                UpdateCurrentStory($"LikeAir{Random.Range(0, 4).ToString()}");
				break;
		}
	}

	private void GoToDislikeStory(int citizenIndex)
	{
		citizens[citizenIndex].revealedDislike = true;
		ReorderCitizens(citizenIndex);

		switch (citizens[0].dislike)
		{
			case Theme.WATER:
                UpdateCurrentStory($"DislikeWater{Random.Range(0, 4).ToString()}");
				break;
			case Theme.FIRE:
                UpdateCurrentStory($"DislikeFire{Random.Range(0, 4).ToString()}");
				break;
			case Theme.EARTH:
                UpdateCurrentStory($"DislikeEarth{Random.Range(0, 4).ToString()}");
				break;
			case Theme.AIR:
                UpdateCurrentStory($"DislikeAir{Random.Range(0, 4).ToString()}");
				break;
		}
	}

	private void GoToProficiencyStory(int citizenIndex)
	{
		citizens[citizenIndex].revealProficience = true;
		ReorderCitizens(citizenIndex);

		switch (citizens[0].proficience)
		{
			case Theme.WATER:
                UpdateCurrentStory($"ProficienceWater{Random.Range(0, 4).ToString()}");
				break;
			case Theme.FIRE:
                UpdateCurrentStory($"ProficienceFire{Random.Range(0, 4).ToString()}");
				break;
			case Theme.EARTH:
                UpdateCurrentStory($"ProficienceEarth{Random.Range(0, 4).ToString()}");
				break;
			case Theme.AIR:
                UpdateCurrentStory($"ProficienceWater{Random.Range(0, 4).ToString()}");
				break;
		}
	}

	private void GoToItemComent(int citizenIndex)
	{
		CitizenData dude = citizens[citizenIndex];
		DecorationScript item = newItem.GetComponent<DecorationScript>();

		ReorderCitizens(citizenIndex);

		if (item.themes.Contains(dude.like) || (item.themes.Contains(dude.proficience)))
		{
			UpdateCurrentStory($"LikingItemP{Random.Range(0, 4).ToString()}");
		}
		else if (item.themes.Contains(dude.dislike))
		{
			UpdateCurrentStory($"DislikingItemP{Random.Range(0, 4).ToString()}");
		}
		else
		{
			UpdateCurrentStory($"NeutralItemP{Random.Range(0, 4).ToString()}");
		}

	}

	public void Bark(Barks barks, CitizenBehaviour dude)
	{
		ReorderCitizens(citizens.IndexOf(dude.GetComponent<CitizenData>()));

		if(dude.gameObject.GetComponent<SatisfactionManager>().strikes == 3)
		{
			story.ChoosePathString($"StrikeBark{Random.Range(0, 3).ToString()}");
		}

		switch (barks)
		{
			case Barks.GET_FOOD:
				story.ChoosePathString($"BarkFood{Random.Range(0, 4).ToString()}");
				break;
			case Barks.REMOVE_DEBRIE:
				story.ChoosePathString($"BarkDebrie{Random.Range(0, 4).ToString()}");
				break;
			case Barks.GET_DECOR_WATER:
				story.ChoosePathString($"BarkWater{Random.Range(0, 4).ToString()}");
				break;
			case Barks.GET_DECOR_FIRE:
				story.ChoosePathString($"BarkFire{Random.Range(0, 4).ToString()}");
				break;
			case Barks.GET_DECOR_EARTH:
				story.ChoosePathString($"BarkEarth{Random.Range(0, 4).ToString()}");
				break;
			case Barks.GET_DECOR_AIR:
				story.ChoosePathString($"BarkAir{Random.Range(0, 4).ToString()}");
				break;
			case Barks.GET_STONE:
				story.ChoosePathString($"BarkStone{Random.Range(0, 4).ToString()}");
				break;
			case Barks.GET_WOOD:
				story.ChoosePathString($"BarkWood{Random.Range(0, 4).ToString()}");
				break;
		}

		dude.ShowText(story.Continue());

	}

	private void SetExternalInkFunctions()
    {
        story.BindExternalFunction("GetName", (int p) => { return getName(p); });
        story.BindExternalFunction("GetSurname", (int p) => { return getSurname(p);  });
        story.BindExternalFunction("GetLike", (int p) => {  return getLike(p); });
        story.BindExternalFunction("GetDislike", (int p) => {  return getDislike(p); });
        story.BindExternalFunction("GetProficiency", (int p) => { return getProficiency(p); });
        story.BindExternalFunction("GetItem", (int p) => { return newItem.GetComponent<DecorationScript>().displayName; });
    }

	public void InkUseCitizens()
	{
		getName = delegate (int index) { return citizens[index].name; };
		getSurname = delegate (int index) { return citizens[index].surname; };
		getLike = delegate (int index) { return (int) citizens[index].like; };
		getDislike = delegate (int index) { return (int) citizens[index].dislike; };
		getDislike = delegate (int index) { return (int) citizens[index].proficience; };
	}

	public void InkUseOrdered()
	{
		getName = delegate (int index) { return orderedCitizensForStory[index].name; };
		getSurname = delegate (int index) { return orderedCitizensForStory[index].surname; };
		getLike = delegate (int index) { return (int)orderedCitizensForStory[index].like; };
		getDislike = delegate (int index) { return (int)orderedCitizensForStory[index].dislike; };
		getDislike = delegate (int index) { return (int)orderedCitizensForStory[index].proficience; };
	}

	private void ReorderCitizens(int i)
	{

		if (i == 0)
        {
            return;
        }

		if (i == orderedCitizensForStory.Count - 1)
        {
			orderedCitizensForStory.Reverse();
            return;
        }
        else
        {
            CitizenData placeholder;

			for (int j = 1; j <= i; j++)
			{
				placeholder = orderedCitizensForStory[j-1];
				orderedCitizensForStory[j-1] = orderedCitizensForStory[j];
				orderedCitizensForStory[j] = placeholder;
			}
            return;
        }
    }

    static public Theme BarkToTheme(Barks bark)
    {
        switch(bark)
        {
            case Barks.GET_DECOR_AIR: return Theme.AIR;
            case Barks.GET_DECOR_WATER: return Theme.WATER;
            case Barks.GET_DECOR_FIRE: return Theme.FIRE;
            case Barks.GET_DECOR_EARTH: return Theme.EARTH;
            default: return Theme.AIR;
        }
    }

    static public Barks ThemeToBark(Theme theme)
    {
        switch (theme)
        {
            case Theme.AIR: return Barks.GET_DECOR_AIR;
            case Theme.EARTH: return Barks.GET_DECOR_EARTH;
            case Theme.FIRE: return Barks.GET_DECOR_FIRE;
            case Theme.WATER: return Barks.GET_DECOR_WATER;
            default: return Barks.GET_DECOR_AIR;
        }
    }

}
