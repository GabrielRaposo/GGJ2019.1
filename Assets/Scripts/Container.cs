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

	public TextMeshProUGUI text;

	public int Amount { get => amount; set { if (value < 0) { amount = 0; } else { amount = value; } text.text = value.ToString(); } }

	private void Awake()
	{
		Amount = amount;
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
