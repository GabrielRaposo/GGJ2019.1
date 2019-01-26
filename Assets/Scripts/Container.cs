using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Container : MonoBehaviour
{
	public Barks type;
	private int amount;

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

}
