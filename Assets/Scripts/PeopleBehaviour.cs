using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleBehaviour : MonoBehaviour
{
	[SerializeField] GameObject citizenPrefab;
    [SerializeField] StoryMaster storyMaster;
    [SerializeField] GameObject go;

    List<GameObject> toBeDestroyed = new List<GameObject>();

    public Material bearMaterial;
	public Material pigMaterial;
	public Material birdMaterial;
	public Material dogMaterial;
	public Material mouseMaterial;
	public Material catMaterial;

	public Sprite bearSprite;
	public Sprite pigSprite;
	public Sprite birdSprite;
	public Sprite dogSprite;
	public Sprite mouseSprite;
	public Sprite catSprite;


    void Update() {
    } 

    public void SpawnNewcomers(int quantity) {
        for (int i = 0; i < quantity; i++) {

            float posY = Random.Range(-3, 3) + 0.5f;
            float posX = Random.Range(-5, 5) + 0.5f;

            GameObject newcomer = Instantiate(citizenPrefab, new Vector3(0.5f, 0.5f, -1f), Quaternion.identity);
            Debug.Log("[x: " + newcomer.transform.position.x + ", y: " + newcomer.transform.position.y + " ]");

			switch (newcomer.GetComponent<CitizenBehaviour>().citizenData.species)
			{
				case Animals.BEAR:
					newcomer.GetComponent<SpriteRenderer>().material = bearMaterial;
					newcomer.GetComponent<SpriteRenderer>().sprite = bearSprite;
					break;
				case Animals.BIRD:
					newcomer.GetComponent<SpriteRenderer>().material = birdMaterial;
					newcomer.GetComponent<SpriteRenderer>().sprite = birdSprite;
					break;
				case Animals.CAT:
					newcomer.GetComponent<SpriteRenderer>().material = catMaterial;
					newcomer.GetComponent<SpriteRenderer>().sprite = catSprite;
					break;
				case Animals.DOG:
					newcomer.GetComponent<SpriteRenderer>().material = dogMaterial;
					newcomer.GetComponent<SpriteRenderer>().sprite = dogSprite;
					break;
				case Animals.MOUSE:
					newcomer.GetComponent<SpriteRenderer>().material = mouseMaterial;
					newcomer.GetComponent<SpriteRenderer>().sprite = mouseSprite;
					break;
				case Animals.PIG:
					newcomer.GetComponent<SpriteRenderer>().material = pigMaterial;
					newcomer.GetComponent<SpriteRenderer>().sprite = pigSprite;
					break;
			}

		}
	}

	public void kickCitizen(GameObject citizen) {
        //desassociar tenda da pessoa
        citizen.GetComponent<CitizenBehaviour>().hasTent = false;
        citizen.GetComponent<CitizenBehaviour>().tent.GetComponent<TentBehaviour>().CitizenOwner = null;
        citizen.GetComponent<CitizenBehaviour>().tent = null;

        //adiciona na listinha de destuicao
        toBeDestroyed.Add(citizen.gameObject);
    }
}
