using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ItemDescriptorScript : MonoBehaviour
{
	public TextMeshProUGUI itemName;
	public TextMeshProUGUI desription;

	public Image symbolW;
	public Image symbolF;
	public Image symbolE;
	public Image symbolA;

	public bool visible;

	public float movmentDuration;

	public AnimationCurve curve;

	public RectTransform rect;
	private Vector2 startingPos;
	private Vector2 endPos;

	private IEnumerator currentRoutine;
	private Vector2 TopBottom
	{
		get
		{
			return new Vector2(rect.offsetMax.y, rect.offsetMin.y);
		}
		set
		{
			rect.offsetMax = new Vector2(rect.offsetMax.x, value.x);
			rect.offsetMin = new Vector2(rect.offsetMin.x, value.y);
		}
		
	}

	private void Awake()
	{
		rect = GetComponent<RectTransform>();
		startingPos = TopBottom;

		float mult = Screen.height * (rect.anchorMax.y - rect.anchorMin.y); 
		
		endPos = new Vector2(-475, -475);
		StartCoroutine(GoDown());
	}

	public void DisplayInfo(DecorationScript item)
	{
		visible = true;

		itemName.text = item.displayName;
		desription.text = item.description;

		symbolA.enabled = item.themes.Contains(Theme.AIR);
		symbolW.enabled = item.themes.Contains(Theme.WATER);
		symbolF.enabled = item.themes.Contains(Theme.FIRE);
		symbolE.enabled = item.themes.Contains(Theme.EARTH);

		if (currentRoutine == null)
		{
			currentRoutine = GoUp();
			StartCoroutine(currentRoutine);	
		}
		else
		{
			StopCoroutine(currentRoutine);
			currentRoutine = GoUp();
			StartCoroutine(currentRoutine);
		}
		
		

	}

	IEnumerator GoUp()
	{
		visible = false;

		float clock = 1;
		
		if (movmentDuration <= 0)
			movmentDuration = 1;
		
		while (clock > 0)
		{
			TopBottom = Vector2.Lerp(startingPos, endPos, (curve.Evaluate(clock)));
			clock -= Time.deltaTime/movmentDuration;
			yield return null;
		}
		
		visible = true;
		
		yield return new WaitForSeconds(3f);

		currentRoutine = GoDown();
		StartCoroutine(currentRoutine);

		

	}

	IEnumerator GoDown()
	{

		float clock = 0;

		if (movmentDuration <= 0)
			movmentDuration = 1;

		visible = false;
		
		while (clock < movmentDuration)
		{
			
			TopBottom = Vector2.Lerp(startingPos, endPos, (curve.Evaluate(clock)));
			clock += Time.deltaTime/movmentDuration;
			yield return null;
		}

		visible = false;
		currentRoutine = null;
	}


}
