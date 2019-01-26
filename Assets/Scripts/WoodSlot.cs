using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodSlot : UISlotScript
{
	public Sprite filledImage;
	public Sprite emptyImage;

	public Image display;

	private void Awake()
	{
		type = SlotType.WOOD;
		display.sprite = emptyImage;
	}

	public void Fill()
	{
		filed = true;
		display.sprite = filledImage;
	}

	public void Remove()
	{
		filed = false;
		display.sprite = emptyImage;
	}

	public void Fill(Theme theme)
	{
		Remove();
	}

	public void Swap(Theme theme)
	{
		Remove();
	}
}
