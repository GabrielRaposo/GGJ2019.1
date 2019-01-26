using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleBehaviour : MonoBehaviour
{
	[SerializeField] GameObject citizenPrefab;
    [SerializeField] GameObject go;

    [SerializeField] int SpawnY = 3;
    [SerializeField] int SpawnX = 5;

    void Update() {
        //if (Input.GetKeyDown(KeyCode.Space)) {
        //    kickCitizen(go);
        //}
    } 

    public void SpawnNewcomers(int quantity) {
        for (int i = 0; i < quantity; i++) {

            float posY = Random.Range(-SpawnY, SpawnY) + 0.5f;
            float posX = Random.Range(-SpawnX, SpawnX) + 0.5f;

            GameObject newcomer = Instantiate(citizenPrefab, new Vector2(posX, posY), Quaternion.identity);
        }
    }

    public void kickCitizen(GameObject citizen) {
        //desassociar tenda da pessoa
        citizen.GetComponent<CitizenBehaviour>().hasTent = false;
        citizen.GetComponent<CitizenBehaviour>().tent.GetComponent<TentBehaviour>().CitizenOwner = null;
        citizen.GetComponent<CitizenBehaviour>().tent = null;

        //destruir go da pessoa
        Destroy(citizen.gameObject);
    }
}
