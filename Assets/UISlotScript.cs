using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlotScript : MonoBehaviour
{
	protected SlotType type;
	public bool filed;

	private Theme content;

	protected Theme? Content { get {

			if (!filed)
				return null;
			else
				return content;

		}

		set => content = value.Value; }
		
}
