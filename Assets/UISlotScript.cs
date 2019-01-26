using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlotScript : MonoBehaviour
{
	protected SlotType type;
	public bool filed;

    private Barks contentType;
	private Theme content;

	protected Theme? Content { get {

			if (!filed)
				return null;
			else
				return content;

		}

		set => content = value.Value; }

    public Barks? ContentType
    {
        get
        {

            if (!filed)
                return null;
            else
                return contentType;

        }

        set => contentType = value.Value;
    }

    public virtual void Fill(CitizenData citizenData) { }
    public virtual void Fill(Theme theme) { }
    public virtual void Fill() { }


    public virtual void Remove() { }

    public virtual bool AssertSlot(Barks barks) { return false; }
}
