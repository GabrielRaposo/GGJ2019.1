﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodTileBehaviour : MonoBehaviour, IPointerClickHandler
{

	GameManager gameManager;
	public ActionMarkers actionMarkers;

    // Start is called before the first frame update
    void Start()
    {
		gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

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
