using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;

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

        citizens[0].citizenName = "Joao";
        citizens[1].citizenName = "Roberto";
        citizens[2].citizenName = "Carlinhos";
        citizens[3].citizenName = "Maria";


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
                //Segue para proximo ponto da historia
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
                    ReorderCitizens(j);
                    citizens[j].revealedLike = true;
                    //Go To reveal like story
                }
            }
            if (!citizens[j].revealedDislike)
            {
                r--;
                if(r == 0)
                {
                    ReorderCitizens(j);
                    citizens[j].revealedDislike = true;
                    // Go to reveal dislike story
                }
            }
            if (!citizens[j].revealProficience)
            {
                r--;
                if(r == 0)
                {
                    ReorderCitizens(j);
                    citizens[j].revealProficience = true;
                    //go to reveal proficience story
                }
            }
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

}
