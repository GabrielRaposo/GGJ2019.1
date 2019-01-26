using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftMaster : MonoBehaviour
{
	public TMP_Dropdown dropdown;

	public List<SORecipe> recipes;

	public GameObject decorationSlot;
	public GameObject inspirationSlot;
	public GameObject woodSlot;
	public GameObject stoneSlot;

	public Canvas canvas;

	public List<GameObject> slots;

	private void Awake()
	{
		dropdown.onValueChanged.AddListener(UpdateSlots);
		dropdown.options.Clear();

		foreach (SORecipe r in recipes)
		{
			dropdown.options.Add(new TMP_Dropdown.OptionData(r.name));
		}

		dropdown.captionText.text = "Select Recipe";

		foreach (GameObject s in slots)
		{
			s.SetActive(false);
		}

	}

	private void UpdateSlots(int x)
	{
		Debug.Log($"UPDATE SLOTS {x}");
		SORecipe currentRecipe = recipes[x];

		for(int i = 0; i < slots.Count; i++)
		{
			if (i < currentRecipe.slots.Count)
			{
				slots[i].SetActive(true);

				Vector3 position = slots[i].transform.position;
				Quaternion rotation = slots[i].transform.rotation;

				Destroy(slots[i]);

				switch (currentRecipe.slots[i].type)
				{
					case SlotType.STONE:
						slots[i] = Instantiate(stoneSlot, position, rotation, canvas.transform);
						break;
					case SlotType.WOOD:
						slots[i] = Instantiate(woodSlot, position, rotation, canvas.transform);
						break;
					case SlotType.DECORATION:
						slots[i] = Instantiate(decorationSlot, position, rotation, canvas.transform);
						break;
					case SlotType.INSPIRATION:
						slots[i] = Instantiate(inspirationSlot, position, rotation, canvas.transform);
						break;
				}
				
			}
			else
			{
				slots[i].SetActive(false);
			}
		}

	}

}
