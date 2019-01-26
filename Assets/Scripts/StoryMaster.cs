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

    public List<CitizenData> citizens;

    private void Awake()
    {
        story = new Story(inkAsset.text);
        story.ChoosePathString("Leaving_camp");

        citizens = new List<CitizenData> { new CitizenData(), new CitizenData(), new CitizenData(), new CitizenData() };

        SetExternalInkFunctions();

        text.text = "";

        
        text.text += story.Continue();       
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (story.canContinue)
            {
                text.text = story.Continue();
            }
            else
            {
                //Segue para proximo ponto da historia ou do jogo
            }
        }       
    }

    private void BasicSelectionBetweenScenes()
    {
        int i = 0;
        int r = 0;

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

        for(int j = 0; j < citizens.Count; j++)
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
				story.ChoosePathString($"LikeWater{Random.Range(0,4).ToString()}");
				break;
			case Theme.FIRE:
				story.ChoosePathString($"LikeFire{Random.Range(0, 4).ToString()}");
				break;
			case Theme.EARTH:
				story.ChoosePathString($"LikeEarth{Random.Range(0, 4).ToString()}");
				break;
			case Theme.AIR:
				story.ChoosePathString($"LikeAir{Random.Range(0, 4).ToString()}");
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
				story.ChoosePathString($"DislikeWater{Random.Range(0, 4).ToString()}");
				break;
			case Theme.FIRE:
				story.ChoosePathString($"DislikeFire{Random.Range(0, 4).ToString()}");
				break;
			case Theme.EARTH:
				story.ChoosePathString($"DislikeEarth{Random.Range(0, 4).ToString()}");
				break;
			case Theme.AIR:
				story.ChoosePathString($"DislikeAir{Random.Range(0, 4).ToString()}");
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
				story.ChoosePathString($"ProficienceWater{Random.Range(0, 4).ToString()}");
				break;
			case Theme.FIRE:
				story.ChoosePathString($"ProficienceFire{Random.Range(0, 4).ToString()}");
				break;
			case Theme.EARTH:
				story.ChoosePathString($"ProficienceEarth{Random.Range(0, 4).ToString()}");
				break;
			case Theme.AIR:
				story.ChoosePathString($"ProficienceWater{Random.Range(0, 4).ToString()}");
				break;
		}
	}

	public void Bark(Barks barks)
	{
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
	}

	private void SetExternalInkFunctions()
    {
        story.BindExternalFunction("GetName", (int p) => { return citizens[p].citizenName; });
        story.BindExternalFunction("GetSurname", (int p) => { return citizens[p].citizenSurname; });
        story.BindExternalFunction("GetLike", (int p) => { return (int)citizens[p].like; });
        story.BindExternalFunction("GetDislike", (int p) => { return (int)citizens[p].dislike; });
        story.BindExternalFunction("GetProficiency", (int p) => { return (int)citizens[p].proficience; });
    }

    private void ReorderCitizens(int i)
    {
        if(i == 0)
        {
            return;
        }
        if(i == citizens.Count - 1)
        {
            citizens.Reverse();
            return;
        }
        else
        {
            CitizenData placeHolder;

            placeHolder = citizens[0];
            citizens[0] = citizens[i];
            citizens[i] = placeHolder;
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
