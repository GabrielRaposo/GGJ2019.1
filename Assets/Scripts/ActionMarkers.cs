using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMarkers : MonoBehaviour
{
   private List<CitizenBehaviour> list;

   private void Awake()
   {
      list = new List<CitizenBehaviour>();
   }

   public void AddCitizen(CitizenBehaviour citizen)
   {
      list.Add(citizen);
      UnityEngine.UI.Image ball = Instantiate(citizen.circleIndicator, transform);
      ball.preserveAspect = true;
      citizen.actionMarker = this;
   }

   public void RemoveCitizen(CitizenBehaviour citizen)
   {
      citizen.actionMarker = null;
      int index = list.IndexOf(citizen);
      Destroy(transform.GetChild(index).gameObject);
      list.RemoveAt(index);
   }

   public void ClearAll()
   {
      for (int i = list.Count - 1; i >= 0; i--)
      {
         RemoveCitizen(list[i]);
      }
   }
}
