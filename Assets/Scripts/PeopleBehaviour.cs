using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleBehaviour : MonoBehaviour
{

	[SerializeField] GameObject citizenPrefab;
    [SerializeField] StoryMaster storyMaster;

    public void SpawnNewcomers(int quantity) {
        for (int i = 0; i < quantity; i++) {
            GameObject newcomer = Instantiate(citizenPrefab, new Vector2(i + 1.5f, 1.5f), Quaternion.identity);
            storyMaster.citizens.Add(newcomer.GetComponent<CitizenBehaviour>().CitizenData);
        }
    }
}
