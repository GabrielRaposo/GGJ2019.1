using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DebrisBehaviour : MonoBehaviour, IPointerClickHandler {

    [SerializeField] [Range(0f, 10f)] float resourceChance;

    MaterialManager materialManager;
    GameManager gameManager;


    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

    public void CleanDebris() {
        gameManager.gameObject.GetComponent<DayBehaviour>().RemoveInteractableObject(this.gameObject);
        Destroy(this.gameObject);
        List<resourceTypes> resourceList = rollForResources();
        if (resourceList.Count > 0) {
            foreach (resourceTypes resource in resourceList) {
                gameManager.gameObject.GetComponent<MaterialManager>().updateResources(resource, 1);
            }
        }
    }

    List<resourceTypes> rollForResources() {
        List<resourceTypes> resourceList = new List<resourceTypes>();
        float rand = Random.Range(0f, 10f);

        if (rand <= resourceChance) {
            int quantity = Random.Range(0, 3);

            for (int i = 0; i < quantity; i++) {
                if (Random.Range(0, 2) == 0)
                    resourceList.Add(resourceTypes.stone);
                else
                    resourceList.Add(resourceTypes.wood);
            }
        }
        return resourceList;
    }

    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("cliquei no entulho");
        CitizenBehaviour selectedCitizenBehaviour = gameManager.SelectedCitizen.GetComponent<CitizenBehaviour>();
        selectedCitizenBehaviour.SetTurnAction(
            delegate () {
                CleanDebris();
            }, actions.cleanDebris);
    }
}
