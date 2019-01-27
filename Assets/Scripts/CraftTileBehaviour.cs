using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CraftTileBehaviour : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private GameManager gameManager;
    public DecorationScript item;
    public float alphaCreation = 0.5f;
    public GameObject mainCanvas;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenCraftTable()
    {
        SceneManager.LoadScene("CraftingScene", LoadSceneMode.Additive);
        mainCanvas.SetActive(false);
    }

    public void CloseCraftTable()
    {
        SceneManager.UnloadSceneAsync("CraftingScene");
        mainCanvas.SetActive(true);
    }

    public void PrepareCraftItem(GameObject item)
    {
        CitizenBehaviour selectedCitizenBehaviour = gameManager.SelectedCitizen.GetComponent<CitizenBehaviour>();
        selectedCitizenBehaviour.SetTurnAction(
            delegate () {
                gameManager.GetComponent<StoryMaster>().newItemName = item.name;
            }, actions.craft);
        selectedCitizenBehaviour.OnPointerClick(null);

        GameObject instantiatedItem = Instantiate(item, new Vector3(100.0f, 100.0f, 100.0f), Quaternion.identity);
        Color color = instantiatedItem.GetComponent<SpriteRenderer>().material.color;
        instantiatedItem.GetComponent<SpriteRenderer>().material.color = new Color(color.r, color.g, color.b, alphaCreation);
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
