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

	SORecipe currentRecipe;

	public List<GameObject> slots;

	public Button confirmButton;

	public CitizenData crafter;

	public bool checkFunction;

	public GameObject craftedObject;

    public CraftTileBehaviour craftTileBehaviour;
    public GameManager gameManager;

	Dictionary<string, int> dic = new Dictionary<string, int>();

	

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

		dic.Add("w", 0);
		dic.Add("f", 1);
		dic.Add("e", 2);
		dic.Add("a", 3);
		dic.Add("wf", 4);
		dic.Add("we", 5);
		dic.Add("wa", 6);
		dic.Add("fe", 7);
		dic.Add("fa", 8);
		dic.Add("ea", 9);
		dic.Add("wfe", 10);
		dic.Add("wea", 11);
		dic.Add("wfa", 12);
		dic.Add("fea", 13);
		dic.Add("wfea", 14);

	}

    void Start()
    {
        craftTileBehaviour = GameObject.FindGameObjectWithTag("CraftTile").GetComponent<CraftTileBehaviour>();
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
	{
		checkFunction = IsCraftReady();

        crafter = gameManager.SelectedCitizen.GetComponent<CitizenBehaviour>().citizenData;

        if (IsCraftReady())
			confirmButton.interactable = true;
		else
			confirmButton.interactable = false;

	}

	private bool IsCraftReady()
	{
		foreach (GameObject s in slots)
		{
			if (s.activeInHierarchy)
			{
				if (s.GetComponent<UISlotScript>() == null)
				{
					return false;
				}
				if (!s.GetComponent<UISlotScript>().filed)
				{
					return false;
				}
			}
			

		}
		return true;
	}

    public void DoTheCraft()
    {

        int v = 0;

        if (!(currentRecipe.results.Length == 1))
        {
            dic.TryGetValue(GetIngredientsCode(), out v);
        }

        MaterialManager materialManager = gameManager.GetComponent<MaterialManager>();
        int themeIndex = 0;
        foreach(Slot slot in currentRecipe.slots)
        {
            if (slot.type == SlotType.DECORATION) //TODO: Vaso dando erro aqui
            {
                materialManager.updateDecorationResources(currentRecipe.themes[v].themes[themeIndex], -1);
            }
            if (slot.type == SlotType.STONE)
            {
                materialManager.updateBasicResources(resourceTypes.stone, -1);
            }
            if (slot.type == SlotType.WOOD)
            {
                materialManager.updateBasicResources(resourceTypes.stone, -1);
            }
            themeIndex++;
        }
        
        EmptyAllSlots();
        craftedObject = currentRecipe.results[v];
        craftTileBehaviour.PrepareCraftItem(craftedObject);
        craftTileBehaviour.CloseCraftTable();
	}

	public string GetIngredientsCode()
	{
		bool w = false;
		bool f = false;
		bool e = false;
		bool a = false;

		foreach(GameObject s in slots)
		{
			if(s != null)
				if (s.activeInHierarchy)
				{
					UISlotScript uISlot = s.GetComponent<UISlotScript>();
					if(uISlot.GetType() == typeof(DecorationSlot))
					{
						switch (uISlot.Container.type)
						{
							case Barks.GET_DECOR_WATER:
								w = true;
								break;
							case Barks.GET_DECOR_FIRE:
								f = true;
								break;
							case Barks.GET_DECOR_EARTH:
								e = true;
								break;
							case Barks.GET_DECOR_AIR:
								a = true;
								break;
						}
					}
                    if (uISlot.GetType() == typeof(InspirationSlot))
                    {
                        switch (crafter.proficience)
                        {
                            case Theme.WATER:
                                w = true;
                                break;
                            case Theme.FIRE:
                                f = true;
                                break;
                            case Theme.EARTH:
                                e = true;
                                break;
                            case Theme.AIR:
                                a = true;
                                break;
                        }

                    }
                }
        }

        string key = "";

		if (w)
			key += "w";
		if (f)
			key += "f";
		if (e)
			key += "e";
		if (a)
			key += "a";


		return key;

    }

    private void UpdateSlots(int x)
	{
		Debug.Log($"UPDATE SLOTS {x}");
		currentRecipe = recipes[x];

		for(int i = 0; i < slots.Count; i++)
		{
			if (i < currentRecipe.slots.Count)
			{
                print(currentRecipe.slots[i]);
				slots[i].SetActive(true);

				Vector3 position = slots[i].transform.position;
				Quaternion rotation = slots[i].transform.rotation;

				if(slots[i].GetComponent<UISlotScript>() != null)
				if(slots[i].GetComponent<UISlotScript>().Container != null)
				slots[i].GetComponent<UISlotScript>().Container.AddOne();

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
						if(crafter != null)
						{
							slots[i].GetComponent<UISlotScript>().Fill(crafter);
						}
						break;
				}
				
			}
			else
			{
				slots[i].SetActive(false);
			}
		}

	}

	private void EmptyAllSlots()
	{
		foreach (GameObject s in slots)
		{
			if (s != null)
				if (s.activeInHierarchy)
				{
					s.GetComponent<UISlotScript>().Remove();
				}
		}
	}

}
