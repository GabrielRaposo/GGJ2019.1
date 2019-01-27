using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverManager : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();   
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameManager.craftedItem != null)
        {
            gameManager.craftedItem.transform.position = transform.position;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameManager.craftedItem != null)
        {
            Color color = gameManager.craftedItem.GetComponent<SpriteRenderer>().color;
            gameManager.craftedItem.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1.0f); 
            gameManager.craftedItem = null;
        }
    }
}
