using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PeopleBehaviour : MonoBehaviour
{
	[SerializeField] GameObject citizenPrefab;
    [SerializeField] StoryMaster storyMaster;
    [SerializeField] GameObject go;

    List<GameObject> toBeDestroyed = new List<GameObject>();

//    public Material bearMaterial;
//	public Material pigMaterial;
//	public Material birdMaterial;
//	public Material dogMaterial;
//	public Material mouseMaterial;
//	public Material catMaterial;

	public Sprite bearSprite;
	public Sprite pigSprite;
	public Sprite birdSprite;
	public Sprite dogSprite;
	public Sprite mouseSprite;
	public Sprite catSprite;

	private void Awake()
	{
		SetCitizenVisual(go);
		
	}

	public void SpawnNewcomers(int quantity) {
        for (int i = 0; i < quantity; i++) {

            float posY = Random.Range(-3, 3) + 0.5f;
            float posX = Random.Range(-5, 5) + 0.5f;

            GameObject newcomer = Instantiate(citizenPrefab, new Vector3(0.5f, 0.5f, -1f), Quaternion.identity);
            Debug.Log("[x: " + newcomer.transform.position.x + ", y: " + newcomer.transform.position.y + " ]");
			
			SetCitizenVisual(newcomer);

        }
	}

	private void SetCitizenVisual(GameObject citizen)
	{
		switch (citizen.GetComponent<CitizenBehaviour>().CitizenData.species)
		{
			case Animals.BEAR:
				//newcomer.GetComponent<SpriteRenderer>().material = bearMaterial;
				citizen.GetComponent<SpriteRenderer>().sprite = bearSprite;
				break;
			case Animals.BIRD:
				//newcomer.GetComponent<SpriteRenderer>().material = birdMaterial;
				citizen.GetComponent<SpriteRenderer>().sprite = birdSprite;
				break;
			case Animals.CAT:
				//newcomer.GetComponent<SpriteRenderer>().material = catMaterial;
				citizen.GetComponent<SpriteRenderer>().sprite = catSprite;
				break;
			case Animals.DOG:
				//newcomer.GetComponent<SpriteRenderer>().material = dogMaterial;
				citizen.GetComponent<SpriteRenderer>().sprite = dogSprite;
				break;
			case Animals.MOUSE:
				//newcomer.GetComponent<SpriteRenderer>().material = mouseMaterial;
				citizen.GetComponent<SpriteRenderer>().sprite = mouseSprite;
				break;
			case Animals.PIG:
				//newcomer.GetComponent<SpriteRenderer>().material = pigMaterial;
				citizen.GetComponent<SpriteRenderer>().sprite = pigSprite;
				break;
		}

		citizen.GetComponent<SpriteRenderer>().color =
			GetSoftColor(citizen.GetComponent<CitizenBehaviour>().citizenData.color);
	}

	public Color GetSoftColor(Color color)
	{
		Color.RGBToHSV(color, out float h, out float s, out float v);

		s = 0.25f;

		return Color.HSVToRGB(h, s, v);

	}

	public void kickCitizen(GameObject citizen) {
        //desassociar tenda da pessoa
        citizen.GetComponent<CitizenBehaviour>().tent.GetComponent<TentBehaviour>().RemoveOwner();

        //adiciona na listinha de destuicao
        toBeDestroyed.Add(citizen.gameObject);
    }
}
