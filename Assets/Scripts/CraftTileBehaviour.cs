using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CraftTileBehaviour : MonoBehaviour, IPointerClickHandler
{

    public GameManager gameManager;
    public DecorationScript item;
    public float alphaCreation = 0.5f;
    public GameObject mainCanvas;

    public ActionMarkers actionMarkers;
    
    void Start()
    {
        actionMarkers = GetComponentInChildren<ActionMarkers>();
    }

    public void OpenCraftTable()
    {
        SceneManager.LoadScene("CraftingScene", LoadSceneMode.Additive);
        foreach (GameObject obj in SceneManager.GetSceneByName("TilemapTest").GetRootGameObjects())
        {
            if (obj.CompareTag("MainCanvas")) obj.SetActive(false);
        }
    }

    public void CloseCraftTable()
    {
        SceneManager.UnloadScene("CraftingScene");
        foreach(GameObject obj in SceneManager.GetSceneByName("TilemapTest").GetRootGameObjects())
        {
            if (obj.CompareTag("MainCanvas")) obj.SetActive(true);
        }
    }

    public void PrepareCraftItem(GameObject item, CitizenBehaviour selectedCitizenBehaviour)
    {
        selectedCitizenBehaviour.SetTurnAction(
            delegate () {
				//gameManager.GetComponent<StoryMaster>().newItemName = item.name;
				gameManager.GetComponent<StoryMaster>().newItem = item;
            }, actions.craft);
        
        actionMarkers.AddCitizen(selectedCitizenBehaviour);
        selectedCitizenBehaviour.ClickDeselect();
        selectedCitizenBehaviour.SetClickable(false);

        GameObject instantiatedItem = Instantiate(item, new Vector3(100.0f, 100.0f, 100.0f), Quaternion.identity);
//        Color color = instantiatedItem.GetComponent<SpriteRenderer>().material.color;
  //      instantiatedItem.GetComponent<SpriteRenderer>().material.color = new Color(color.r, color.g, color.b, alphaCreation);
        gameManager.craftedItem = instantiatedItem;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameManager.SelectedCitizen != null)
        {
            CitizenBehaviour selectedCitizenBehaviour = gameManager.SelectedCitizen.GetComponent<CitizenBehaviour>();

            OpenCraftTable();
        }

    }
}
