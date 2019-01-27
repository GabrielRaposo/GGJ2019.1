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

    List<string> names = new List<string>() {
        "Allegro",
        "Alpine",
        "Baron",
        "Bentley",
        "Buttermilk'",
        "Cider",
        "Denali",
        "Ermine",
        "Figaro",
        "Guru",
        "Jigjag",
        "Mithra",
        "Mocha",
        "Nova",
        "Rishi",
        "Yukon",
        "Reese",
        "Kamryn"
    };

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

    string chooseName() {
        int index = Random.Range(0, names.Count);
        Debug.Log(names[index]);
        return names[index];
    }

}
