using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TentBehaviour : MonoBehaviour, IPointerClickHandler
{

	[SerializeField] private GameObject citizenOwner;
	public Sprite builtTentSprite;
	public Transform ownerPosition;
	
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
				selectedCitizenBehaviour.ClickDeselect();
				selectedCitizenBehaviour.SetTurnAction(
					delegate () {
						SetOwner(selectedCitizenBehaviour);
						selectedCitizenBehaviour.OnPointerClick(null);
					}, actions.cleanTent);
			}
		} 
	}

	private void SetOwner(CitizenBehaviour citizen)
	{
		GetComponent<SpriteRenderer>().sprite = builtTentSprite;
		GetComponent<SpriteRenderer>().color = TentAdjustedColor(citizen.citizenData.color);
		citizenOwner = citizen.gameObject;
		citizen.hasTent = true;
		citizen.tent = gameObject;
	}

	public void RemoveOwner()
	{
		citizenOwner.GetComponent<CitizenBehaviour>().hasTent = false;
		citizenOwner.GetComponent<CitizenBehaviour>().tent = null;
		citizenOwner = null;
		GetComponent<SpriteRenderer>().color = Color.grey;
	}

	//60 75
	public Color TentAdjustedColor(Color baseColor)
	{
		Color.RGBToHSV(baseColor, out var h, out var s, out var v);

		s = 0.6f;
		v = 0.75f;

		return Color.HSVToRGB(h, s, v);

	}

}
