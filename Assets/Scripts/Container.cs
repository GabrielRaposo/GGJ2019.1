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
        isResourceInUse = TryRemoveOne();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isResourceInUse) return;
        isResourceInUse = false;
        if (!eventData.pointerCurrentRaycast.isValid)
        {
            amount += 1;
            return;
        }
        UISlotScript slot = eventData.pointerCurrentRaycast.gameObject.GetComponent<UISlotScript>();
        if (slot == null || !slot.AssertSlot(type))
        {
            amount += 1;
            return;
        }
        print(slot.ContentType);
        if (slot.ContentType != null)
        {
            GameObject container = GameObject.FindGameObjectWithTag("container-" + StoryMaster.BarkToTheme(slot.ContentType.Value).ToString().ToLower());
            print(container);
            container.GetComponent<Container>().AddOne();
        }
        if (eventData.pointerCurrentRaycast.gameObject.GetComponent<DecorationSlot>() != null)
        {
            slot.Fill(StoryMaster.BarkToTheme(type));
                return;
        }
        slot.Fill();
    }

}
