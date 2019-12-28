using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class CitizenBehaviour : MonoBehaviour, IPointerClickHandler
{
	GameManager gameManager;
    public CitizenData citizenData;

	public bool hasTent;
    public GameObject tent;
	public delegate void TurnAction();
	public TurnAction turnAction = null;
	public actions turnActionType;
	public GameObject textBox;
	public TextMeshProUGUI text;

	public UnityEngine.UI.Image circleIndicator;
	public ActionMarkers actionMarker;
	
	public int strikes;

    private bool isClickable;
    public bool IsClickable
    {
        get { return isClickable; }
        set { isClickable = value; }
    }

    public CitizenData CitizenData
    {
        get { return citizenData; }
        set { citizenData = value; }
    }
	
    void Awake()
    {
        isClickable = true;
        hasTent = false;
        tent = null;
        turnActionType = actions.none;
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        citizenData = CitizenData.CreateCitizen();
    }
    
	public void SetShowInfo(bool value)
	{
		transform.GetChild(0).gameObject.SetActive(value);
	}
    
    public void HideInfo()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void SetHighlightInteractableAll(bool value)
    {
        foreach (GameObject gameObject in gameManager.GetInteractableItemsInCurrentDay)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(value);
        }
    }

    public void SetHighlightInteractableScpecific(bool value)
	{
		foreach (GameObject gameObject in gameManager.GetInteractableItemsInCurrentDay)
		{
			if (!hasTent)
			{
				if (gameObject.CompareTag("tent") && gameObject.GetComponent<TentBehaviour>().CitizenOwner == null)
				{
					gameObject.transform.GetChild(0).gameObject.SetActive(value);
				}
				continue;
			}
			if (!gameObject.CompareTag("tent"))
			{
				gameObject.transform.GetChild(0).gameObject.SetActive(value);
			}
		}
	}

	public void SetTurnAction(TurnAction action, actions actionType)
	{
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
		if (!IsClickable) return;
		
		if (gameManager.SelectedCitizen == null)
		{
			ClickSelect();
		}
		else
		{
			if (gameManager.SelectedCitizen == gameObject)
			{
				ClickDeselect();
			}
			else
			{
				gameManager.SelectedCitizen.GetComponent<CitizenBehaviour>().ClickDeselect();
				ClickSelect();
			}
		}
	}

	public void SetClickable(bool value)
	{
		isClickable = value;
		if (!value)
			GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, .7f); 
		else
			GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 1f);
	}

	public void ClickSelect()
	{
		gameManager.SelectedCitizen = gameObject;
		SetShowInfo(true);
		SetHighlightInteractableScpecific(true);
	}

	public void ClickDeselect()
	{
		gameManager.SelectedCitizen = null;
		SetShowInfo(false);
		SetHighlightInteractableAll(false);
	}

	public void ClickDeselectVisualOnly()
	{
		SetShowInfo(false);
		SetHighlightInteractableAll(false);
	}
	

	public void ShowText(string recievedText)
	{
		text.text = recievedText;
		textBox.SetActive(true);
		textBox.GetComponentInChildren<Image>().color = Color.white;
		text.color = Color.white;
		StartCoroutine(FadeText(4.0f));
	}

	IEnumerator FadeText(float duration)
	{
		RectTransform rect = textBox.GetComponent<RectTransform>();
		Vector2 basePos = rect.anchoredPosition;
		Image img = textBox.GetComponentInChildren<Image>();
		
		Vector2 startingPos = new Vector2(basePos.x, basePos.y - 0.4f);
		text.color = Color.clear;
		img.color = Color.clear;

		float spawnTime = 0.33f;
		float clock = 0;

		Color curentColor;
		
		rect.anchoredPosition = startingPos;
		while (clock<spawnTime)
		{
			clock += Time.deltaTime;
			
			rect.anchoredPosition = Vector2.Lerp(startingPos, basePos, (clock/spawnTime));
			curentColor = new Color(1f,1f,1f,Mathf.Lerp(0,1,clock/spawnTime));
			text.color = curentColor;
			img.color = curentColor;
			yield return null;

		}
		
		
		yield return new WaitForSeconds(duration);

		while(textBox.GetComponentInChildren<Image>().color.a > 0)
		{
			
			
			textBox.GetComponentInChildren<Image>().color = new Vector4(1, 1, 1, textBox.GetComponentInChildren<Image>().color.a - Time.deltaTime);
			text.color = new Vector4(1, 1, 1, text.color.a - Time.deltaTime);
			yield return null;
		}
		textBox.SetActive(false);
	}
}
