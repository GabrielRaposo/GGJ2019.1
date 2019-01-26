using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotType { STONE, WOOD, DECORATION, INSPIRATION}

[CreateAssetMenu(fileName = "Recipe", menuName = "Create Recipe")]
public class SORecipe : ScriptableObject
{
    public List<Slot> slots;

    public GameObject[] results;

    public ThemeSet[] themes;   

}

public class Slot
{
    public SlotType type;
} 

[System.Serializable]
public struct ThemeSet
{
    public Theme[] themes;
}


