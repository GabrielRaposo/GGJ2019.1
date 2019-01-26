using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CitizenBehaviour : MonoBehaviour, IPointerClickHandler
{

	[SerializeField] GameManager gameManager;
	public bool hasTent;

    // Start is called before the first frame update
    void Start()
    {
		hasTent = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void ShowInfo()
	{
		transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeSelf);
	}

	public void HighlightInteractable()
	{
		List<GameObject> itemsCurrentDay = gameManager.GetInteractableItemsInCurrentDay;
		foreach (GameObject gameObject in itemsCurrentDay)
		{
			if (gameObject.CompareTag("tent"))
			{
				if (!hasTent)
				{
					gameObject.transform.GetChild(0).gameObject.SetActive(!gameObject.transform.GetChild(0).gameObject.activeSelf);
				}
				continue;
			}
			gameObject.transform.GetChild(0).gameObject.SetActive(!gameObject.transform.GetChild(0).gameObject.activeSelf);
		}
	}
	
	public void OnPointerClick(PointerEventData eventData)
	{
		if (gameManager.SelectedCitizen == null)
		{
			gameManager.SelectedCitizen = gameObject;
			ShowInfo();
			HighlightInteractable();
		} else
		{
			if (gameManager.SelectedCitizen == gameObject)
			{
				gameManager.SelectedCitizen = null;
				ShowInfo();
				HighlightInteractable();
			}
		}
	}
}
