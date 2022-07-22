using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [SerializeField] private ParticleSystem[] winParticles;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Finish")) return;
        FreeCamera();
        PlayParticles();
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
}
