using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Theme {WATER, FIRE, EARTH, AIR}
public enum Animals { BEAR, BIRD, CAT, DOG, MOUSE, PIG}

[System.Serializable]
public class CitizenData
{
    public string name;
    public string surname;

	public Animals species;

    public GameObject tent;

    public Theme like;
    public Theme dislike;
    public Theme proficience;

    public bool revealedLike;
    public bool revealedDislike;
    public bool revealProficience;

    public Color color;
    
    public int strikes;

    List<string> names = new List<string>() {
        "Allegro", "Silvana",
        "Alpine", "Marceline",
        "Baron", "Masha",
        "Bentley", "Sarah",
        "Buttermilk'", "Yulia",
        "Cider", "Yukito",
        "Denali", "Whisky",
        "Kleidson", "Cosmo",
        "Figaro", "Luna",
        "Guru", "Maya",
        "Jigjag", "Flocos",
        "Mithra", "Dima",
        "Mocha", "Gretchen",
        "Nova", "Madgalina",
        "Rishi", "Kalinina",
        "Yukon", "Jocione",
        "Reese", "Olya",
        "Kamryn", "Vinizinho"
    };

    List<string> surnames = new List<string>(){
        "Makarovich", "Ivanovich",
        "Raposo", "Guio",
        "Pimpão", "Carneiro",
        "Cohen", "Lichtman",
        "Silva", "Sousa",
        "Bastos", "Barros",
        "Marques", "Garcia",
        "Moreno", "Gherman",
        "Nogueira", "Corrêa",
        "Barcellos", "Lima",
        "Mendonça", "Guina",
        "Moraes", "Valente",
        "Soares", "Bandeira",
        "Montes", "Domingues"
    };

    public static CitizenData CreateCitizen()
    {
        CitizenData citizen = new CitizenData();

        citizen.name = citizen.chooseName();
        citizen.surname = citizen.chooseSurname();

        citizen.like = (Theme)Random.Range(0, 3);
        citizen.proficience = (Theme)Random.Range(0, 3);

        do
        {
            citizen.dislike = (Theme)Random.Range(0, 3);
        } while (citizen.like == citizen.dislike || citizen.proficience == citizen.dislike);

		citizen.species = (Animals)Random.Range(0, 7);

        citizen.color = GetRandomVividColor();
        
		Debug.Log($"Like: {citizen.like}");
		Debug.Log($"Dislike: {citizen.dislike}");
		Debug.Log($"Proficience: {citizen.proficience}");
		Debug.Log($"Speciees: {citizen.species}");

        return citizen;

    }

    string chooseName() {
        int index = Random.Range(0, names.Count);
        Debug.Log(names[index]);
        return names[index];
    }

    string chooseSurname()
    {
        int index = Random.Range(0, surnames.Count);
        Debug.Log(surnames[index]);
        return surnames[index];
    }

    public static Color GetRandomVividColor()
    {
        float h = Random.Range(0f, 1f);
        float s = 1;
        float v = 1;

        return Color.HSVToRGB(h, s, v);

    }

}
