using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Theme {WATER, FIRE, EARTH, AIR}

public class CitizenData
{
    public string citizenName;
    public string citizenSurname;

    public GameObject tent;

    public Theme like;
    public Theme dislike;
    public Theme proficience;

    public bool revealedLike;
    public bool revealedDislike;
    public bool revealProficience;

    public int strikes;
    
    public static CitizenData CreateCitizen()
    {
        CitizenData citizen = new CitizenData();

        citizen.like = (Theme)Random.Range(0, 3);
        citizen.proficience = (Theme)Random.Range(0, 3);

        do
        {
            citizen.dislike = (Theme)Random.Range(0, 3);
        } while (citizen.like == citizen.dislike || citizen.proficience == citizen.dislike);

        return citizen;

    }

}
