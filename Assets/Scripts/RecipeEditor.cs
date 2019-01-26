using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SORecipe))]
public class RecipeEditor : Editor
{
    SORecipe recipe;

    private int variableNumber;

    private void OnEnable()
    {
        recipe = target as SORecipe;

        if (recipe.themes?.Length == 0)
        {
            InitializeThemes();
        }
    }

    public override void OnInspectorGUI()
    {
        recipe = target as SORecipe;

        if(recipe.themes == null)
        {
            InitializeThemes();
        }

        if (recipe.themes?.Length == 0)
        {
            recipe.themes = new ThemeSet[15];

            for (int i = 0; i < 16; i++)
            {

                switch (i)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)i } };
                        break;

                    case 4:
                        recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)0, (Theme)1 } };
                        break;
                    case 5:
                        recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)0, (Theme)2 } };
                        break;
                    case 6:
                        recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)0, (Theme)3 } };
                        break;
                    case 7:
                        recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)1, (Theme)2 } };
                        break;
                    case 8:
                        recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)1, (Theme)3 } };
                        break;
                    case 9:
                        recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)2, (Theme)3 } };
                        break;
                    case 10:
                        recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)0, (Theme)1, (Theme)2 } };
                        break;
                    case 11:
                        recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)0, (Theme)2, (Theme)3 } };
                        break;
                    case 12:
                        recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)0, (Theme)1, (Theme)3 } };
                        break;
                    case 13:
                        recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)1, (Theme)2, (Theme)3 } };
                        break;
                    case 14:
                        recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)0, (Theme)1, (Theme)2, (Theme)3 } };
                        break;
                }

            }

        }

        if(recipe.slots == null)
        {
            recipe.slots = new List<Slot>();
        }

        EditorGUILayout.BeginVertical("Box");


        foreach(Slot slot in recipe.slots)
        {
            EditorGUILayout.BeginHorizontal();
            slot.type = (SlotType)EditorGUILayout.EnumPopup("", slot.type);
            if (GUILayout.Button("X"))
            {
                recipe.slots.Remove(slot);
            }
            EditorGUILayout.EndHorizontal();
        }

        if(GUILayout.Button("Add Slot"))
        {
            recipe.slots.Add(new Slot());
        }

        EditorGUILayout.EndVertical();

        if(recipe.results == null || NumberOfVariables() != variableNumber)
        {
            switch (NumberOfVariables())
            {
                case 0:
                    recipe.results = new GameObject[1];
                    break;
                case 1:
                    recipe.results = new GameObject[4];
                    break;
                case 2:
                    recipe.results = new GameObject[10];
                    break;
                case 3:
                    recipe.results = new GameObject[14];
                    break;
                case 4:
                    recipe.results = new GameObject[15];
                    break;
            }

            variableNumber = NumberOfVariables();

        }


        EditorGUILayout.BeginVertical("Box");


        for (int i = 0; i < recipe.results.Length; i++)
        {
            EditorGUILayout.BeginHorizontal();

            string labelText = "";

            switch (NumberOfVariables())
            {
                case 0:
                    labelText = "Base";
                    break;
                case 1:
                    labelText = recipe.themes[i].themes[0].ToString();
                    break;
                case 2:
                    if (i < 4)
                    {
                        labelText = recipe.themes[i].themes[0].ToString();
                    }
                    else
                    {
                        labelText = $"{recipe.themes[i].themes[0].ToString()}, {recipe.themes[i].themes[1].ToString()}";
                    }
                    break;
                case 3:
                    if (i < 4)
                    {
                        labelText = recipe.themes[i].themes[0].ToString();
                    }
                    else if (i < 10)
                    {
                        labelText = $"{recipe.themes[i].themes[0].ToString()}, {recipe.themes[i].themes[1].ToString()}";
                    }
                    else
                    {
                        labelText = $"{recipe.themes[i].themes[0].ToString()}, {recipe.themes[i].themes[1].ToString()}, {recipe.themes[i].themes[2].ToString()}";
                    }
                    break;
                case 4:
                    if (i < 4)
                    {
                        labelText = recipe.themes[i].themes[0].ToString();
                    }
                    else if (i < 10)
                    {
                        labelText = $"{recipe.themes[i].themes[0].ToString()}, {recipe.themes[i].themes[1].ToString()}";
                    }
                    else if (i < 14)
                    {
                        labelText = $"{recipe.themes[i].themes[0].ToString()}, {recipe.themes[i].themes[1].ToString()}, {recipe.themes[i].themes[2].ToString()}";
                    }
                    else
                    {
                        labelText = $"{recipe.themes[i].themes[0].ToString()}, {recipe.themes[i].themes[1].ToString()}, {recipe.themes[i].themes[2].ToString()}, {recipe.themes[i].themes[3].ToString()}";
                    }
                    break;

                default:
                    labelText = "Default";
                    break;
            }
            EditorGUILayout.LabelField(labelText);
            recipe.results[i] = (GameObject) EditorGUILayout.ObjectField(recipe.results[i], typeof(GameObject), false);
            EditorGUILayout.EndHorizontal();

        }

        EditorGUILayout.EndVertical();

        //base.OnInspectorGUI();
    }


    private int NumberOfVariables()
    {
        int i = 0;

        foreach(Slot s in recipe.slots)
        {
            if (s.type == SlotType.DECORATION || s.type == SlotType.INSPIRATION)
            {
                i++;
            }
        }

        if (i > 4)
            i = 4;

        return i;

    }

    private void InitializeThemes()
    {
        recipe.themes = new ThemeSet[15];

        for (int i = 0; i < 16; i++)
        {

            switch (i)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)i } };
                    break;

                case 4:
                    recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)0, (Theme)1 } };
                    break;
                case 5:
                    recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)0, (Theme)2 } };
                    break;
                case 6:
                    recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)0, (Theme)3 } };
                    break;
                case 7:
                    recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)1, (Theme)2 } };
                    break;
                case 8:
                    recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)1, (Theme)3 } };
                    break;
                case 9:
                    recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)2, (Theme)3 } };
                    break;
                case 10:
                    recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)0, (Theme)1, (Theme)2 } };
                    break;
                case 11:
                    recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)0, (Theme)2, (Theme)3 } };
                    break;
                case 12:
                    recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)0, (Theme)1, (Theme)3 } };
                    break;
                case 13:
                    recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)1, (Theme)2, (Theme)3 } };
                    break;
                case 14:
                    recipe.themes[i] = new ThemeSet { themes = new Theme[] { (Theme)0, (Theme)1, (Theme)2, (Theme)3 } };
                    break;
            }

        }

    }

}
