using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CitizenBehaviour : MonoBehaviour, IPointerClickHandler
{
	GameManager gameManager;

	public bool hasTent;
	public delegate void TurnAction();
	public TurnAction turnAction = null;
	public actions turnActionType;
	
	// Start is called before the first frame update
	void Start()
	{
		hasTent = false;
		turnActionType = actions.none;
		gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
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
		foreach (GameObject gameObject in gameManager.GetInteractableItemsInCurrentDay)
		{
			if (!hasTent)
			{
				if (gameObject.CompareTag("tent"))
				{
					gameObject.transform.GetChild(0).gameObject.SetActive(!gameObject.transform.GetChild(0).gameObject.activeSelf);
				}
				continue;
			}
			if (!gameObject.CompareTag("tent"))
			{
				Debug.Log(gameObject);
				gameObject.transform.GetChild(0).gameObject.SetActive(!gameObject.transform.GetChild(0).gameObject.activeSelf);
			}
		}
	}

	public void SetTurnAction(TurnAction action, actions actionType) {
		turnAction = action;
		turnActionType = actionType;
	}

	public void ResetTurnAction()
	{
		turnAction = delegate () { };
		turnActionType = actions.none;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (gameManager.SelectedCitizen == null)
		{
			gameManager.SelectedCitizen = gameObject;
			Debug.Log(gameManager.SelectedCitizen);
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
