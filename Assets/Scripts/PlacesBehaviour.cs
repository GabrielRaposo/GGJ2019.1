using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacesBehaviour : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] [Range(0f, 10f)] float chanceOfGettingDecorationResources;
    GameObject gameManager;
    GameObject selectedCitizen;

    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
    }

    void collectBasic(resourceTypes resource, Theme proficience) {
        gameManager.GetComponent<MaterialManager>().updateBasicResources(resource, 1);

        float rand = Random.Range(0f, 10f);
        if (rand <= chanceOfGettingDecorationResources) {
            gameManager.GetComponent<MaterialManager>().updateDecorationResources(proficience, 1);
        }
    }

    void collectDecoration(Theme proficience) {
        gameManager.GetComponent<MaterialManager>().updateDecorationResources(proficience, 1);
        int other = Random.Range(0, System.Enum.GetNames(typeof(Theme)).Length);

        Theme bonus = Theme.FIRE;
        switch (other) {
            case 0:
                bonus = Theme.FIRE;
                break;
            case 1:
                bonus = Theme.AIR;
                break;
            case 2:
                bonus = Theme.EARTH;
                break;
            case 3:
                bonus = Theme.WATER;
                break;
        }
        gameManager.GetComponent<MaterialManager>().updateDecorationResources(bonus, 1);
    }

    public void OnPointerClick(PointerEventData eventData) {
        GameObject selectedCitizen = gameManager.GetComponent<GameManager>().SelectedCitizen;

        actions act = actions.getWood;
        resourceTypes type = resourceTypes.wood;

        
        
        if (selectedCitizen != null) {
            selectedCitizen.GetComponent<CitizenBehaviour>().ClickDeselect();
            Theme proficience = selectedCitizen.GetComponent<CitizenBehaviour>().CitizenData.proficience;
            Debug.Log(proficience);
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
                    break;

            }
            if (act != null && type != null) {
                if (this.gameObject.tag == "DecorationWay") {
                    selectedCitizen.GetComponent<CitizenBehaviour>().SetTurnAction(
                    delegate () {
                        collectDecoration(proficience);
                    }, act);
                } else {
                selectedCitizen.GetComponent<CitizenBehaviour>().SetTurnAction(
                    delegate () {
                        collectBasic(type, proficience);
                    }, act);
                }
            }
        }
    }
}
