using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodTileBehaviour : MonoBehaviour, IPointerClickHandler
{

	GameManager gameManager;
	public ActionMarkers actionMarkers;
	private StoryMaster storyMaster;
	
    void Start()
    {
		gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
		storyMaster = FindObjectOfType<StoryMaster>();
    }


	public void CollectFood()
	{
		gameManager.FoodQuantity = 3;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (gameManager.SelectedCitizen != null)
		{
			if (!gameManager.SelectedCitizen.GetComponent<CitizenBehaviour>().hasTent)
			{
				gameManager.SelectedCitizen.GetComponent<CitizenBehaviour>().ClickDeselect();
				return;
			}
			
			if (gameManager.GetInteractableItemsInCurrentDay.Exists(go => go == gameObject))
			{
				CitizenBehaviour selectedCitizenBehaviour = gameManager.SelectedCitizen.GetComponent<CitizenBehaviour>();
				Debug.Log($"{selectedCitizenBehaviour.name} vai pegar comida");
				
				if(selectedCitizenBehaviour.actionMarker != null)
					selectedCitizenBehaviour.actionMarker.RemoveCitizen(selectedCitizenBehaviour);
				
				actionMarkers.AddCitizen(selectedCitizenBehaviour);
				storyMaster.Bark(Barks.GET_FOOD, selectedCitizenBehaviour);
				
				selectedCitizenBehaviour.ClickDeselect();
				selectedCitizenBehaviour.SetTurnAction(
					delegate () {
						selectedCitizenBehaviour.OnPointerClick(null);
						CollectFood();
					}, actions.getFood);
			}
		}
	}

}
