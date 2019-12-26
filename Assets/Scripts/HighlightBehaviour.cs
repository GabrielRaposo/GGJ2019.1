using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightBehaviour : MonoBehaviour
{
	public AnimationCurve curve;
	private Vector3 startingScale;
	public float speed;
	private float time;
	
    void Start()
    {
		Vector2 tileSize = GetComponentInParent<Interactable>().tileSize;
		startingScale = new Vector3(tileSize.x, tileSize.y, 1.0f);
		transform.localScale = startingScale;
    }

    void Update()
    {
	    time += speed * Time.deltaTime;
	    time %= 1;
	    transform.localScale = startingScale * (curve.Evaluate(time) + 1f);
    }
}
