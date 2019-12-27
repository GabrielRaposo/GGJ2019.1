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

	public float maxY;
	public float minY;

	public float speed;

	private void Update()
	{
		
		if (Input.GetMouseButtonDown(0))
		{
			StartCoroutine(GoDown());
		}
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

		StartCoroutine(GoUp());

	}

	IEnumerator GoUp()
	{
		visible = false;

		while (transform.position.y < maxY)
		{
			transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + Time.deltaTime * speed, transform.localPosition.z); 
			yield return null;
		}
	}

	IEnumerator GoDown()
	{
		while (transform.position.y > minY)
		{
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - Time.deltaTime * speed, transform.localPosition.z);
			yield return null;
		}
	}


}
