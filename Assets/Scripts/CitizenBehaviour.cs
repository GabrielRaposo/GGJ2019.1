using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CitizenBehaviour : MonoBehaviour, IPointerClickHandler
{

	[SerializeField] GameManager gameManager;
	public bool hasTent;

	public delegate void TurnAction();
	public TurnAction turnAction = null;
	public actions turnActionType;
	public GameObject textBox;
	public TextMeshProUGUI text;

	public int strikes;
	
	// Start is called before the first frame update
	void Start()
	{
		hasTent = false;
		turnActionType = actions.none;
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

	public void ShowText(string recievedText)
	{
		text.text = recievedText;
		textBox.SetActive(true);
		textBox.GetComponent<SpriteRenderer>().color = Color.white;
		text.color = Color.white;
		StartCoroutine(FadeText(4.0f));
	}

	IEnumerator FadeText(float duration)
	{
		yield return new WaitForSeconds(duration);

		while(textBox.GetComponent<SpriteRenderer>().color.a > 0)
		{
			textBox.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, textBox.GetComponent<SpriteRenderer>().color.a - Time.deltaTime);
			text.color = new Vector4(1, 1, 1, text.color.a - Time.deltaTime);
			yield return null;
		}
		textBox.SetActive(false);

	}
}
