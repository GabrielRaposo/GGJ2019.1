using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Container : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool isResourceInUse = false;

	public Barks type;
	[SerializeField] private int amount;
    [SerializeField] private GameManager gameManager;

	public TextMeshProUGUI text;

	public int Amount { get => amount; set { if (value < 0) { amount = 0; } else { amount = value; } text.text = value.ToString(); } }

	private void Awake()
	{
		Amount = amount;
	}

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        print(type);
        if (type == Barks.GET_DECOR_AIR || type == Barks.GET_DECOR_EARTH || type == Barks.GET_DECOR_FIRE || type == Barks.GET_DECOR_WATER)
            Amount = gameManager.GetComponent<MaterialManager>().decorations[StoryMaster.BarkToTheme(type)];
        if (type == Barks.GET_STONE)
            Amount = gameManager.GetComponent<MaterialManager>().Stone;
        if (type == Barks.GET_WOOD)
            Amount = gameManager.GetComponent<MaterialManager>().Wood;
    }

    public bool TryRemoveOne()
	{
		if(Amount == 0)
		{
			return false;
		}
		else
		{
			Amount--;
			return true;
		}
	}

	public void AddOne()
	{
		Amount++;
	}

	public bool TryGiveItem(ItemCursor cursor)
	{
		if (TryRemoveOne())
		{
			cursor.heldItem = type;
			cursor.adress = this;
			return true;
		}
		else
			return false;
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        isResourceInUse = TryRemoveOne();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isResourceInUse) return;
        isResourceInUse = false;
        if (!eventData.pointerCurrentRaycast.isValid)
        {
            Amount += 1;
            return;
        }
        UISlotScript slot = eventData.pointerCurrentRaycast.gameObject.GetComponent<UISlotScript>();
        if (slot == null || !slot.AssertSlot(type))
        {
            Amount += 1;
            return;
        }
        if (slot.Container != null)
        {
            slot.Container.AddOne();
        }
        slot.Container = this;
        if (eventData.pointerCurrentRaycast.gameObject.GetComponent<DecorationSlot>() != null)
        {
            slot.Fill(StoryMaster.BarkToTheme(type));
            return;
        }
        slot.Fill();
    }

}
