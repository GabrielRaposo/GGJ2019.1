using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TentBehaviour : MonoBehaviour, IPointerClickHandler
{

	[SerializeField] private GameObject citizenOwner;

	public GameObject CitizenOwner
	{
		get { return citizenOwner; }
		set { citizenOwner = value; }
	}

	public GameManager gameManager;

	// Start is called before the first frame update
	void Start()
    {
		gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log($"{gameObject}: Click tent");
	
		if (gameManager.SelectedCitizen != null && citizenOwner == null)
		{
			if (gameManager.GetInteractableItemsInCurrentDay.Exists(go => go == gameObject))
			{
				CitizenBehaviour selectedCitizenBehaviour = gameManager.SelectedCitizen.GetComponent<CitizenBehaviour>();
				Debug.Log($"{selectedCitizenBehaviour.name} vai limpar a tenda {gameObject}");
				selectedCitizenBehaviour.SetTurnAction(
					delegate () {
						citizenOwner = gameManager.SelectedCitizen;
						selectedCitizenBehaviour.OnPointerClick(null);
						selectedCitizenBehaviour.hasTent = true;
                        selectedCitizenBehaviour.tent = this.gameObject;
					}, actions.cleanTent);
			}
		} 
	}

}
