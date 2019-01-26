using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecorationSlot : UISlotScript
{
	public Sprite filledImageW;
	public Sprite filledImageE;
	public Sprite filledImageF;
	public Sprite filledImageA;

	public Sprite emptyImage;

	public Image display;

	private void Awake()
	{
		type = SlotType.DECORATION;
		display.sprite = emptyImage;

	}

	public override void Fill(Theme theme)
	{
		filed = true;

		Content = theme;
        ContentType = StoryMaster.ThemeToBark(theme);
    
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

    public override bool AssertSlot(Barks barks)
    {
        return (barks == Barks.GET_DECOR_AIR || barks == Barks.GET_DECOR_EARTH || barks == Barks.GET_DECOR_FIRE || barks == Barks.GET_DECOR_WATER);
    }

    public void Swap(Theme theme)
	{
		Fill(theme);
	}

	public override void Remove()
	{
		filed = false;
		display.sprite = emptyImage;
	}

}
