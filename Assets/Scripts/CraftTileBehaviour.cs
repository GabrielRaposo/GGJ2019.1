using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CraftTileBehaviour : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private GameManager gameManager;
    public DecorationScript item;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenCraftTable()
    {
        SceneManager.LoadScene("CraftingScene", LoadSceneMode.Additive);
        GameObject.FindGameObjectWithTag("MainCanvas").SetActive(false);
    }

    public void CloseCraftTable()
    {
        SceneManager.UnloadSceneAsync("CraftingScene");
        GameObject.FindGameObjectWithTag("MainCanvas").SetActive(false);
    }

    public void PrepareCraftItem(GameObject item)
    {
        CitizenBehaviour selectedCitizenBehaviour = gameManager.SelectedCitizen.GetComponent<CitizenBehaviour>();
        selectedCitizenBehaviour.SetTurnAction(
            delegate () {
            }, actions.craft);
        selectedCitizenBehaviour.OnPointerClick(null);
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
