﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspirationSlot : UISlotScript
{
	public Sprite filledImageW;
	public Sprite filledImageE;
	public Sprite filledImageF;
	public Sprite filledImageA;

	public Sprite emptyImage;

	public Image display;


	private void Awake()
	{
		type = SlotType.INSPIRATION;
		display.sprite = emptyImage;

	}

	public void Fill()
	{
		Remove();
	}

	public void Fill(Theme theme)
	{
		filed = true;

		Content = theme;

		switch (theme)
		{
			case Theme.WATER:
				display.sprite = filledImageW;
				break;
			case Theme.FIRE:
				display.sprite = filledImageF;
				break;
			case Theme.EARTH:
				display.sprite = filledImageE;
				break;
			case Theme.AIR:
				display.sprite = filledImageA;
				break;
		}
	}

	public void Fill(CitizenData citizen)
	{
		Fill(citizen.proficience);
	}

	public void Remove()
	{
		filed = false;
		display.sprite = emptyImage;
	}

	public void Swap(Theme theme)
	{
		Fill(theme);
	}

}