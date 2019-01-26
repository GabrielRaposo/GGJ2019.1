using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacesBehaviour : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] [Range(0f, 10f)] float chanceOfGettingResources;
    [SerializeField] int maxResource = 5;
    GameObject gameManager;

    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
    }

    void collect(resourceTypes resource) {
        float rand = Random.Range(0f, 10f);
        if (rand <= chanceOfGettingResources) {
            int quantity = Random.Range(1, maxResource + 1);
            gameManager.GetComponent<MaterialManager>().updateResources(resource, quantity);
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        GameObject selectedCitizen = gameManager.GetComponent<GameManager>().SelectedCitizen;
        actions act = actions.getWood;
        resourceTypes type = resourceTypes.wood;
        if (selectedCitizen != null) {
            switch (this.gameObject.tag) {
                case "WoodWay":
                    Debug.Log("wood");
                    act = actions.getWood;
                    type = resourceTypes.wood;
                    break;
                case "StoneWay":
                    Debug.Log("stone");
                    act = actions.getStone;
                    type = resourceTypes.stone;
                    break;
                case "DecorationWay":
                    Debug.Log("decoration");
                    act = actions.getDecoration;
                    type = resourceTypes.decoration;
                    break;

            }
            if (act != null && type != null) {
                selectedCitizen.GetComponent<CitizenBehaviour>().SetTurnAction(
                    delegate () {
                        collect(type);
                    }, act);
            }
        }
    }
}
