using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLight : MonoBehaviour
{
   [SerializeField] private Light light;

   public void OpenClose()
   {
      light.enabled = !light.enabled;
   }
}
