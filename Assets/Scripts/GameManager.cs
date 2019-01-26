using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	private DayBehaviour dayBehaviour;
	private GameObject selectedCitizen;

	public GameObject SelectedCitizen
	{
		get { return selectedCitizen; }
		set { selectedCitizen = value; }
	}

	public List<GameObject> GetInteractableItemsInCurrentDay
	{
		get
		{
			dayBehaviour.InitInteractableObjects();
			return dayBehaviour.interactableItemsInCurrentDay;
		}
	}

	// Start is called before the first frame update
	void Start()
    {
		dayBehaviour = GetComponent<DayBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
