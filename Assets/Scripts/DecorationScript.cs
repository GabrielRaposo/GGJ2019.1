using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DecorationScript : MonoBehaviour, IPointerClickHandler
{
	public string displayName;
	public string description;
	public List<Theme> themes;
	public GameObject cursor;

	public bool placed;

	private void Awake()
	{
		Collider2D col = GetComponent<Collider2D>();
		if(col!=null)
			col.enabled = false;
	}

	void ShowDescrption()
	{
		FindObjectOfType<ItemDescriptorScript>().DisplayInfo(this);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if(!placed)
			return;
	
		Debug.Log($"{displayName}: Decoration Click");
		ShowDescrption();
	}

	public void Place()
	{
		placed = true;
		GetComponent<Collider2D>().enabled = true;
	}
	
	
	
}
