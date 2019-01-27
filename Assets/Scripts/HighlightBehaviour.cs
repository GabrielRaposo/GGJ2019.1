using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightBehaviour : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
		Vector2 tileSize = GetComponentInParent<Interactable>().tileSize;
		transform.localScale = new Vector3(tileSize.x, tileSize.y, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
