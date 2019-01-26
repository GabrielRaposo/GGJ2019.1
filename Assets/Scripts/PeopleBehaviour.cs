using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleBehaviour : MonoBehaviour
{

	[SerializeField] GameObject citizenPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNewcomers(int quantity) {
        for (int i = 0; i < quantity; i++) {
            GameObject newcomer = Instantiate(citizenPrefab, new Vector2(i + 1.5f, 1.5f), Quaternion.identity);
        }
    }
}
