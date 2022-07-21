using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    //public static LightManager Instance;
    [SerializeField] private StreetLight[] lightList;
    [SerializeField] private float lightTimer;
    private int _currentLight = 0;


    private void Start()
    {
        StartCoroutine(LightPatern(lightTimer));
    }

    private IEnumerator LightPatern(float time)
    {
        lightList[_currentLight].OpenClose();
        yield return new WaitForSeconds(time);
        lightList[_currentLight].OpenClose();
        _currentLight++;
        StartCoroutine(LightPatern(time));
    }

}
