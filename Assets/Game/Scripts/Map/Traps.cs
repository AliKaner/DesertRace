using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Traps : MonoBehaviour
{
    [Header("Settings")] [SerializeField] private float forceMultiplier;
    
    private Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            _rb.AddForce( new Vector3(Random.Range(-10,10),Random.Range(0,10),Random.Range(-10,10)));
        }
    }
}
