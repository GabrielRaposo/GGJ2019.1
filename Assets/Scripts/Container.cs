using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Container : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public Barks type;
	[SerializeField] private int amount;

	public TextMeshProUGUI text;

	public int Amount { get => amount; set { if (value < 0) { amount = 0; } else { amount = value; } text.text = value.ToString(); } }

	public bool TryRemoveOne()
	{
		if(amount == 0)
		{
			return false;
		}
		else
		{
			amount--;
			return true;
		}
	}

	public void AddOne()
	{
		amount++;
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
        amount -= 1;
        print("Aloo");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print(eventData.pointerCurrentRaycast.isValid);
        if (!eventData.pointerCurrentRaycast.isValid)
        {
            amount += 1;
            return;
        }
        StoneSlot stoneSlot = eventData.pointerCurrentRaycast.gameObject.GetComponent<StoneSlot>();
        print(eventData.pointerCurrentRaycast.gameObject.name);
        if (stoneSlot == null || !stoneSlot.AssertSlot(type))
        {
            amount += 1;
            return;
        }
        stoneSlot.Fill();
    }

}
