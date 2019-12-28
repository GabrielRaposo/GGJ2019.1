using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class PlacesBehaviour : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] [Range(0f, 10f)] float chanceOfGettingDecorationResources;
    GameObject gameManager;
    GameObject selectedCitizen;
    public ActionMarkers actionMarkers;
    private StoryMaster storyMaster;

    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        storyMaster = GameManager.FindObjectOfType<StoryMaster>();
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
        
        GameObject selectedCitizenObject = gameManager.GetComponent<GameManager>().SelectedCitizen;
        
        if(selectedCitizenObject == null) return;
        
        CitizenBehaviour selectedCitizen = selectedCitizenObject.GetComponent<CitizenBehaviour>();

        if (!selectedCitizen.hasTent)
        {
            selectedCitizen.ClickDeselect();
            return;
        }
        
        actions act = actions.getWood;
        resourceTypes type = resourceTypes.wood;
        
        if (selectedCitizenObject != null) {
            selectedCitizen.ClickDeselect();
            Theme proficience = selectedCitizen.CitizenData.proficience;
            Debug.Log(proficience);
            switch (gameObject.tag) {
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
                if (this.gameObject.tag == "DecorationWay")
                {
                    if(selectedCitizen.actionMarker!=null)
                        selectedCitizen.actionMarker.RemoveCitizen(selectedCitizen);
                    
                    actionMarkers.AddCitizen(selectedCitizen);

                    switch (proficience)
                    {
                        case Theme.WATER:
                            storyMaster.Bark(Barks.GET_DECOR_WATER, selectedCitizen);
                            break;
                        case Theme.FIRE:
                            storyMaster.Bark(Barks.GET_DECOR_FIRE, selectedCitizen);
                            break;
                        case Theme.EARTH:
                            storyMaster.Bark(Barks.GET_DECOR_EARTH, selectedCitizen);
                            break;
                        case Theme.AIR:
                            storyMaster.Bark(Barks.GET_DECOR_AIR, selectedCitizen);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    
                    selectedCitizen.SetTurnAction(
                    delegate () {
                        collectDecoration(proficience);
                    }, act);
                }
                else
                {
                    if(selectedCitizen.actionMarker != null)
                        selectedCitizen.actionMarker.RemoveCitizen(selectedCitizen);
                    actionMarkers.AddCitizen(selectedCitizen);
                    
                    if(act == actions.getStone)
                        storyMaster.Bark(Barks.GET_STONE, selectedCitizen);
                    else if(act == actions.getWood)
                        storyMaster.Bark(Barks.GET_WOOD, selectedCitizen);
                    
                    selectedCitizen.SetTurnAction(
                        delegate () {
                            collectBasic(type, proficience);
                        }, act);
                }
            }
        }
    }
}
