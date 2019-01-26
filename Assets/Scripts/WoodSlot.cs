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

	public override void Fill()
	{
		filed = true;
		display.sprite = filledImage;
	}

	public override void Remove()
	{
		filed = false;
		display.sprite = emptyImage;
	}
}
