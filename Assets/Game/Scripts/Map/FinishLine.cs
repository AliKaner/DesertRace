using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [SerializeField] private ParticleSystem[] winParticles;
    [SerializeField] private GameObject finishUI;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Finish")) return;
        FreeCamera();
        PlayParticles();
        ActivateUI();
    }

    private void FreeCamera()
    {
        camera.parent = null;
    }

    private void PlayParticles()
    {
        foreach (ParticleSystem particle in winParticles)
        {
            particle.Play();
        }
    }

    private void ActivateUI()
    {
        finishUI.SetActive(true);
    }
}
